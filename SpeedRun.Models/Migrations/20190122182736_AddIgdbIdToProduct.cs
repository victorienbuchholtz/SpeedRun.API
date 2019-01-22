using Microsoft.EntityFrameworkCore.Migrations;

namespace SpeedRun.Models.Migrations
{
    public partial class AddIgdbIdToProduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Inventory",
                table: "Product",
                newName: "IgdbId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IgdbId",
                table: "Product",
                newName: "Inventory");
        }
    }
}
