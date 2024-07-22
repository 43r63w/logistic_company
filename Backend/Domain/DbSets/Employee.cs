using Domain.CustomAttribute;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;


namespace Domain.DbSets
{
    [Table("employees")]
    public class Employee
    {
        [Column("id")]
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "This field is required")]
        [Column("last_name")]
        public string LastName { get; set; } = string.Empty;
        [Required(ErrorMessage = "This field is required")]
        [Column("first_name")]
        public string FirstName { get; set; } = string.Empty;
        [Required(ErrorMessage = "This field is required")]
        [Column("sur_name")]
        public string SurName { get; set; } = string.Empty;
        [Column("date_of_birth")]
        public DateTimeOffset DateOfBirth { get; set; }
        [Column("phone_number")]
        [RegularExpression(@"^(\+380|0)\d{9}$")]
        [MaxLength(15, ErrorMessage = "Phone number be able then 12 characters")]
        public string PhoneNumber { get; set; } = string.Empty;
        
        [Column("title")]
        [Required]
        public string Title { get; set; } = string.Empty;
        [Column("info_about_employment")]
        public int InfoAboutEmploymentId { get; set; }
        [ForeignKey(nameof(InfoAboutEmploymentId))]
        public InfoAboutEmployment InfoAboutEmployment { get; set; }

        [Column("hire_date")]
        [Required]
        public DateTimeOffset HireDate { get; set; }

        [PhotoFormat(new string[] { "png", "jpeg", "jpg" })]
        [MaxResulotion(1)]
        [NotMapped]
        public IFormFile Photo { get; set; }

        public string ImageUrl { get; set; } = string.Empty;

        [Column("department_id")]
        public int DepartmentId { get; set; }
        [ForeignKey(nameof(DepartmentId))]
        public Department Department { get; set; }

        [Column("description")]
        public string Description { get; set; } = string.Empty;

        [Column("city")]
        [Required]
        public string City { get; set; } = string.Empty;

        [Column("address")]
        [Required]
        public string Address { get; set; } = string.Empty;

        [MaybeNull]
        public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    }
}
