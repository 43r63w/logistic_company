using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.DbSets
{
    [Table("customers")]
    public class Customer
    {
        [Column("id")]
        [Key]
        public int Id { get; set; }

        [Column("company_name")]
        [Required]
        public string CompanyName { get; set; } = string.Empty;

        [Column("contact_name")]
        [Required]
        public string ContactName { get; set; } = string.Empty;

        [Column("contact_title")]
        [Required]
        public string ContactTitle { get; set; } = string.Empty;   
        
        [Column("address")]
        [Required]
        public string Address { get; set; } = string.Empty;

        [Column("postal_code")]
        [Required]
        public string PostalCode { get; set; } = string.Empty;

        [Column("city")]
        [Required]
        public string City { get; set; } = string.Empty;

        [Column("country")]
        [Required]
        public string Country { get; set; } = string.Empty;

        [Column("phone_number")]
        [Required]
        public string PhoneNumber { get; set; } = string.Empty;

    }
}
