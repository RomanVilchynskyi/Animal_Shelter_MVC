using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Animal_Shelter.Migrations
{
    /// <inheritdoc />
    public partial class InitSomee : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AnimalQuestionnaires",
                keyColumn: "Id",
                keyValue: 1,
                column: "ImageUrl",
                value: "https://www.vidavetcare.com/wp-content/uploads/sites/234/2022/04/labrador-retriever-dog-breed-info.jpeg");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AnimalQuestionnaires",
                keyColumn: "Id",
                keyValue: 1,
                column: "ImageUrl",
                value: "https://cdn.pixabay.com/photo/2016/02/19/10/00/dog-1209621_960_720.jpg");
        }
    }
}
