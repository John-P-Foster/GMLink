using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GMLink.Models
{
    public class AppUserDetail
    {
        public int AppUserDetailID { get; set; }
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
    }
}
