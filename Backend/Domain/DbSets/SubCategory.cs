using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security;

namespace Domain.DbSets
{
    [Table("subs_category")]
    public class SubCategory
    {
     
        [Column("id")]
        [Key]
        public int Id { get; set; }

        [Column("sub_category_name")]
        [Required]
        public string SubCategoryName { get; set; } = null!;

    }
}
