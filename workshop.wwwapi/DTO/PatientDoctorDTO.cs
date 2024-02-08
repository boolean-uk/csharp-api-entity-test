using workshop.wwwapi.Models;

namespace workshop.wwwapi.DTO
{
    public class PatientDoctorDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public PatientDoctorDTO(Doctor doctor) 
        {
            Id = doctor.Id;
            Name = doctor.FullName;
        }
    }
}
