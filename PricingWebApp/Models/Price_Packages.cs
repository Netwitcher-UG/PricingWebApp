namespace PricingWebApp.Models
{
    public class Price_Packages
    {

        public int id { get; set; }
        public PraiceCalculation? PraiceCalculationID { get; set; }

        public int winperc { get; set; }
        public int discount { get; set; }

        public double defaultpack { get; set; }
        public double secondpack { get; set; }
        public double thirdpack { get; set; }

    }
}
