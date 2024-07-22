using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.DbSets
{
    [Table("departments")]
    public class Department
    {
        [Column("Id")]
        [Key]
        public int Id { get; set; }
        [Required]
        [Column("name")]
        public string Name { get; set; } = string.Empty;
        [Range(0, long.MaxValue, ErrorMessage = "Budget must be 0 to 1_000_000_00")]
        [Column("budget")]
        public decimal Budget { get; set; }
    }
}
