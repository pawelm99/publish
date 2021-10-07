using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Biblioteka.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Ksiazka",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nazwa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    autor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    dataWydania = table.Column<DateTime>(type: "datetime2", nullable: false),
                    opis = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ksiazka", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ksiazka");
        }
    }
}
