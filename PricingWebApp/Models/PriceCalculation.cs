using System.ComponentModel.DataAnnotations.Schema;

namespace PricingWebApp.Models
{
    public class PriceCalculation
    {

        public int Id { get; set; }

        public  Employees? Employee { get; set; }
        public  Services?  Service { get; set; }
        public  Projects?  Project { get; set; }
        public double ServiceCost { get; set; }
        public int Count { get; set; }
        public double FixCost { get; set; }
    }
}
