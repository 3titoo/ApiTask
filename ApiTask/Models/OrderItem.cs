using ApiTask.Models.Attribute;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiTask.Models
{
    public class OrderItem
    {
        [Key]
        public int OrderItemId { get; set; }
        [Required]
        public int OrderId { get; set; }
        [Required,MaxLength(50)]
        public string ProductName { get; set; }

        [Required]
        [postiveNumber]
        public double Quantity { get; set; }
        [Required]
        [postiveNumber]
        public double UnitPrice { get; set; }

        public double? TotalPrice { get; set; }

        

        [ForeignKey("OrderId")]
        public Order? Order { get; set; }


    }
}
