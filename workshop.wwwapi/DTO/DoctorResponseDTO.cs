using System.ComponentModel.DataAnnotations.Schema;
using workshop.wwwapi.Models;

namespace workshop.wwwapi.DTO
{
    public class DoctorResponseDTO
    {
        public int Id { get; set; }

        public string FullName { get; set; }

        public ICollection<AppointmentDTO> Appointments { get; set; } = new List<AppointmentDTO>();

        public DoctorResponseDTO(Doctor doctor)
        {
            Id = doctor.Id;
            FullName = doctor.FullName;
            foreach (var appointment in doctor.Appointments)
                Appointments.Add(new AppointmentDTO(appointment));
        }

        public static List<DoctorResponseDTO> FromRepository(IEnumerable<Doctor> doctors)
        {
            var results = new List<DoctorResponseDTO>();
            foreach (var doctor in doctors)
                results.Add(new DoctorResponseDTO(doctor));
            return results;
        }

        public static DoctorResponseDTO FromARepository(Doctor doctor)
        {
            DoctorResponseDTO result = new DoctorResponseDTO(doctor);
            return result;
        }
    }
}
