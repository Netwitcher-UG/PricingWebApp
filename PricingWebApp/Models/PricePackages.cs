namespace PricingWebApp.Models
{
    public class PricePackages
    {
        public int Id { get; set; }
        public PriceCalculation? PriceCalculationId { get; set; }
        public int ProfitRatio { get; set; }
        public int DiscountPercent { get; set; }
        public double DefaultPack { get; set; }
        public double SecondPack { get; set; }
        public double ThirdPack { get; set; }
    }
}
