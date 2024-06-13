using workshop.wwwapi.Models;

namespace workshop.wwwapi.DTO
{
    public class DoctorDTO
    {
        public int Id { get; set; }
        public string FullName { get; set; }

        public DoctorDTO(Doctor doctor) 
        {
            Id = doctor.Id;
            FullName = doctor.FullName;
        }
    }
}
