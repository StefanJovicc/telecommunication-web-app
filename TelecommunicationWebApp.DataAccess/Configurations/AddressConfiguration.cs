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
    public class AddressConfiguration : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.Property(x => x.Street)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(x => x.Zip)
                   .IsRequired()
                   .HasMaxLength(5);

            builder.HasOne(x => x.City)
                   .WithMany(x => x.Addresses)
                   .HasForeignKey(x => x.CityId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.State)
                   .WithMany(x => x.Addresses)
                   .HasForeignKey(x => x.StateId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
