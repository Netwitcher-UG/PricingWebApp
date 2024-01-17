namespace PricingWebApp.Models
{
    public class PriceCalculation
    {
        public int Id { get; set; }

        public Employees? User { get; set; }
        public Services? Servise { get; set; }
        public Projects? Project { get; set; }
        public double ServiseCost { get; set; }
        public int Count { get; set; }
        public double FixCost { get; set; }
    }
}
