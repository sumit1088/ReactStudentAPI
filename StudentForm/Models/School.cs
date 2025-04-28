namespace StudentForm.Models
{
    public class School
    {
        public int Id { get; set; }
        public int SchoolId { get; set; }
        public int CenterId { get; set; }
        public string? Name { get; set; }
        public string? Address { get; set; }
        public int DistrictId { get; set; }
        public int TehsilId { get; set; }
        public string? State { get; set; }
        public int PinCode { get; set; }
        public string? TeacherName { get; set; }
        public string? ContactNo1 { get; set; }
        public string? ContactNo2 { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }       
        public bool IsDeleted { get; set; }
        public DateTime? Created { get; set; }
    }
}
