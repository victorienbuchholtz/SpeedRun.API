using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SpeedRun.Models.Migrations
{
    public partial class CreateDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Picture",
                table: "Product",
                newName: "Summary");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Product",
                newName: "StoryLine");

            migrationBuilder.AddColumn<string>(
                name: "CoverUrl",
                table: "Product",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "FirstReleaseDate",
                table: "Product",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "FranchiseId",
                table: "Product",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PegiRating",
                table: "Product",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RatingCount",
                table: "Product",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TotalRating",
                table: "Product",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Company",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Url = table.Column<string>(nullable: true),
                    UrlLogo = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Company", x => x.Id);
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
                name: "Screenshot",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ScreenshotUrl = table.Column<string>(nullable: true),
                    ProductId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Screenshot", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Screenshot_Product_ProductId",
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
                    VideoUrl = table.Column<string>(nullable: true),
                    ProductId = table.Column<Guid>(nullable: true)
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
                name: "IX_ProductTheme_ThemeId",
                table: "ProductTheme",
                column: "ThemeId");

            migrationBuilder.CreateIndex(
                name: "IX_Screenshot_ProductId",
                table: "Screenshot",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Video_ProductId",
                table: "Video",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Franchise_FranchiseId",
                table: "Product",
                column: "FranchiseId",
                principalTable: "Franchise",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_Franchise_FranchiseId",
                table: "Product");

            migrationBuilder.DropTable(
                name: "Franchise");

            migrationBuilder.DropTable(
                name: "ProductCompany");

            migrationBuilder.DropTable(
                name: "ProductGameEngine");

            migrationBuilder.DropTable(
                name: "ProductGameMode");

            migrationBuilder.DropTable(
                name: "ProductGenre");

            migrationBuilder.DropTable(
                name: "ProductTheme");

            migrationBuilder.DropTable(
                name: "Screenshot");

            migrationBuilder.DropTable(
                name: "Video");

            migrationBuilder.DropTable(
                name: "Company");

            migrationBuilder.DropTable(
                name: "GameEngine");

            migrationBuilder.DropTable(
                name: "GameMode");

            migrationBuilder.DropTable(
                name: "Genre");

            migrationBuilder.DropTable(
                name: "Theme");

            migrationBuilder.DropIndex(
                name: "IX_Product_FranchiseId",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "CoverUrl",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "FirstReleaseDate",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "FranchiseId",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "PegiRating",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "RatingCount",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "TotalRating",
                table: "Product");

            migrationBuilder.RenameColumn(
                name: "Summary",
                table: "Product",
                newName: "Picture");

            migrationBuilder.RenameColumn(
                name: "StoryLine",
                table: "Product",
                newName: "Description");
        }
    }
}
