namespace PricingWebApp.Models
{
    public class Price_Packages
    {

        public int id { get; set; }
        public PraiceCalculation? PraiceCalculationID { get; set; }

        public int WinPerc { get; set; }
        public int Discount { get; set; }

        public double DefaultPack { get; set; }
        public double SecondPack { get; set; }
        public double ThirdPack { get; set; }

    }
}
