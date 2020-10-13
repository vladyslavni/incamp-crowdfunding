using System.Security.Claims;
using Crowdfunding.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Crowdfunding
{
    // services add db context
    public class CrowdfudingContext : IdentityDbContext<User, IdentityRole<long>, long>
    {
        public CrowdfudingContext(DbContextOptions<CrowdfudingContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<User> Users {get; set;}
        public DbSet<Investment> Investments {get; set;}
        public DbSet<Project> Projects {get; set;}
        public DbSet<IdentityUserClaim<long>> AspNetUserClaims {get; set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // modelBuilder.Entity<User>().HasKey(m => m.Id);
            // modelBuilder.Entity<IdentityUser>().ToTable("Users");
            modelBuilder.Entity<User>(u => {
                u.HasKey( k => k.Id);

                u.ToTable("Users");

                u.Property(p=> p.ConcurrencyStamp).IsConcurrencyToken();
                u.Property(p=> p.UserName).HasMaxLength(256);
                u.Property(p=> p.NormalizedUserName).HasMaxLength(256);
                u.Property(p=> p.Email).HasMaxLength(256);
                u.Property(p=> p.NormalizedEmail).HasMaxLength(256);
            });

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=usersdb;Username=postgres;Password=admin");
        }
    }
}