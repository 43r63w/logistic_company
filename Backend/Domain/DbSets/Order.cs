using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace Domain.DbSets
{
    [Table("orders")]
    public class Order
    {
        [Column("id")]
        [Key]
        public int Id { get; set; }
        [Column("customer_id")]
        public int CustomerId { get; set; }
        [ForeignKey(nameof(CustomerId))]
        public Customer Customer { get; set; }

        [Column("employee_id")]
        public int EmployeeId { get; set; }
        [ForeignKey(nameof(EmployeeId))]
        public Employee Employee { get; set; }

        [Column("product_id")]
        public int ProductId { get; set; }
        [ForeignKey(nameof(ProductId))]
        public Product Product { get; set; }    

        [Column("order_date")]
        public DateTimeOffset OrderDate { get; set; } = DateTimeOffset.UtcNow;

        [Column("shipped_date")]
        public DateTimeOffset ShippedDate { get; set; }
        
        [Column("order_price")]
        [Required]
        [Range(0, long.MaxValue)]
        public decimal OrderPrice { get; set; }

        [Column("weight")]
        [Required]
        public decimal Weight { get; set; }

        [Column("vehicels_type")]
        public string VehicelsType { get; set; } = string.Empty;
        
        [Column("city_of_delivery")]
        [Required]
        public string CityOfDelivery { get; set; } = string.Empty;

        [Column("delivery_address")]
        [Required]
        public string DeliveryAddress { get; set; } = string.Empty;

        [Column("delivery_postal_code")]
        [Required]
        public string DeliveryPostalCode { get; set; } = string.Empty;
        
        [Column("description")]
        [MaybeNull]
        public string Description { get; set; } 
    }
}
