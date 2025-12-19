using Microsoft.AspNetCore.Identity;

namespace BE_U3_W3_D5.Models.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }

        public string Surname { get; set; }

        public DateTime CreateAt { get; set; }

        public bool IsDeleted { get; set; }
        public DateTime Birthday { get; set; }
    }
}
