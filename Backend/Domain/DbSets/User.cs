using Microsoft.AspNetCore.Identity;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices.ObjectiveC;


namespace Domain.DbSets
{
    [Table("users")]
    public class User
    {
        [Column("id")]
        [Key]
        public int Id { get; set; }
        [Column("employee_id")]
        [MaybeNull]
        public int? EmployeeId { get; set; }
        [ForeignKey(nameof(EmployeeId))]
        public Employee? Employee { get; set; }

        [Column("customer_id")]
        [MaybeNull]
        public int? CustomerId { get; set; }
        [ForeignKey(nameof(CustomerId))]
        public Customer? Customer { get; set; }

        [Column("role")]
        [Required]
        public string Role { get; set; } = string.Empty;

        [DataType(DataType.Password)]
        [Column("password")]
        public string Password { get; set; } = null!;

        [EmailAddress]
        [Column("email")]
        public string Email { get; set; } = null!;

        [Column("is_have_ban")]
        public bool IsHaveBan { get; set; }
        
    }
}
