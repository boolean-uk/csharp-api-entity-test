using workshop.wwwapi.Models;

namespace workshop.wwwapi.Data.DTO
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

        public static ICollection<DoctorDTO> FromRepository(IEnumerable<Doctor> doctors)
        {
            List<DoctorDTO> result = new List<DoctorDTO>();
            foreach (Doctor doctor in doctors)
            {
                result.Add(new DoctorDTO(doctor));
            }
            return result;

        }
    }
}
