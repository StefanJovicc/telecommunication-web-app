using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelecommunicationWebApp.Domain
{
    public class IssuedDiscount : Entity
    {
        public int EmployeeId { get; set; }
        public int CustomerId { get; set; }
        public bool Used { get; set; }
        public DateTime ExpirationDate { get; set; }

        public Employee Employee { get; set; }
        public User Customer { get; set; }
        public ICollection<Purchase> Purchases { get; set; }
    }
}
