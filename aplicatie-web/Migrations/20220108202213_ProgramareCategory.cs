using Microsoft.EntityFrameworkCore.Migrations;

namespace aplicatie_web.Migrations
{
    public partial class ProgramareCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SalonID",
                table: "Programare",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SalonID1",
                table: "Programare",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Salon",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumarSalon = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Salon", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ProgramareCategory",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProgramareID = table.Column<int>(type: "int", nullable: false),
                    CategoryID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProgramareCategory", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ProgramareCategory_Category_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "Category",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProgramareCategory_Programare_ProgramareID",
                        column: x => x.ProgramareID,
                        principalTable: "Programare",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Programare_SalonID1",
                table: "Programare",
                column: "SalonID1");

            migrationBuilder.CreateIndex(
                name: "IX_ProgramareCategory_CategoryID",
                table: "ProgramareCategory",
                column: "CategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_ProgramareCategory_ProgramareID",
                table: "ProgramareCategory",
                column: "ProgramareID");

            migrationBuilder.AddForeignKey(
                name: "FK_Programare_Salon_SalonID1",
                table: "Programare",
                column: "SalonID1",
                principalTable: "Salon",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Programare_Salon_SalonID1",
                table: "Programare");

            migrationBuilder.DropTable(
                name: "ProgramareCategory");

            migrationBuilder.DropTable(
                name: "Salon");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropIndex(
                name: "IX_Programare_SalonID1",
                table: "Programare");

            migrationBuilder.DropColumn(
                name: "SalonID",
                table: "Programare");

            migrationBuilder.DropColumn(
                name: "SalonID1",
                table: "Programare");
        }
    }
}
