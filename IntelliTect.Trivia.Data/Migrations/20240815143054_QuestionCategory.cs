using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IntelliTect.Trivia.Data.Migrations
{
    /// <inheritdoc />
    public partial class QuestionCategory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Category",
                table: "Questions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.Sql("UPDATE Questions SET Category = 3");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Category",
                table: "Questions");
        }
    }
}
