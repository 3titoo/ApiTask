using ApiTask.Models.Attribute;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Metrics;

namespace ApiTask.Models
{
    
    public class Order
    {
        [Key]
        public int OrderId { get; set; }

        public string? OrderNumber { get; set; }

        [Required]
        [MaxLength(50)]
        public string CustomerName { get; set; }    
        [Required]
        public string OrderDate { get; set; }
        [Required]
        [postiveNumber]
        public double TotalAmount { get; set; }

    }
}