using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelecommunicationWebApp.Domain
{
    public class User : Entity
    {
        public string Fullname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string SocialSecurityNumber { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int HomeId { get; set; }
        public int OfficeId { get; set; }
        public int? SpouseId { get; set; }
        public int Age { get; set; }

        public Address Home { get; set; }
        public Address Office { get; set; }
        public User Spouse { get; set; }
        public ICollection<User> SpouseUsers { get; set; } = new HashSet<User>();
    }
}
