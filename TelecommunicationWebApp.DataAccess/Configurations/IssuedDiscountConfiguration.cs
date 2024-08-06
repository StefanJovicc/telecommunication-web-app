using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelecommunicationWebApp.Domain;

namespace TelecommunicationWebApp.DataAccess.Configurations
{
    public class IssuedDiscountConfiguration : IEntityTypeConfiguration<IssuedDiscount>
    {
        public void Configure(EntityTypeBuilder<IssuedDiscount> builder)
        {
            builder.Property(x => x.ExpirationDate)
                   .IsRequired();

            builder.HasOne(x => x.Employee)
                   .WithMany(x => x.GivenDiscounts)
                   .HasForeignKey(x => x.EmployeeId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Customer)
                   .WithMany(x => x.RecievedDiscounts)
                   .HasForeignKey(x => x.CustomerId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
