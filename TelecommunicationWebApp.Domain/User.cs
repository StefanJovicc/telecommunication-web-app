using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelecommunicationWebApp.Domain
{
    public class User : Entity
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int RoleId { get; set; }
        public string SSN { get; set; }
        public DateTime DOB { get; set; }
        public int HomeId { get; set; }
        public int OfficeId { get; set; }
        public int? SpouseId { get; set; }
        public int Age { get; set; }
        public string Title { get; set; }
        public decimal? Salary { get; set; }

        public Role Role { get; set; }
        public Address Home { get; set; }
        public Address Office { get; set; }
        public User Spouse { get; set; }
        // public ICollection<UserUseCase> UseCases { get; set; }
    }
}
