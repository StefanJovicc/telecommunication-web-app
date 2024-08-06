using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelecommunicationWebApp.Domain
{
    public class Employee : Entity
    {
        public int UserId { get; set; }
        public string Title { get; set; }
        public decimal? Salary { get; set; }
        public string Notes { get; set; }

        public User User { get; set; }
        public ICollection<IssuedDiscount> GivenDiscounts { get; set; }
    }
}
