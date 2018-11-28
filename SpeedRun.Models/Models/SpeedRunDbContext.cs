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
        //public virtual DbSet<User> User { get; set; }
        //public virtual DbSet<Order> Order { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Value>()
                .HasKey(v => v.Id);

            modelBuilder.Entity<Value>(e => e.Property(m => m.Name).HasMaxLength(127));

            modelBuilder.Entity<Value>()
                .HasIndex(v => v.Name)
                .IsUnique();

            //modelBuilder.Entity<User>()
            //    .HasMany(e => e.DeliveryAddresses)
            //    .WithOne()
            //    .HasForeignKey(e => e.User);

            //modelBuilder.Entity<User>()
            //    .HasMany(e => e.Orders)
            //    .WithOne()
            //    .HasForeignKey(e => e.User);

            //modelBuilder.Entity<Order>()
            //    .HasMany(e => e.OrderedProducts)
            //    .WithOne()
            //    .HasForeignKey(e => e.Order);

            //modelBuilder.Entity<Order>()
            //    .HasOne(e => e.DeliveryAddress)
            //    .WithMany(e => e.Orders);
        }
    }
}
