using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace SpeedRun.Models.Models
{
    public class SpeedRunDbContext : IdentityDbContext<User,Role,Guid>
    {
        public SpeedRunDbContext(DbContextOptions<SpeedRunDbContext> options)
            : base(options)
        { }

        public virtual DbSet<Value> Values { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<Order> Order { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<Theme> Theme { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Value>()
                .HasKey(v => v.Id);

            modelBuilder.Entity<Value>(e => e.Property(m => m.Name).HasMaxLength(127));

            modelBuilder.Entity<Value>()
                .HasIndex(v => v.Name)
                .IsUnique();

            modelBuilder.Entity<User>()
                .HasMany(e => e.DeliveryAddresses)
                .WithOne()
                .HasForeignKey(e => e.User);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Orders)
                .WithOne()
                .HasForeignKey(e => e.User);

            modelBuilder.Entity<Order>()
                .HasMany(e => e.OrderedProducts)
                .WithOne()
                .HasForeignKey(e => e.Order);

            modelBuilder.Entity<Order>()
                .HasOne(e => e.DeliveryAddress)
                .WithMany(e => e.Orders);

            modelBuilder.Entity<Order>()
                .HasOne(e => e.DeliveryStatus)
                .WithMany(e => e.Orders);

            modelBuilder.Entity<Order>()
                .HasOne(e => e.User)
                .WithMany(e => e.Orders);

            modelBuilder.Entity<Product>()
                .HasMany(e => e.OrderedProducts)
                .WithOne()
                .HasForeignKey(e => e.Product);

            modelBuilder.Entity<Product>()
                .HasOne(e => e.Franchise)
                .WithMany(e => e.Products);

            // ICI REPOSE : Les MANY TO MANY
            modelBuilder.Entity<ProductTheme>()
                .HasKey(t => new {t.ProductId, t.ThemeId});

            modelBuilder.Entity<ProductGenre>()
                .HasKey(t => new { t.ProductId, t.GenreId });

            modelBuilder.Entity<ProductGameMode>()
                .HasKey(t => new { t.ProductId, t.GameModeId });

            modelBuilder.Entity<ProductGameEngine>()
                .HasKey(t => new { t.ProductId, t.GameEngineId });

            modelBuilder.Entity<ProductCompany>()
                .HasKey(t => new { t.ProductId, t.CompanyId });
        }
    }
}
