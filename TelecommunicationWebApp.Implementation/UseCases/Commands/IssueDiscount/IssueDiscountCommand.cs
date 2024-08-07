using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelecommunicationWebApp.Application.DTO;
using TelecommunicationWebApp.Application.UseCases.Commands.IssueDiscount;
using TelecommunicationWebApp.DataAccess;
using TelecommunicationWebApp.Domain;
using TelecommunicationWebApp.Implementation.Validators.IssueDiscount;

namespace TelecommunicationWebApp.Implementation.UseCases.Commands.IssueDiscount
{
    public class IssueDiscountCommand : EfUseCase, IIssueDiscountCommand
    {
        private IssueDiscountDTOValidator _validator;

        public IssueDiscountCommand(TelecommunicationContext context, IssueDiscountDTOValidator validator) : base(context)
        {
            _validator = validator;
        }

        public int Id => 1;

        public string Name => "Issue Discounts Command";

        public void Execute(IssueDiscountDTO data)
        {
            _validator.ValidateAndThrow(data);

            IssuedDiscount issuedDiscount = new IssuedDiscount
            {
                CustomerId = data.UserId,
                EmployeeId = data.IssuerId,
                Used = false,
                ExpirationDate = DateTime.UtcNow.AddDays(7)
            };

            Context.IssuedDiscounts.Add(issuedDiscount);
            Context.SaveChanges();

            RandomPurchase(data.UserId);
        }

        private void RandomPurchase(int userId)
        {
            Random randomEntry = new Random();
            int randomServiceId = randomEntry.Next(1, 4);
            int randomUseOfDiscount = randomEntry.Next(0, 2);

            Purchase purchase = new Purchase
            {
                CustomerId = userId,
                ServiceId = randomServiceId,
                DiscountId = Context.IssuedDiscounts.Where(x => x.CustomerId == userId && x.IsActive == true).FirstOrDefault().Id
            };

            Context.Purchases.Add(purchase);
            Context.SaveChanges();

            if (randomUseOfDiscount == 1)
            {
                IssuedDiscount usedDiscount = Context.IssuedDiscounts.Where(x => x.CustomerId == userId && x.IsActive == true).FirstOrDefault();
                usedDiscount.Used = true;
                usedDiscount.IsActive = false;
                Console.WriteLine($"User with id {userId} has used his discount with id {usedDiscount.Id}.");
            }

            Context.SaveChanges();
        }
    }
}
