namespace StudentForm.Models
{
    public class CenterDto
    {
        public int Id { get; set; }
        public int CenterId { get; set; }
        public string? Name { get; set; }
        public string? Address { get; set; }
        public string? DistrictName { get; set; }
        public string? TehsilName { get; set; }
        public DateTime? Created { get; set; }
    }

}
