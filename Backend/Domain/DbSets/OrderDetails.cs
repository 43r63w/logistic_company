using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace Domain.DbSets
{
    [Table("order_details")]
    public class OrderDetails
    {
        [Column("id")]
        [Key]
        public int Id { get; set; }
        
        [Column("order_id")]
        public int OrderId { get; set; }
        [ForeignKey(nameof(OrderId))]
        public Order Order { get; set; }

        [Column("product_id")]
        public int ProductId { get; set; }
        [ForeignKey(nameof(ProductId))]
        public Product Product { get; set; }
        
        [Column("quantity")]
        [Required, Range(0, 255)]
        public byte Quantity { get; set; }
        
        [Column("is_discount")]
        public bool IsDiscount { get; set; }
        
    }
}
