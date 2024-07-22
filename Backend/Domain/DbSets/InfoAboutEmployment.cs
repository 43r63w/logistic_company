using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.DbSets
{
    [Table("info_about_employment")]
    public class InfoAboutEmployment
    {
        [Column("id")]
        [Key]
        public int Id { get; set; }

        [Column("salary")]
        [Required]
        public decimal Salary { get; set; }

        [Column("work_identifier")]
        public string WorkIdentifier { get; set; } = Guid.NewGuid().ToString();

    }
}
