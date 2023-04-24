using Microsoft.AspNetCore.Identity;

namespace GMLink.Models
{
    public class User : IdentityUser<Guid>
    {
        public bool IsGM { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserAddress { get; set; }
        public string UserPhoneNumber { get; set; }
        public string UserEmailAddress { get; set; }
    }
}
