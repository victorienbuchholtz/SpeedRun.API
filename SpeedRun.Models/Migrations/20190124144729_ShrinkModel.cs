using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SpeedRun.Models.Migrations
{
    public partial class ShrinkModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_DeliveryAddress_DeliveryAddressId",
                table: "Order");

            migrationBuilder.DropForeignKey(
                name: "FK_Order_DeliveryStatus_DeliveryStatusId",
                table: "Order");

            migrationBuilder.DropForeignKey(
                name: "FK_Product_Franchise_FranchiseId",
                table: "Product");

            migrationBuilder.DropTable(
                name: "DeliveryAddress");

            migrationBuilder.DropTable(
                name: "DeliveryStatus");

            migrationBuilder.DropTable(
                name: "Franchise");

            migrationBuilder.DropTable(
                name: "OrderedProduct");

            migrationBuilder.DropTable(
                name: "ProductDeveloper");

            migrationBuilder.DropTable(
                name: "ProductGameEngine");

            migrationBuilder.DropTable(
                name: "ProductGameMode");

            migrationBuilder.DropTable(
                name: "ProductGenre");

            migrationBuilder.DropTable(
                name: "ProductPublisher");

            migrationBuilder.DropTable(
                name: "ProductTheme");

            migrationBuilder.DropTable(
                name: "Video");

            migrationBuilder.DropTable(
                name: "GameEngine");

            migrationBuilder.DropTable(
                name: "GameMode");

            migrationBuilder.DropTable(
                name: "Genre");

            migrationBuilder.DropTable(
                name: "Company");

            migrationBuilder.DropTable(
                name: "Theme");

            migrationBuilder.DropIndex(
                name: "IX_Product_FranchiseId",
                table: "Product");

            migrationBuilder.DropIndex(
                name: "IX_Order_DeliveryAddressId",
                table: "Order");

            migrationBuilder.DropIndex(
                name: "IX_Order_DeliveryStatusId",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "FranchiseId",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "DeliveryAddressId",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "DeliveryStatusId",
                table: "Order");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "FranchiseId",
                table: "Product",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "DeliveryAddressId",
                table: "Order",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "DeliveryStatusId",
                table: "Order",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Company",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Url = table.Column<string>(nullable: true),
                    UrlLogo = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Company", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DeliveryAddress",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Address = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    DefaultAddress = table.Column<bool>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    UserId = table.Column<Guid>(nullable: true),
                    ZipCode = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeliveryAddress", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DeliveryAddress_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DeliveryStatus",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeliveryStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Franchise",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Url = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Franchise", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GameEngine",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Url = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameEngine", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GameMode",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Url = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameMode", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Genre",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Url = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genre", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OrderedProduct",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CdKey = table.Column<string>(nullable: true),
                    OrderId = table.Column<Guid>(nullable: true),
                    Price = table.Column<double>(nullable: false),
                    ProductId = table.Column<Guid>(nullable: true),
                    Taxes = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderedProduct", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderedProduct_Order_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Order",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrderedProduct_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Theme",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Url = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Theme", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Video",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ProductId = table.Column<Guid>(nullable: true),
                    VideoUrl = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Video", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Video_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

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

            migrationBuilder.CreateTable(
                name: "ProductGameEngine",
                columns: table => new
                {
                    ProductId = table.Column<Guid>(nullable: false),
                    GameEngineId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductGameEngine", x => new { x.ProductId, x.GameEngineId });
                    table.ForeignKey(
                        name: "FK_ProductGameEngine_GameEngine_GameEngineId",
                        column: x => x.GameEngineId,
                        principalTable: "GameEngine",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductGameEngine_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductGameMode",
                columns: table => new
                {
                    ProductId = table.Column<Guid>(nullable: false),
                    GameModeId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductGameMode", x => new { x.ProductId, x.GameModeId });
                    table.ForeignKey(
                        name: "FK_ProductGameMode_GameMode_GameModeId",
                        column: x => x.GameModeId,
                        principalTable: "GameMode",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductGameMode_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductGenre",
                columns: table => new
                {
                    ProductId = table.Column<Guid>(nullable: false),
                    GenreId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductGenre", x => new { x.ProductId, x.GenreId });
                    table.ForeignKey(
                        name: "FK_ProductGenre_Genre_GenreId",
                        column: x => x.GenreId,
                        principalTable: "Genre",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductGenre_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductTheme",
                columns: table => new
                {
                    ProductId = table.Column<Guid>(nullable: false),
                    ThemeId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductTheme", x => new { x.ProductId, x.ThemeId });
                    table.ForeignKey(
                        name: "FK_ProductTheme_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductTheme_Theme_ThemeId",
                        column: x => x.ThemeId,
                        principalTable: "Theme",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Product_FranchiseId",
                table: "Product",
                column: "FranchiseId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_DeliveryAddressId",
                table: "Order",
                column: "DeliveryAddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_DeliveryStatusId",
                table: "Order",
                column: "DeliveryStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_DeliveryAddress_UserId",
                table: "DeliveryAddress",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderedProduct_OrderId",
                table: "OrderedProduct",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderedProduct_ProductId",
                table: "OrderedProduct",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductDeveloper_CompanyId",
                table: "ProductDeveloper",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductGameEngine_GameEngineId",
                table: "ProductGameEngine",
                column: "GameEngineId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductGameMode_GameModeId",
                table: "ProductGameMode",
                column: "GameModeId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductGenre_GenreId",
                table: "ProductGenre",
                column: "GenreId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductPublisher_CompanyId",
                table: "ProductPublisher",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductTheme_ThemeId",
                table: "ProductTheme",
                column: "ThemeId");

            migrationBuilder.CreateIndex(
                name: "IX_Video_ProductId",
                table: "Video",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_DeliveryAddress_DeliveryAddressId",
                table: "Order",
                column: "DeliveryAddressId",
                principalTable: "DeliveryAddress",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Order_DeliveryStatus_DeliveryStatusId",
                table: "Order",
                column: "DeliveryStatusId",
                principalTable: "DeliveryStatus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Franchise_FranchiseId",
                table: "Product",
                column: "FranchiseId",
                principalTable: "Franchise",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
