using Microsoft.EntityFrameworkCore.Migrations;

namespace DecklistProjectASP.Migrations
{
    public partial class updateCards2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CardIdentifier",
                table: "Card",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CardIdentifier",
                table: "Card");
        }
    }
}
