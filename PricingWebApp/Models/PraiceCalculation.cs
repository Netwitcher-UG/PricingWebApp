namespace PricingWebApp.Models
{
    public class PraiceCalculation
    {
        public int  id { get; set; }

        public Employes? Employeid { get; set; }
        public Servises? Serviseid { get; set; }
        public Projects? Projectid { get; set; }
        public double ServiseCost { get; set; }

        public int count { get; set; }
        public double fixCost { get; set; }



    }
}
