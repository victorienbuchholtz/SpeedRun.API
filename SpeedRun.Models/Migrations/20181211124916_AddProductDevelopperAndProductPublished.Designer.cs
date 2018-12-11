﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SpeedRun.Models.Models;

namespace SpeedRun.Models.Migrations
{
    [DbContext(typeof(SpeedRunDbContext))]
    [Migration("20181211124916_AddProductDevelopperAndProductPublished")]
    partial class AddProductDevelopperAndProductPublished
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<Guid>("RoleId");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<Guid>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(127);

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(127);

                    b.Property<string>("ProviderDisplayName");

                    b.Property<Guid>("UserId");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId");

                    b.Property<Guid>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(127);

                    b.Property<string>("Name")
                        .HasMaxLength(127);

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("SpeedRun.Models.Models.Company", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.Property<string>("Url");

                    b.Property<string>("UrlLogo");

                    b.HasKey("Id");

                    b.ToTable("Company");
                });

            modelBuilder.Entity("SpeedRun.Models.Models.DeliveryAddress", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address");

                    b.Property<string>("City");

                    b.Property<bool>("DefaultAddress");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<string>("PhoneNumber");

                    b.Property<Guid?>("UserId");

                    b.Property<string>("ZipCode");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("DeliveryAddress");
                });

            modelBuilder.Entity("SpeedRun.Models.Models.DeliveryStatus", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("DeliveryStatus");
                });

            modelBuilder.Entity("SpeedRun.Models.Models.Franchise", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<string>("Url");

                    b.HasKey("Id");

                    b.ToTable("Franchise");
                });

            modelBuilder.Entity("SpeedRun.Models.Models.GameEngine", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<string>("Url");

                    b.HasKey("Id");

                    b.ToTable("GameEngine");
                });

            modelBuilder.Entity("SpeedRun.Models.Models.GameMode", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<string>("Url");

                    b.HasKey("Id");

                    b.ToTable("GameMode");
                });

            modelBuilder.Entity("SpeedRun.Models.Models.Genre", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<string>("Url");

                    b.HasKey("Id");

                    b.ToTable("Genre");
                });

            modelBuilder.Entity("SpeedRun.Models.Models.Order", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Date");

                    b.Property<Guid?>("DeliveryAddressId");

                    b.Property<Guid?>("DeliveryStatusId");

                    b.Property<Guid?>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("DeliveryAddressId");

                    b.HasIndex("DeliveryStatusId");

                    b.HasIndex("UserId");

                    b.ToTable("Order");
                });

            modelBuilder.Entity("SpeedRun.Models.Models.OrderedProduct", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CdKey");

                    b.Property<Guid?>("OrderId");

                    b.Property<double>("Price");

                    b.Property<Guid?>("ProductId");

                    b.Property<double>("Taxes");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.HasIndex("ProductId");

                    b.ToTable("OrderedProduct");
                });

            modelBuilder.Entity("SpeedRun.Models.Models.Product", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Active");

                    b.Property<string>("CoverUrl");

                    b.Property<int>("DeliveryTime");

                    b.Property<DateTime>("FirstReleaseDate");

                    b.Property<Guid?>("FranchiseId");

                    b.Property<int>("Inventory");

                    b.Property<string>("Name");

                    b.Property<int>("PegiRating");

                    b.Property<double>("Price");

                    b.Property<int>("RatingCount");

                    b.Property<string>("StoryLine");

                    b.Property<string>("Summary");

                    b.Property<double>("Taxes");

                    b.Property<int>("TotalRating");

                    b.HasKey("Id");

                    b.HasIndex("FranchiseId");

                    b.ToTable("Product");
                });

            modelBuilder.Entity("SpeedRun.Models.Models.ProductDevelopper", b =>
                {
                    b.Property<Guid>("ProductId");

                    b.Property<Guid>("CompanyId");

                    b.HasKey("ProductId", "CompanyId");

                    b.HasIndex("CompanyId");

                    b.ToTable("ProductDevelopper");
                });

            modelBuilder.Entity("SpeedRun.Models.Models.ProductGameEngine", b =>
                {
                    b.Property<Guid>("ProductId");

                    b.Property<Guid>("GameEngineId");

                    b.HasKey("ProductId", "GameEngineId");

                    b.HasIndex("GameEngineId");

                    b.ToTable("ProductGameEngine");
                });

            modelBuilder.Entity("SpeedRun.Models.Models.ProductGameMode", b =>
                {
                    b.Property<Guid>("ProductId");

                    b.Property<Guid>("GameModeId");

                    b.HasKey("ProductId", "GameModeId");

                    b.HasIndex("GameModeId");

                    b.ToTable("ProductGameMode");
                });

            modelBuilder.Entity("SpeedRun.Models.Models.ProductGenre", b =>
                {
                    b.Property<Guid>("ProductId");

                    b.Property<Guid>("GenreId");

                    b.HasKey("ProductId", "GenreId");

                    b.HasIndex("GenreId");

                    b.ToTable("ProductGenre");
                });

            modelBuilder.Entity("SpeedRun.Models.Models.ProductPublisher", b =>
                {
                    b.Property<Guid>("ProductId");

                    b.Property<Guid>("CompanyId");

                    b.HasKey("ProductId", "CompanyId");

                    b.HasIndex("CompanyId");

                    b.ToTable("ProductPublisher");
                });

            modelBuilder.Entity("SpeedRun.Models.Models.ProductTheme", b =>
                {
                    b.Property<Guid>("ProductId");

                    b.Property<Guid>("ThemeId");

                    b.HasKey("ProductId", "ThemeId");

                    b.HasIndex("ThemeId");

                    b.ToTable("ProductTheme");
                });

            modelBuilder.Entity("SpeedRun.Models.Models.Role", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Description");

                    b.Property<string>("Name")
                        .HasMaxLength(127);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(127);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("SpeedRun.Models.Models.Screenshot", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("ProductId");

                    b.Property<string>("ScreenshotUrl");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.ToTable("Screenshot");
                });

            modelBuilder.Entity("SpeedRun.Models.Models.Theme", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<string>("Url");

                    b.HasKey("Id");

                    b.ToTable("Theme");
                });

            modelBuilder.Entity("SpeedRun.Models.Models.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("Address");

                    b.Property<string>("AvatarUrl");

                    b.Property<string>("City");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(127);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(127);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(127);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(127);

                    b.Property<string>("ZipCode");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("SpeedRun.Models.Models.Video", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("ProductId");

                    b.Property<string>("VideoUrl");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.ToTable("Video");
                });

            modelBuilder.Entity("SpeedRun.Models.Value", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .HasMaxLength(127);

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Values");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.HasOne("SpeedRun.Models.Models.Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.HasOne("SpeedRun.Models.Models.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.HasOne("SpeedRun.Models.Models.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.HasOne("SpeedRun.Models.Models.Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SpeedRun.Models.Models.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.HasOne("SpeedRun.Models.Models.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SpeedRun.Models.Models.DeliveryAddress", b =>
                {
                    b.HasOne("SpeedRun.Models.Models.User", "User")
                        .WithMany("DeliveryAddresses")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("SpeedRun.Models.Models.Order", b =>
                {
                    b.HasOne("SpeedRun.Models.Models.DeliveryAddress", "DeliveryAddress")
                        .WithMany("Orders")
                        .HasForeignKey("DeliveryAddressId");

                    b.HasOne("SpeedRun.Models.Models.DeliveryStatus", "DeliveryStatus")
                        .WithMany("Orders")
                        .HasForeignKey("DeliveryStatusId");

                    b.HasOne("SpeedRun.Models.Models.User", "User")
                        .WithMany("Orders")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("SpeedRun.Models.Models.OrderedProduct", b =>
                {
                    b.HasOne("SpeedRun.Models.Models.Order", "Order")
                        .WithMany("OrderedProducts")
                        .HasForeignKey("OrderId");

                    b.HasOne("SpeedRun.Models.Models.Product", "Product")
                        .WithMany("OrderedProducts")
                        .HasForeignKey("ProductId");
                });

            modelBuilder.Entity("SpeedRun.Models.Models.Product", b =>
                {
                    b.HasOne("SpeedRun.Models.Models.Franchise", "Franchise")
                        .WithMany("Products")
                        .HasForeignKey("FranchiseId");
                });

            modelBuilder.Entity("SpeedRun.Models.Models.ProductDevelopper", b =>
                {
                    b.HasOne("SpeedRun.Models.Models.Company", "Company")
                        .WithMany("Developped")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SpeedRun.Models.Models.Product", "Product")
                        .WithMany("Developpers")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SpeedRun.Models.Models.ProductGameEngine", b =>
                {
                    b.HasOne("SpeedRun.Models.Models.GameEngine", "GameEngine")
                        .WithMany("Products")
                        .HasForeignKey("GameEngineId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SpeedRun.Models.Models.Product", "Product")
                        .WithMany("GameEngines")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SpeedRun.Models.Models.ProductGameMode", b =>
                {
                    b.HasOne("SpeedRun.Models.Models.GameMode", "GameMode")
                        .WithMany("Products")
                        .HasForeignKey("GameModeId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SpeedRun.Models.Models.Product", "Product")
                        .WithMany("GameModes")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SpeedRun.Models.Models.ProductGenre", b =>
                {
                    b.HasOne("SpeedRun.Models.Models.Genre", "Genre")
                        .WithMany("Products")
                        .HasForeignKey("GenreId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SpeedRun.Models.Models.Product", "Product")
                        .WithMany("Genres")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SpeedRun.Models.Models.ProductPublisher", b =>
                {
                    b.HasOne("SpeedRun.Models.Models.Company", "Company")
                        .WithMany("Published")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SpeedRun.Models.Models.Product", "Product")
                        .WithMany("Publishers")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SpeedRun.Models.Models.ProductTheme", b =>
                {
                    b.HasOne("SpeedRun.Models.Models.Product", "Product")
                        .WithMany("Themes")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SpeedRun.Models.Models.Theme", "Theme")
                        .WithMany("Products")
                        .HasForeignKey("ThemeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SpeedRun.Models.Models.Screenshot", b =>
                {
                    b.HasOne("SpeedRun.Models.Models.Product", "Product")
                        .WithMany("Screenshots")
                        .HasForeignKey("ProductId");
                });

            modelBuilder.Entity("SpeedRun.Models.Models.Video", b =>
                {
                    b.HasOne("SpeedRun.Models.Models.Product", "Product")
                        .WithMany("Videos")
                        .HasForeignKey("ProductId");
                });
#pragma warning restore 612, 618
        }
    }
}
