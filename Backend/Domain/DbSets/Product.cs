using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.DbSets
{
    [Table("products")]
    public class Product
    {
        [Column("id")]
        [Key]
        public int Id { get; set; }
        [Column("name")]
        [Required]
        public string Name { get; set; } = string.Empty;
        [Column("quantity_per_unit")]
        [Required]
        public string QuantityPerUnit { get; set; } = string.Empty;
        [Column("Price")]
        [Required]
        public decimal Price { get; set; }
        [Column("category_id")]
        public int CategoryId { get; set; }
        [ForeignKey(nameof(CategoryId))]
        public Category Category { get; set; }
        [Column("sub_category_id")]
        public int SubCategoryId { get; set; }
        [ForeignKey(nameof(SubCategoryId))]
        public SubCategory SubCategory { get; set; }

        [Column("is_discount")]
        public bool IsDiscount { get; set; }

        [Column("price_with_discount")]
        public decimal PriceWithDiscount { get; set; }

    }
}


