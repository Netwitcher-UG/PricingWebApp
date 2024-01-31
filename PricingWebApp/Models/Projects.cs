namespace PricingWebApp.Models
{
    public class Projects
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public List<PriceCalculation>? PriceCalculation { get; set; }

    }
}
