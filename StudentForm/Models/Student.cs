namespace StudentForm.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string? Surname { get; set; }
        public string? Firstname { get; set; }
        public string? Lastname { get; set; }
        public string? MotherName { get; set; }
        public string? ClassName { get; set; }
        public string? Medium { get; set; }
        public int SchoolId { get; set; }
        public School? School { get; set; }
        public int CenterId { get; set; }
        public Center? Center { get; set; }
        public DateTime? Created { get; set; }
    }
}
