using Microsoft.EntityFrameworkCore.Migrations;

namespace MusicRecommendations.Migrations
{
    public partial class AddPriceField : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "MusicModel",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "MusicModel");
        }
    }
}
