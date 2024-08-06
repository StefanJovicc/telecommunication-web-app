using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelecommunicationWebApp.Domain
{
    public class Color : Entity
    {
        public string Name { get; set; }

        public ICollection<UserColor> UsersFavorite { get; set; }
    }
}
