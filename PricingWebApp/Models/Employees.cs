using System.ComponentModel.DataAnnotations;

namespace PricingWebApp.Models
{
    public class Employees
    {
        [Key]
        public int Id { get; set; }
        public string? First_Name { get; set; }
        public string? Last_Name { get; set; }
        public string? PhoneNo { get; set; }
        public string? Email { get; set; }
        public double HourRate { get; set; }
    }
}
