namespace Animal_Shelter.Data.Entities
{
    public class Gender
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty; // Напр. "Самець", "Самка"

        public ICollection<AnimalQuestionnaire>? Animals { get; set; }
    }
}
