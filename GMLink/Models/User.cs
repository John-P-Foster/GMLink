using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GMLink.Models
{
    public class User
    {
        public int Username { get; set; }
        public int Password { get; set; }
        public int Name { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public decimal Email { get; set; }
        public string BillingInformation { get; set; }

    }
}