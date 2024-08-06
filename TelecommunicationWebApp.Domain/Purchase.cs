using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelecommunicationWebApp.Domain
{
    public class Purchase : Entity
    {
        public int CustomerId { get; set; }
        public int ServiceId { get; set; }
        public int? DiscountId { get; set; }

        public User Customer { get; set; }
        public Service Service { get; set; }
        public IssuedDiscount Discount { get; set; }
    }
}
