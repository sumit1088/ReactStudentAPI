using System.ComponentModel.DataAnnotations;

namespace StudentForm.Models
{
    public class Teachers
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Contact No 1 is required")]
        public string? ContactNo1 { get; set; }

        public string? ContactNo2 { get; set; }

        [OptionalEmail]
        public string? Email { get; set; }

        [Required(ErrorMessage = "CenterId is required")]
        public int CenterId { get; set; }

        [Required(ErrorMessage = "SchoolId is required")]
        public int SchoolId { get; set; }

    }
}
