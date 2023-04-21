using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GMLink.Models
{
    public class PlayerAccount : User
    {
        public int Player_ID { get; set; }
        public int Group_ID { get; set; }
        public int Cart_ID { get; set; } 
    }
}