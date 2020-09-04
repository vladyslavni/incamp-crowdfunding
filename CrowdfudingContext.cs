using Crowdfunding.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace Crowdfunding
{
    // services add db context
    public class CrowdfudingContext : DbContext
    {
        public DbSet<User> Users {get; set;}
        public DbSet<Team> Teams {get; set;}
        public DbSet<Investment> Investments {get; set;}
        public DbSet<Project> Projects {get; set;}
        public DbSet<TransactionResult> Transactions {get; set;}
        public DbSet<IdentityUserClaim<long>> IdentityUserClaims {get; set;}
        
        public CrowdfudingContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=usersdb;Username=postgres;Password=admin");
        }
    }
}