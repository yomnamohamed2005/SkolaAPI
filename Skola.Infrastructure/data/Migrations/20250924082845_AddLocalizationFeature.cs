using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Skola.Infrastructure.data.Migrations
{
    /// <inheritdoc />
    public partial class AddLocalizationFeature : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Student",
                newName: "NameEn");

            migrationBuilder.AddColumn<string>(
                name: "NameAr",
                table: "Student",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NameAr",
                table: "Student");

            migrationBuilder.RenameColumn(
                name: "NameEn",
                table: "Student",
                newName: "Name");
        }
    }
}
