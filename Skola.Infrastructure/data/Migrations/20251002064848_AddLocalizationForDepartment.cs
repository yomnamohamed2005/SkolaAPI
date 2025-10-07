using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Skola.Infrastructure.data.Migrations
{
    /// <inheritdoc />
    public partial class AddLocalizationForDepartment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Department",
                newName: "NameEn");

            migrationBuilder.AddColumn<string>(
                name: "NameAr",
                table: "Department",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NameAr",
                table: "Department");

            migrationBuilder.RenameColumn(
                name: "NameEn",
                table: "Department",
                newName: "Name");
        }
    }
}
