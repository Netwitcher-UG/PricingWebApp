using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PricingWebApp.Models;

namespace PricingWebApp.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        
        public DbSet<FixCosts> FixCosts { get; set; }
        public DbSet<Services> Services { get; set; }
        public DbSet<Projects> Projects { get; set; }
        public DbSet<Employees> Employees { get; set; }
        public DbSet<PriceCalculation> PriceCalculation { get; set; }
        public DbSet<PricePackages> PricePackages { get; set; }
    }
}
