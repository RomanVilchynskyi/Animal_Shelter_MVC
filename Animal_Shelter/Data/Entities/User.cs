using Microsoft.AspNetCore.Identity;

namespace Animal_Shelter.Data.Entities
{
    public class User : IdentityUser
    {
        public string FullName { get; set; }
        public decimal? Donations { get; set; }
    }
}
