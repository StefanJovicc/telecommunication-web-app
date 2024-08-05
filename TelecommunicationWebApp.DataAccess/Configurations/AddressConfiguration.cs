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
                   .IsRequired();

            builder.Property(x => x.City)
                   .IsRequired();

            builder.Property(x => x.State)
                   .HasMaxLength(2)
                   .IsRequired();

            builder.Property(x => x.Zip)
                   .HasMaxLength(5)
                   .IsRequired();
        }
    }
}
