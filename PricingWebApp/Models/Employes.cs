namespace PricingWebApp.Models
{
    public class Employes
    {
        public int ID { get; set; }
        public string? First_Name { get; set; }
        public string? Last_Name { get; set; }
        public int PhoneNo { get; set; }

        public string? Email { get; set; }

        public bool Admin { get; set; }

        public double HourRate { get; set; }

    }
}
