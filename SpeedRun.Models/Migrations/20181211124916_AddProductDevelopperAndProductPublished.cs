using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SpeedRun.Models.Migrations
{
    public partial class AddProductDevelopperAndProductPublished : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductCompany");

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

            migrationBuilder.CreateTable(
                name: "ProductPublisher",
                columns: table => new
                {
                    ProductId = table.Column<Guid>(nullable: false),
                    CompanyId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductPublisher", x => new { x.ProductId, x.CompanyId });
                    table.ForeignKey(
                        name: "FK_ProductPublisher_Company_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductPublisher_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductDevelopper_CompanyId",
                table: "ProductDevelopper",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductPublisher_CompanyId",
                table: "ProductPublisher",
                column: "CompanyId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductDevelopper");

            migrationBuilder.DropTable(
                name: "ProductPublisher");

            migrationBuilder.CreateTable(
                name: "ProductCompany",
                columns: table => new
                {
                    ProductId = table.Column<Guid>(nullable: false),
                    CompanyId = table.Column<Guid>(nullable: false),
                    CompanyId1 = table.Column<Guid>(nullable: true),
                    ProductId1 = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCompany", x => new { x.ProductId, x.CompanyId });
                    table.ForeignKey(
                        name: "FK_ProductCompany_Company_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductCompany_Company_CompanyId1",
                        column: x => x.CompanyId1,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductCompany_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductCompany_Product_ProductId1",
                        column: x => x.ProductId1,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductCompany_CompanyId",
                table: "ProductCompany",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductCompany_CompanyId1",
                table: "ProductCompany",
                column: "CompanyId1");

            migrationBuilder.CreateIndex(
                name: "IX_ProductCompany_ProductId1",
                table: "ProductCompany",
                column: "ProductId1");
        }
    }
}
