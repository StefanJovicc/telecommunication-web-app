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
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(x => x.Fullname)
                   .IsRequired()
                   .HasMaxLength(60);

            builder.Property(x => x.Email)
                   .IsRequired();

            builder.Property(x => x.Password)
                   .IsRequired();

            builder.Property(x => x.SocialSecurityNumber)
                   .IsRequired()
                   .HasMaxLength(9);

            builder.Property(x => x.DateOfBirth)
                   .IsRequired();

            builder.Property(x => x.Age)
                   .IsRequired();

            builder.HasOne(x => x.Home)
                   .WithMany(x => x.HomeUsers)
                   .HasForeignKey(x => x.HomeId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Office)
                   .WithMany(x => x.OfficeUsers)
                   .HasForeignKey(x => x.OfficeId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
