using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Crintea_Miruna_Proiect.Migrations
{
    public partial class InitialCreation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Coach",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Experience = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Coach", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Element",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BaseValue = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Element", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "SkatingClub",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OpeningYear = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SkatingClub", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Skater",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    Height = table.Column<int>(type: "int", nullable: false),
                    EmailAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SkatingClubID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skater", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Skater_SkatingClub_SkatingClubID",
                        column: x => x.SkatingClubID,
                        principalTable: "SkatingClub",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "ProgramElement",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SkaterID = table.Column<int>(type: "int", nullable: false),
                    ElementID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProgramElement", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ProgramElement_Element_ElementID",
                        column: x => x.ElementID,
                        principalTable: "Element",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_ProgramElement_Skater_SkaterID",
                        column: x => x.SkaterID,
                        principalTable: "Skater",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SkaterCoach",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SkaterID = table.Column<int>(type: "int", nullable: true),
                    CoachID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SkaterCoach", x => x.ID);
                    table.ForeignKey(
                        name: "FK_SkaterCoach_Coach_CoachID",
                        column: x => x.CoachID,
                        principalTable: "Coach",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_SkaterCoach_Skater_SkaterID",
                        column: x => x.SkaterID,
                        principalTable: "Skater",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProgramElement_ElementID",
                table: "ProgramElement",
                column: "ElementID");

            migrationBuilder.CreateIndex(
                name: "IX_ProgramElement_SkaterID",
                table: "ProgramElement",
                column: "SkaterID");

            migrationBuilder.CreateIndex(
                name: "IX_Skater_SkatingClubID",
                table: "Skater",
                column: "SkatingClubID");

            migrationBuilder.CreateIndex(
                name: "IX_SkaterCoach_CoachID",
                table: "SkaterCoach",
                column: "CoachID");

            migrationBuilder.CreateIndex(
                name: "IX_SkaterCoach_SkaterID",
                table: "SkaterCoach",
                column: "SkaterID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProgramElement");

            migrationBuilder.DropTable(
                name: "SkaterCoach");

            migrationBuilder.DropTable(
                name: "Element");

            migrationBuilder.DropTable(
                name: "Coach");

            migrationBuilder.DropTable(
                name: "Skater");

            migrationBuilder.DropTable(
                name: "SkatingClub");
        }
    }
}
