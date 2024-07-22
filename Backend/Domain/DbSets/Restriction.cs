using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.DbSets
{
    [Table("restrictions")]
    public class Restriction
    {
        [Column("id")]
        [Key]
        public int Id { get; set; }

        [Column("user_id")]
        public int UserId { get; set; }
        [ForeignKey(nameof(UserId))]
        public User User { get; set; }

        [Column("ban_type")]
        public string BanType { get; set; } = null!;
        
        [Column("restriction_detail")]
        public string? RestrictionDetail { get; set; } 

        [Column("expires_date_restriction")]
        public DateTimeOffset ExpiresDateRestriction { get; set; }
    }
}
