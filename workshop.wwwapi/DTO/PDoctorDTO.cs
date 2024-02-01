using workshop.wwwapi.Models;

namespace workshop.wwwapi.DTO
{
    public class PDoctorDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public PDoctorDTO(Doctor doctor) 
        {
            Id = doctor.Id;
            Name = doctor.FullName;
        }
    }
}
