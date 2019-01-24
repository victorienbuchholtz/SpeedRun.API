using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SpeedRun.Models.Models.Product;

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
        public virtual DbSet<Product.Product> Product { get; set; }
        public virtual DbSet<Theme> Theme { get; set; }
        public virtual DbSet<InventoryOperation> InventoryOperation { get; set; }
        public virtual DbSet<Basket> Basket { get; set; }

        private const int MAX_KEY_LENGTH = 127;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Value>()
                .HasKey(v => v.Id);

            modelBuilder.Entity<User>()
                .HasKey(u => u.Id);

            modelBuilder.Entity<Order>()
                .HasKey(o => o.Id);

            modelBuilder.Entity<Product.Product>()
                .HasKey(p => p.Id);

            modelBuilder.Entity<Theme>()
                .HasKey(t => t.Id);

            modelBuilder.Entity<InventoryOperation>()
                .HasKey(t => t.Id);

            modelBuilder.Entity<Basket>()
                .HasKey(t => t.Id);

            modelBuilder.Entity<Value>(e => e.Property(m => m.Name).HasMaxLength(127));
            
            modelBuilder.Entity<Value>()
                .HasIndex(v => v.Name)
                .IsUnique();

            modelBuilder.Entity<User>()
                .HasMany(e => e.DeliveryAddresses)
                .WithOne(e => e.User);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Orders)
                .WithOne(e => e.User);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Baskets)
                .WithOne(e => e.User);

            modelBuilder.Entity<Order>()
                .HasMany(e => e.OrderedProducts)
                .WithOne(e => e.Order);

            modelBuilder.Entity<Order>()
                .HasOne(e => e.DeliveryAddress)
                .WithMany(e => e.Orders);

            modelBuilder.Entity<Order>()
                .HasOne(e => e.DeliveryStatus)
                .WithMany(e => e.Orders);

            modelBuilder.Entity<Product.Product>()
                .HasMany(e => e.OrderedProducts)
                .WithOne(e => e.Product);

            modelBuilder.Entity<Product.Product>()
                .HasOne(e => e.Franchise)
                .WithMany(e => e.Products);

            modelBuilder.Entity<Product.Product>()
                .HasMany(e => e.Screenshots)
                .WithOne(e => e.Product);

            modelBuilder.Entity<Product.Product>()
                .HasMany(e => e.Videos)
                .WithOne(e => e.Product);

            modelBuilder.Entity<Product.Product>()
                .HasMany(e => e.OrderedProducts)
                .WithOne(e => e.Product);

            modelBuilder.Entity<Product.Product>()
                .HasMany(e => e.Baskets)
                .WithOne(e => e.Product);

            // ICI REPOSE : Les MANY TO MANY
            modelBuilder.Entity<ProductTheme>()
                .HasKey(t => new {t.ProductId, t.ThemeId});

            modelBuilder.Entity<ProductTheme>()
                .HasOne(bc => bc.Product)
                .WithMany(b => b.Themes)
                .HasForeignKey(bc => bc.ProductId);

            modelBuilder.Entity<ProductTheme>()
                .HasOne(bc => bc.Theme)
                .WithMany(c => c.Products)
                .HasForeignKey(bc => bc.ThemeId);

            modelBuilder.Entity<ProductGenre>()
                .HasKey(t => new { t.ProductId, t.GenreId });

            modelBuilder.Entity<ProductGenre>()
                .HasOne(bc => bc.Product)
                .WithMany(b => b.Genres)
                .HasForeignKey(bc => bc.ProductId);

            modelBuilder.Entity<ProductGenre>()
                .HasOne(bc => bc.Genre)
                .WithMany(c => c.Products)
                .HasForeignKey(bc => bc.GenreId);

            modelBuilder.Entity<ProductGameMode>()
                .HasKey(t => new { t.ProductId, t.GameModeId });

            modelBuilder.Entity<ProductGameMode>()
                .HasOne(bc => bc.Product)
                .WithMany(b => b.GameModes)
                .HasForeignKey(bc => bc.ProductId);

            modelBuilder.Entity<ProductGameMode>()
                .HasOne(bc => bc.GameMode)
                .WithMany(c => c.Products)
                .HasForeignKey(bc => bc.GameModeId);

            modelBuilder.Entity<ProductGameEngine>()
                .HasKey(t => new { t.ProductId, t.GameEngineId });

            modelBuilder.Entity<ProductGameEngine>()
                .HasOne(bc => bc.Product)
                .WithMany(b => b.GameEngines)
                .HasForeignKey(bc => bc.ProductId);

            modelBuilder.Entity<ProductGameEngine>()
                .HasOne(bc => bc.GameEngine)
                .WithMany(c => c.Products)
                .HasForeignKey(bc => bc.GameEngineId);

            modelBuilder.Entity<ProductDeveloper>()
                .HasKey(t => new { t.ProductId, t.CompanyId });

            modelBuilder.Entity<ProductDeveloper>()
                .HasOne(bc => bc.Product)
                .WithMany(b => b.Developers)
                .HasForeignKey(bc => bc.ProductId);

            modelBuilder.Entity<ProductDeveloper>()
                .HasOne(bc => bc.Company)
                .WithMany(c => c.Developed)
                .HasForeignKey(bc => bc.CompanyId);

            modelBuilder.Entity<ProductPublisher>()
                .HasKey(t => new { t.ProductId, t.CompanyId });

            modelBuilder.Entity<ProductPublisher>()
                .HasOne(bc => bc.Product)
                .WithMany(b => b.Publishers)
                .HasForeignKey(bc => bc.ProductId);

            modelBuilder.Entity<ProductPublisher>()
                .HasOne(bc => bc.Company)
                .WithMany(c => c.Published)
                .HasForeignKey(bc => bc.CompanyId);

            // ICI REPOSE : Les longueurs pas cool
            modelBuilder.Entity<User>(e =>
            {
                e.Property(m => m.UserName).HasMaxLength(MAX_KEY_LENGTH);
                e.Property(m => m.NormalizedUserName).HasMaxLength(MAX_KEY_LENGTH);
                e.Property(m => m.Email).HasMaxLength(MAX_KEY_LENGTH);
                e.Property(m => m.NormalizedEmail).HasMaxLength(MAX_KEY_LENGTH);
            });

            modelBuilder.Entity<Role>(e =>
            {
                e.Property(m => m.Name).HasMaxLength(MAX_KEY_LENGTH);
                e.Property(m => m.NormalizedName).HasMaxLength(MAX_KEY_LENGTH);
            });

            modelBuilder.Entity<IdentityUserLogin<Guid>>(entity =>
            {
                entity.Property(m => m.LoginProvider).HasMaxLength(MAX_KEY_LENGTH);
                entity.Property(m => m.ProviderKey).HasMaxLength(MAX_KEY_LENGTH);
            });

            modelBuilder.Entity<IdentityUserToken<Guid>>(entity =>
            {
                entity.Property(m => m.LoginProvider).HasMaxLength(MAX_KEY_LENGTH);
                entity.Property(m => m.Name).HasMaxLength(MAX_KEY_LENGTH);

            });
        }
    }
}
