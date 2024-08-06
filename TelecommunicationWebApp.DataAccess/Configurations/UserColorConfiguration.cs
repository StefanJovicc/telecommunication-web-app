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
    public class UserColorConfiguration : IEntityTypeConfiguration<UserColor>
    {
        public void Configure(EntityTypeBuilder<UserColor> builder)
        {
            builder.HasKey(x => new { x.UserId, x.ColorId });
        }
    }
}
