using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GMLink.Models
{
    public class PlayerAccount
    {
        public int PlayerAccountID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string CardNumber { get; set; }
        public string ExpirationDate { get; set; }
        public string CardholderName { get; set; }
        public string SecurityCode { get; set; }

    }
}