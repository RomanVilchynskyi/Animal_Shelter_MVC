namespace Animal_Shelter.Data.Entities
{
    public class AnimalQuestionnaire
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty; // ім’я тварини
        public string? ImageUrl { get; set; } // фото

        public int Age { get; set; } // вік у роках
        public bool IsVaccinated { get; set; } // щеплена чи ні
        public bool IsSterilized { get; set; } // стерилізована чи ні
        public bool HasMedicalIssues { get; set; } // наявність проблем зі здоров’ям

        public string? Description { get; set; } // додаткова інформація, характер
        public DateTime AdmissionDate { get; set; } // коли потрапила в притулок

        // ---- Зовнішні ключі
        public int SpeciesId { get; set; }
        public int BreedId { get; set; }
        public int GenderId { get; set; }

        // ---- Навігаційні властивості
        public Species? Species { get; set; }
        public Breed? Breed { get; set; }
        public Gender? Gender { get; set; }
    }
}
