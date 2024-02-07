namespace workshop.wwwapi.Models.DTOS
{
    public class DoctorBaseDTO
    {
        public int Id { get; set; }
        public string FullName { get; set; }

        public DoctorBaseDTO(Doctor doctor)
        {
            Id = doctor.Id;
            FullName = doctor.FullName;
        }
    }
}
