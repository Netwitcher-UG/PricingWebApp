using System.ComponentModel.DataAnnotations;

namespace PricingWebApp.Models
{
    public class FixCosts
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? Title { get; set; }
        [Required]
        public double MonthlyCost { get; set; }
        public double Cost { get; set; }

        public DateTime Date { get; set; } = DateTime.Now;

        public DateTime LastUpdate { get; set; } = DateTime.Now;
    }
}
