using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Catalog.Migrations
{
    public partial class Mote : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Nota",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Valoare = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MaterieID = table.Column<int>(type: "int", nullable: true),
                    StudentID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nota", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Nota_Materie_MaterieID",
                        column: x => x.MaterieID,
                        principalTable: "Materie",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Nota_Student_StudentID",
                        column: x => x.StudentID,
                        principalTable: "Student",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Nota_MaterieID",
                table: "Nota",
                column: "MaterieID");

            migrationBuilder.CreateIndex(
                name: "IX_Nota_StudentID",
                table: "Nota",
                column: "StudentID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Nota");
        }
    }
}
