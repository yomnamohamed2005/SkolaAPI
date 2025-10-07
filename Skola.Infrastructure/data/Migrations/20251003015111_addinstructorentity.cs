using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Skola.Infrastructure.data.Migrations
{
    /// <inheritdoc />
    public partial class addinstructorentity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_StudentSubject",
                table: "StudentSubject");

            migrationBuilder.DropIndex(
                name: "IX_StudentSubject_SubjectId",
                table: "StudentSubject");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DepartmentSubject",
                table: "DepartmentSubject");

            migrationBuilder.DropIndex(
                name: "IX_DepartmentSubject_DepartmentId",
                table: "DepartmentSubject");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "StudentSubject");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "DepartmentSubject");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Subject",
                newName: "NameEn");

            migrationBuilder.AddColumn<string>(
                name: "NameAr",
                table: "Subject",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "Grade",
                table: "StudentSubject",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AlterColumn<string>(
                name: "NameAr",
                table: "Student",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "DepartmentId1",
                table: "Student",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NameAr",
                table: "Department",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "DepartmentManagerId",
                table: "Department",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_StudentSubject",
                table: "StudentSubject",
                columns: new[] { "SubjectId", "StudentId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_DepartmentSubject",
                table: "DepartmentSubject",
                columns: new[] { "DepartmentId", "SubjectId" });

            migrationBuilder.CreateTable(
                name: "Instructor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameAr = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    NameEn = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Postion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Salary = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DepartmentId = table.Column<int>(type: "int", nullable: false),
                    SupervisorId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Instructor", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Instructor_Department_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Department",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Instructor_Instructor_SupervisorId",
                        column: x => x.SupervisorId,
                        principalTable: "Instructor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "subjectInstructor",
                columns: table => new
                {
                    SubjectId = table.Column<int>(type: "int", nullable: false),
                    InstructorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_subjectInstructor", x => new { x.SubjectId, x.InstructorId });
                    table.ForeignKey(
                        name: "FK_subjectInstructor_Instructor_InstructorId",
                        column: x => x.InstructorId,
                        principalTable: "Instructor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_subjectInstructor_Subject_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "Subject",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Student_DepartmentId1",
                table: "Student",
                column: "DepartmentId1");

            migrationBuilder.CreateIndex(
                name: "IX_Department_DepartmentManagerId",
                table: "Department",
                column: "DepartmentManagerId",
                unique: true,
                filter: "[DepartmentManagerId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Instructor_DepartmentId",
                table: "Instructor",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Instructor_SupervisorId",
                table: "Instructor",
                column: "SupervisorId");

            migrationBuilder.CreateIndex(
                name: "IX_subjectInstructor_InstructorId",
                table: "subjectInstructor",
                column: "InstructorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Department_Instructor_DepartmentManagerId",
                table: "Department",
                column: "DepartmentManagerId",
                principalTable: "Instructor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Student_Department_DepartmentId1",
                table: "Student",
                column: "DepartmentId1",
                principalTable: "Department",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Department_Instructor_DepartmentManagerId",
                table: "Department");

            migrationBuilder.DropForeignKey(
                name: "FK_Student_Department_DepartmentId1",
                table: "Student");

            migrationBuilder.DropTable(
                name: "subjectInstructor");

            migrationBuilder.DropTable(
                name: "Instructor");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StudentSubject",
                table: "StudentSubject");

            migrationBuilder.DropIndex(
                name: "IX_Student_DepartmentId1",
                table: "Student");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DepartmentSubject",
                table: "DepartmentSubject");

            migrationBuilder.DropIndex(
                name: "IX_Department_DepartmentManagerId",
                table: "Department");

            migrationBuilder.DropColumn(
                name: "NameAr",
                table: "Subject");

            migrationBuilder.DropColumn(
                name: "Grade",
                table: "StudentSubject");

            migrationBuilder.DropColumn(
                name: "DepartmentId1",
                table: "Student");

            migrationBuilder.DropColumn(
                name: "DepartmentManagerId",
                table: "Department");

            migrationBuilder.RenameColumn(
                name: "NameEn",
                table: "Subject",
                newName: "Name");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "StudentSubject",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<string>(
                name: "NameAr",
                table: "Student",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "DepartmentSubject",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<string>(
                name: "NameAr",
                table: "Department",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AddPrimaryKey(
                name: "PK_StudentSubject",
                table: "StudentSubject",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DepartmentSubject",
                table: "DepartmentSubject",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_StudentSubject_SubjectId",
                table: "StudentSubject",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_DepartmentSubject_DepartmentId",
                table: "DepartmentSubject",
                column: "DepartmentId");
        }
    }
}
