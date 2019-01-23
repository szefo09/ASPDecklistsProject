using Microsoft.EntityFrameworkCore.Migrations;

namespace DecklistProjectASP.Migrations
{
    public partial class UpdateDeckName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "NameOfDeck",
                table: "Decklists",
                newName: "DeckName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DeckName",
                table: "Decklists",
                newName: "NameOfDeck");
        }
    }
}
