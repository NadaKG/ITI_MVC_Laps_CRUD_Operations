using Microsoft.AspNetCore.Identity;

namespace Day9.Models
{
    public class AppUser:IdentityUser
    {
        public string First_Name { get; set; }
        public string Last_Name { get; set;}
        public string? Nationality { get; set; }
    }
}
