namespace StudentForm.Models
{
    public class Center
    {
        public int Id { get; set; }
        public int CenterId { get; set; }
        public string? Name { get; set; }
        public string? Address { get; set; }
        public int DistrictId { get; set; }
        public int TehsilId { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? Created { get; set; }

        // Navigation properties
        public DistrictsMasters? District { get; set; }
        public TehsilsMasters? Tehsil { get; set; }
    }
}
