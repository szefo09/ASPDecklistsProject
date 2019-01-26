using Microsoft.EntityFrameworkCore.Migrations;

namespace DecklistProjectASP.Migrations
{
    public partial class removePicPath : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CardArtPath",
                table: "Card");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CardArtPath",
                table: "Card",
                nullable: true);
        }
    }
}
