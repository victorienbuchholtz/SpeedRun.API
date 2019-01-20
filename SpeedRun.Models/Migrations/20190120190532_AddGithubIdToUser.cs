using Microsoft.EntityFrameworkCore.Migrations;

namespace SpeedRun.Models.Migrations
{
    public partial class AddGithubIdToUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "IDGitHub",
                table: "AspNetUsers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IDGitHub",
                table: "AspNetUsers");
        }
    }
}
