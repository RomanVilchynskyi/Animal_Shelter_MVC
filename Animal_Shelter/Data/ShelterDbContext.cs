
using Animal_Shelter.Data.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace Animal_Shelter.Data
{
    public class ShelterDbContext : IdentityDbContext
    {
        public ShelterDbContext()
        {
            //Database.EnsureCreated();
        }
        public ShelterDbContext(DbContextOptions<ShelterDbContext> options) : base(options) { }

        public DbSet<Entities.AnimalQuestionnaire> AnimalQuestionnaires { get; set; } = null!;
        public DbSet<Entities.Species> Species { get; set; } = null!;
        public DbSet<Entities.Breed> Breeds { get; set; } = null!;
        public DbSet<Entities.Gender> Gender { get; set; } = null!;

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    base.OnConfiguring(optionsBuilder);

        //    optionsBuilder.UseSqlServer("");
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Species>().HasData(new[]
            {
                new Species { Id = 1, Name = "Dog" },
                new Species { Id = 2, Name = "Cat" },
                new Species { Id = 3, Name = "Rabbit" },
                new Species { Id = 4, Name = "Bird" },
                new Species { Id = 5, Name = "Other" }
            });

            modelBuilder.Entity<Breed>().HasData(new[]
            {
                new Breed { Id = 1, Name = "Labrador", SpeciesId = 1 },
                new Breed { Id = 2, Name = "German Shepherd", SpeciesId = 1 },
                new Breed { Id = 3, Name = "Persian", SpeciesId = 2 },
                new Breed { Id = 4, Name = "Siamese", SpeciesId = 2 },
                new Breed { Id = 5, Name = "Dwarf Rabbit", SpeciesId = 3 },
                new Breed { Id = 6, Name = "Macaw", SpeciesId = 4 },
                new Breed { Id = 7, Name = "Mixed", SpeciesId = 5 }
            });

            modelBuilder.Entity<Gender>().HasData(new[]
            {
                new Gender { Id = 1, Name = "Male" },
                new Gender { Id = 2, Name = "Female" },
                new Gender { Id = 3, Name = "Unknown" }
            });

            modelBuilder.Entity<AnimalQuestionnaire>().HasData(new List<AnimalQuestionnaire>()
            {
                new AnimalQuestionnaire
                {
                    Id = 1,
                    Name = "Buddy",
                    Age = 3,
                    SpeciesId = 1, // Dog
                    BreedId = 1,   // Labrador
                    GenderId = 1,  // Male
                    IsVaccinated = true,
                    IsSterilized = true,
                    HasMedicalIssues = false,
                    Description = "Friendly and energetic Labrador, loves kids.",
                    AdmissionDate = new DateTime(2023, 5, 12),
                    ImageUrl = "https://www.vidavetcare.com/wp-content/uploads/sites/234/2022/04/labrador-retriever-dog-breed-info.jpeg"
                },
                new AnimalQuestionnaire
                {
                    Id = 2,
                    Name = "Misty",
                    Age = 2,
                    SpeciesId = 2, // Cat
                    BreedId = 3,   // Persian
                    GenderId = 2,  // Female
                    IsVaccinated = true,
                    IsSterilized = false,
                    HasMedicalIssues = false,
                    Description = "Calm Persian cat, prefers quiet places.",
                    AdmissionDate = new DateTime(2024, 1, 20),
                    ImageUrl = "https://cdn.pixabay.com/photo/2017/11/09/21/41/cat-2934720_960_720.jpg"
                },
                new AnimalQuestionnaire
                {
                    Id = 3,
                    Name = "Shadow",
                    Age = 1,
                    SpeciesId = 2, // Cat
                    BreedId = 4,   // Siamese
                    GenderId = 1,  // Male
                    IsVaccinated = false,
                    IsSterilized = false,
                    HasMedicalIssues = false,
                    Description = "Playful Siamese kitten, full of energy.",
                    AdmissionDate = new DateTime(2024, 7, 10),
                    ImageUrl = "https://cdn.pixabay.com/photo/2016/02/10/16/37/siamese-cat-1192026_960_720.jpg"
                },
                new AnimalQuestionnaire
                {
                    Id = 4,
                    Name = "Lola",
                    Age = 4,
                    SpeciesId = 1, // Dog
                    BreedId = 2,   // German Shepherd
                    GenderId = 2,  // Female
                    IsVaccinated = true,
                    IsSterilized = true,
                    HasMedicalIssues = true,
                    Description = "German Shepherd, intelligent and loyal, has mild hip dysplasia.",
                    AdmissionDate = new DateTime(2022, 9, 5),
                    ImageUrl = "https://cdn.pixabay.com/photo/2015/06/03/13/13/german-shepherd-796259_960_720.jpg"
                }


            });
            modelBuilder.Entity<AnimalQuestionnaire>()
                .HasOne(a => a.Species)
                .WithMany()
                .HasForeignKey(a => a.SpeciesId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<AnimalQuestionnaire>()
                .HasOne(a => a.Breed)
                .WithMany()
                .HasForeignKey(a => a.BreedId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<AnimalQuestionnaire>()
                .HasOne(a => a.Gender)
                .WithMany()
                .HasForeignKey(a => a.GenderId)
                .OnDelete(DeleteBehavior.Restrict);


        }
    }
}
