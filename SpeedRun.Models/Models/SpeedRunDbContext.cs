using System;
using Microsoft.AspNetCore.Identity;
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
        public virtual DbSet<InventoryOperation> InventoryOperation { get; set; }
        public virtual DbSet<Basket> Basket { get; set; }

        private const int MAX_KEY_LENGTH = 127;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Value>().HasKey(v => v.Id);
            modelBuilder.Entity<User>().HasKey(u => u.Id);
            modelBuilder.Entity<Order>().HasKey(o => o.Id);
            modelBuilder.Entity<Product>().HasKey(p => p.Id);
            modelBuilder.Entity<InventoryOperation>().HasKey(t => t.Id);
            modelBuilder.Entity<Basket>().HasKey(t => t.Id);
            modelBuilder.Entity<Value>(e => e.Property(m => m.Name).HasMaxLength(127));
            
            modelBuilder.Entity<Value>()
                .HasIndex(v => v.Name)
                .IsUnique();

            modelBuilder.Entity<User>()
                .HasMany(e => e.Orders)
                .WithOne(e => e.User);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Baskets)
                .WithOne(e => e.User);

            modelBuilder.Entity<Product>()
                .HasMany(e => e.Screenshots)
                .WithOne(e => e.Product);

            modelBuilder.Entity<Product>()
                .HasMany(e => e.Baskets)
                .WithOne(e => e.Product);

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
