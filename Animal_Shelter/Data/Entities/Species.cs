namespace Animal_Shelter.Data.Entities
{
    public class Species
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty; // Напр. "Собака", "Кіт", "Кролик"

        public ICollection<AnimalQuestionnaire>? Animals { get; set; }
    }
}
