using System.ComponentModel.DataAnnotations;

namespace PricingWebApp.Models
{
    public class PricePackages
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public PriceCalculation? PriceCalculation { get; set; }
        [Required]
        public int ProfitRatio { get; set; }
        public int DiscountPercent { get; set; }
        [Required]
        public double DefaultPack { get; set; }
        [Required]
        public double SecondPack { get; set; }
        [Required]
        public double ThirdPack { get; set; }
    }
}
