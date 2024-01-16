using System.ComponentModel.DataAnnotations;

namespace PricingWebApp.Models
{
    public class FixCosts
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string? Title { get; set; }
        [Required]
        public double MonthlyCost { get; set; }
     

        public DateTime LastUpdate { get; set; } = DateTime.Now;
    }
}
