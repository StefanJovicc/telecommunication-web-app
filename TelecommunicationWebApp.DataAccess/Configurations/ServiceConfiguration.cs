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
    public class ServiceConfiguration : IEntityTypeConfiguration<Service>
    {
        public void Configure(EntityTypeBuilder<Service> builder)
        {
            builder.Property(x => x.Name)
                   .IsRequired();

            builder.Property(x => x.Description)
                   .HasMaxLength(150)
                   .IsRequired();

            builder.Property(x => x.Price)
                   .IsRequired();

            builder.HasIndex(x => x.Name)
                   .IsUnique();
        }
    }
}
