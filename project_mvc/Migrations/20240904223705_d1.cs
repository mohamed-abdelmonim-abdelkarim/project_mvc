using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace task1.Migrations
{
    /// <inheritdoc />
    public partial class d1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "students",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    dept_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_students", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "departments",
                columns: table => new
                {
                    dept_Id = table.Column<int>(type: "int", nullable: false),
                    dept_Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StudentsId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_departments", x => x.dept_Id);
                    table.ForeignKey(
                        name: "FK_departments_students_StudentsId",
                        column: x => x.StudentsId,
                        principalTable: "students",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_departments_StudentsId",
                table: "departments",
                column: "StudentsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "departments");

            migrationBuilder.DropTable(
                name: "students");
        }
    }
}
