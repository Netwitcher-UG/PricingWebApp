namespace PricingWebApp.Models
{
    public class Employees
    {
        public int Id { get; set; }
        public string? First_Name { get; set; }
        public string? Last_Name { get; set; }
        public int PhoneNo { get; set; }

        public string? Email { get; set; }

        public bool Admin { get; set; }

        public double HourRate { get; set; }

    }
}