using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SpeedRun.Models.Migrations
{
    public partial class RenameDevelopperToDeveloper : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductDevelopper");

            migrationBuilder.CreateTable(
                name: "ProductDeveloper",
                columns: table => new
                {
                    ProductId = table.Column<Guid>(nullable: false),
                    CompanyId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductDeveloper", x => new { x.ProductId, x.CompanyId });
                    table.ForeignKey(
                        name: "FK_ProductDeveloper_Company_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductDeveloper_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductDeveloper_CompanyId",
                table: "ProductDeveloper",
                column: "CompanyId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductDeveloper");

            migrationBuilder.CreateTable(
                name: "ProductDevelopper",
                columns: table => new
                {
                    ProductId = table.Column<Guid>(nullable: false),
                    CompanyId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductDevelopper", x => new { x.ProductId, x.CompanyId });
                    table.ForeignKey(
                        name: "FK_ProductDevelopper_Company_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductDevelopper_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductDevelopper_CompanyId",
                table: "ProductDevelopper",
                column: "CompanyId");
        }
    }
}
