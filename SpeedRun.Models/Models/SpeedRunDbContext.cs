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
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Value>()
                .HasKey(v => v.Id);
        }
    }
}
