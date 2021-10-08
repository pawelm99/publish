using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Biblioteka.Migrations
{
    public partial class Rezerwacja : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Rezerwacja",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KasiazkaId = table.Column<int>(type: "int", nullable: false),
                    UzytkownikId = table.Column<int>(type: "int", nullable: false),
                    dataRezerwacji = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rezerwacja", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Rezerwacja");
        }
    }
}
