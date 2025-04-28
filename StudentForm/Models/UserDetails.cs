using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace StudentForm.Models
{
    [Table("userdetails")]
    public class UserDetails
    {
        [Key]
        public int id { get; set; }
        [Required]
        public string? username { get; set; }
        [Required]
        public string? password { get; set; }
        public string? FirstName { get; set; }
        public string? MiddleName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? Role { get; set; }
        public DateTime? createddate { get; set; } 
    }

}
