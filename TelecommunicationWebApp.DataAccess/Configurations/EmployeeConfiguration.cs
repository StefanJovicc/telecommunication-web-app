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
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.Property(x => x.Title)
                   .IsRequired();

            builder.HasOne(x => x.User)
                   .WithOne(x => x.Employee)
                   .HasForeignKey<Employee>(x => x.UserId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
