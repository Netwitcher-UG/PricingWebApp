using System.ComponentModel.DataAnnotations;

namespace PricingWebApp.Models
{
    public class Employees
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? FirstName { get; set; }
        [Required]
        public string? MiddleName { get; set; }
        [Required]
        public string? LastName { get; set; }
        public string FullName => $"{FirstName} {MiddleName} {LastName}";
        [Required]
        [EmailAddress]
        public string? EmailAdress { get; set; }
        [Required]
        public int? PhoneNo { get; set; }
        [Required]
        public string? Adress { get; set; }


    }
}
