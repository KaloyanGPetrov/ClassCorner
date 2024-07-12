using Microsoft.AspNetCore.Identity;

namespace ClassCorner.Models
{
    public class AppUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Role { get; set; }


    }
}
