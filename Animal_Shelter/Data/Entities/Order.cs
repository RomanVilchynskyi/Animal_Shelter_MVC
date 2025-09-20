using Microsoft.AspNetCore.Identity;

namespace Animal_Shelter.Data.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }

        public string AnimalName { get; set; }

        public string UserId { get; set; }
        public User User { get; set; }
    }
}
