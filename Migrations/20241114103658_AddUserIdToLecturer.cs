using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ST10298613_PROG6212_POE.Migrations
{
    /// <inheritdoc />
    public partial class AddUserIdToLecturer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Lecturers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Lecturers");
        }
    }
}
