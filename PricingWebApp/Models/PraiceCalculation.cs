namespace PricingWebApp.Models
{
    public class PraiceCalculation
    {
        public int Id { get; set; }

        public Employes? User { get; set; }
        public Servises? Servise { get; set; }
        public Projects? Project { get; set; }
        public double ServiseCost { get; set; }

        public int count { get; set; }
        public double FixCost { get; set; }



    }
}
