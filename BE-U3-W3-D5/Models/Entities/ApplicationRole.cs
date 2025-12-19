using Microsoft.AspNetCore.Identity;

namespace BE_U3_W3_D5.Models.Entities
{
    public class ApplicationRole : IdentityRole
    {
        public string Role { get; set; }
    }
}
