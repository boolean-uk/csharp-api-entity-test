namespace workshop.wwwapi.Models.DTOS
{
    public class DoctorDTO
    {
        public string FullName { get; set; }

        public DoctorDTO(Doctor doctor)
        {
            FullName = doctor.FullName;
        }
    }
}
