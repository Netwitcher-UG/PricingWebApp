using System.ComponentModel.DataAnnotations;

namespace PricingWebApp.Models
{
    //Ms.Anas Delete this file when you finish testing it because Walaa will create it
    public class FixCosts
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? Title { get; set; }
        [Required]
        public decimal Cost { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
    }
}
