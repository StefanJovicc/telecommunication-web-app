using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelecommunicationWebApp.Application.DTO;
using TelecommunicationWebApp.DataAccess;

namespace TelecommunicationWebApp.Implementation.Validators.IssueDiscount
{
    public class IssueDiscountDTOValidator : AbstractValidator<IssueDiscountDTO>
    {
        public IssueDiscountDTOValidator(TelecommunicationContext ctx)
        {
            CascadeMode = CascadeMode.StopOnFirstFailure;

            RuleFor(x => x.UserId).NotEmpty();
            RuleFor(x => x.IssuerId).NotEmpty();
            // Rule for employee so he cant do more than 5 discounts per day
            // Rule for customer so he cant recieve more than 1 discount per day
        }
    }
}
