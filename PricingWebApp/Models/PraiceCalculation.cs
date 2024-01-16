namespace PricingWebApp.Models
{
    public class PraiceCalculation
    {
        public int ID { get; set; }

        public Employes? UserID { get; set; }
        public Servises? ServiseID { get; set; }
        public Projects? ProjectID { get; set; }
        public double ServiseCost { get; set; }

        public int count { get; set; }
        public double FixCost { get; set; }



    }
}
