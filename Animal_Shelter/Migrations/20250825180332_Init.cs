using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Animal_Shelter.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Gender",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gender", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Species",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Species", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Breeds",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SpeciesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Breeds", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Breeds_Species_SpeciesId",
                        column: x => x.SpeciesId,
                        principalTable: "Species",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AnimalQuestionnaires",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Age = table.Column<int>(type: "int", nullable: false),
                    IsVaccinated = table.Column<bool>(type: "bit", nullable: false),
                    IsSterilized = table.Column<bool>(type: "bit", nullable: false),
                    HasMedicalIssues = table.Column<bool>(type: "bit", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AdmissionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SpeciesId = table.Column<int>(type: "int", nullable: false),
                    BreedId = table.Column<int>(type: "int", nullable: false),
                    GenderId = table.Column<int>(type: "int", nullable: false),
                    BreedId1 = table.Column<int>(type: "int", nullable: true),
                    GenderId1 = table.Column<int>(type: "int", nullable: true),
                    SpeciesId1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnimalQuestionnaires", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AnimalQuestionnaires_Breeds_BreedId",
                        column: x => x.BreedId,
                        principalTable: "Breeds",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AnimalQuestionnaires_Breeds_BreedId1",
                        column: x => x.BreedId1,
                        principalTable: "Breeds",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AnimalQuestionnaires_Gender_GenderId",
                        column: x => x.GenderId,
                        principalTable: "Gender",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AnimalQuestionnaires_Gender_GenderId1",
                        column: x => x.GenderId1,
                        principalTable: "Gender",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AnimalQuestionnaires_Species_SpeciesId",
                        column: x => x.SpeciesId,
                        principalTable: "Species",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AnimalQuestionnaires_Species_SpeciesId1",
                        column: x => x.SpeciesId1,
                        principalTable: "Species",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Gender",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Male" },
                    { 2, "Female" },
                    { 3, "Unknown" }
                });

            migrationBuilder.InsertData(
                table: "Species",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Dog" },
                    { 2, "Cat" },
                    { 3, "Rabbit" },
                    { 4, "Bird" },
                    { 5, "Other" }
                });

            migrationBuilder.InsertData(
                table: "Breeds",
                columns: new[] { "Id", "Name", "SpeciesId" },
                values: new object[,]
                {
                    { 1, "Labrador", 1 },
                    { 2, "German Shepherd", 1 },
                    { 3, "Persian", 2 },
                    { 4, "Siamese", 2 },
                    { 5, "Dwarf Rabbit", 3 },
                    { 6, "Macaw", 4 },
                    { 7, "Mixed", 5 }
                });

            migrationBuilder.InsertData(
                table: "AnimalQuestionnaires",
                columns: new[] { "Id", "AdmissionDate", "Age", "BreedId", "BreedId1", "Description", "GenderId", "GenderId1", "HasMedicalIssues", "ImageUrl", "IsSterilized", "IsVaccinated", "Name", "SpeciesId", "SpeciesId1" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 5, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 1, null, "Friendly and energetic Labrador, loves kids.", 1, null, false, "https://cdn.pixabay.com/photo/2016/02/19/10/00/dog-1209621_960_720.jpg", true, true, "Buddy", 1, null },
                    { 2, new DateTime(2024, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 3, null, "Calm Persian cat, prefers quiet places.", 2, null, false, "https://cdn.pixabay.com/photo/2017/11/09/21/41/cat-2934720_960_720.jpg", false, true, "Misty", 2, null },
                    { 3, new DateTime(2024, 7, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 4, null, "Playful Siamese kitten, full of energy.", 1, null, false, "https://cdn.pixabay.com/photo/2016/02/10/16/37/siamese-cat-1192026_960_720.jpg", false, false, "Shadow", 2, null },
                    { 4, new DateTime(2022, 9, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 2, null, "German Shepherd, intelligent and loyal, has mild hip dysplasia.", 2, null, true, "https://cdn.pixabay.com/photo/2015/06/03/13/13/german-shepherd-796259_960_720.jpg", true, true, "Lola", 1, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AnimalQuestionnaires_BreedId",
                table: "AnimalQuestionnaires",
                column: "BreedId");

            migrationBuilder.CreateIndex(
                name: "IX_AnimalQuestionnaires_BreedId1",
                table: "AnimalQuestionnaires",
                column: "BreedId1");

            migrationBuilder.CreateIndex(
                name: "IX_AnimalQuestionnaires_GenderId",
                table: "AnimalQuestionnaires",
                column: "GenderId");

            migrationBuilder.CreateIndex(
                name: "IX_AnimalQuestionnaires_GenderId1",
                table: "AnimalQuestionnaires",
                column: "GenderId1");

            migrationBuilder.CreateIndex(
                name: "IX_AnimalQuestionnaires_SpeciesId",
                table: "AnimalQuestionnaires",
                column: "SpeciesId");

            migrationBuilder.CreateIndex(
                name: "IX_AnimalQuestionnaires_SpeciesId1",
                table: "AnimalQuestionnaires",
                column: "SpeciesId1");

            migrationBuilder.CreateIndex(
                name: "IX_Breeds_SpeciesId",
                table: "Breeds",
                column: "SpeciesId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AnimalQuestionnaires");

            migrationBuilder.DropTable(
                name: "Breeds");

            migrationBuilder.DropTable(
                name: "Gender");

            migrationBuilder.DropTable(
                name: "Species");
        }
    }
}
