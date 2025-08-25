namespace Animal_Shelter.Data.Entities
{
    public class Breed
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty; // Напр. "Лабрадор", "Перс"

        public int SpeciesId { get; set; }
        public Species? Species { get; set; }

        public ICollection<AnimalQuestionnaire>? Animals { get; set; }
    }
}
