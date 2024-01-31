using System.ComponentModel.DataAnnotations;

namespace PricingWebApp.Models
{
    public class Employees
    {
        [Key]
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? PhoneNo { get; set; }
        public string? Email { get; set; }
        public double HourRate { get; set; }

        //public List<PriceCalculation> PriceCalculation { get; set; }


    }
}
