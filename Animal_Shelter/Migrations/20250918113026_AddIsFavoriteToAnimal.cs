using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Animal_Shelter.Migrations
{
    /// <inheritdoc />
    public partial class AddIsFavoriteToAnimal : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "AnimalQuestionnaires",
                type: "nvarchar(3000)",
                maxLength: 3000,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsFavorite",
                table: "AnimalQuestionnaires",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "AnimalQuestionnaires",
                keyColumn: "Id",
                keyValue: 1,
                column: "IsFavorite",
                value: false);

            migrationBuilder.UpdateData(
                table: "AnimalQuestionnaires",
                keyColumn: "Id",
                keyValue: 2,
                column: "IsFavorite",
                value: false);

            migrationBuilder.UpdateData(
                table: "AnimalQuestionnaires",
                keyColumn: "Id",
                keyValue: 3,
                column: "IsFavorite",
                value: false);

            migrationBuilder.UpdateData(
                table: "AnimalQuestionnaires",
                keyColumn: "Id",
                keyValue: 4,
                column: "IsFavorite",
                value: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsFavorite",
                table: "AnimalQuestionnaires");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "AnimalQuestionnaires",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(3000)",
                oldMaxLength: 3000,
                oldNullable: true);
        }
    }
}
