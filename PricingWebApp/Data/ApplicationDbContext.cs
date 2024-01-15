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
        public DbSet<Servises> Servises { get; set; }
        public DbSet<Projects> Projects { get; set; }
        public DbSet<Employes> Employes { get; set; }
        public DbSet<PraiceCalculation> PraiceCalculation { get; set; }
        public DbSet<Price_Packages> Price_Packages { get; set; }
        


    }
}
