using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations;

namespace GMlink.Models
{
    public class FakeCartItems
    {

        public int ReservationID { get; set; }
 
        public int GameMasterID { get; set; }


        public string GroupID { get; set; }

        public string DateTime { get; set; }
    }
}