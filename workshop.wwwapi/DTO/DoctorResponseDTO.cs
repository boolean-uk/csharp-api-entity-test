using workshop.wwwapi.Models;

namespace workshop.wwwapi.DTO
{
    public class DoctorResponseDTO
    {
        public int Id { get; set; }
        public string FullName { get; set; }

        /*public ICollection<DoctorAppointmentDTO>*/

        public DoctorResponseDTO(Doctor doctor)
        {
            Id = doctor.Id;
            FullName = doctor.FullName;
        }

        public static List<DoctorResponseDTO> FromRepository(IEnumerable<Doctor> doctors)
        {
            var results = new List<DoctorResponseDTO>();
            foreach (var Doctor in doctors)
            {
                results.Add(new DoctorResponseDTO(Doctor));
            }
            return results;
        }

        public static DoctorResponseDTO FromRrepository(Doctor doctor)
        {
            return new DoctorResponseDTO(doctor);
        }
    }
}
