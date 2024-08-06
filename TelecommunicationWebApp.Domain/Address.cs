using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelecommunicationWebApp.Domain
{
    public class Address : Entity
    {
        public string Street { get; set; }
        public int CityId { get; set; }
        public int StateId { get; set; }
        public string Zip { get; set; }

        public City City { get; set; }
        public State State { get; set; }
        public ICollection<User> HomeUsers { get; set; } = new HashSet<User>();
        public ICollection<User> OfficeUsers { get; set; } = new HashSet<User>();
    }
}
