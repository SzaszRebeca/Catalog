using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Catalog.Migrations
{
    public partial class ListaProfesoriMaterii : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Materie",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumeMaterie = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Materie", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Profesor",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumeProfesor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Facultate = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profesor", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Student",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumeStudent = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Facultate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    An = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MaterieID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Student", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Student_Materie_MaterieID",
                        column: x => x.MaterieID,
                        principalTable: "Materie",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "ListaProfesoriMaterie",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaterieID = table.Column<int>(type: "int", nullable: true),
                    ProfesorID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ListaProfesoriMaterie", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ListaProfesoriMaterie_Materie_MaterieID",
                        column: x => x.MaterieID,
                        principalTable: "Materie",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_ListaProfesoriMaterie_Profesor_ProfesorID",
                        column: x => x.ProfesorID,
                        principalTable: "Profesor",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ListaProfesoriMaterie_MaterieID",
                table: "ListaProfesoriMaterie",
                column: "MaterieID");

            migrationBuilder.CreateIndex(
                name: "IX_ListaProfesoriMaterie_ProfesorID",
                table: "ListaProfesoriMaterie",
                column: "ProfesorID");

            migrationBuilder.CreateIndex(
                name: "IX_Student_MaterieID",
                table: "Student",
                column: "MaterieID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ListaProfesoriMaterie");

            migrationBuilder.DropTable(
                name: "Student");

            migrationBuilder.DropTable(
                name: "Profesor");

            migrationBuilder.DropTable(
                name: "Materie");
        }
    }
}
