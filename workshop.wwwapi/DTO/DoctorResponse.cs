using System.ComponentModel.DataAnnotations.Schema;
using workshop.wwwapi.DTO;

namespace workshop.wwwapi.Models
{
    public class DoctorResponseDTO
    {
        public int Id { get; set; }
        public string FullName { get; set; }

        public ICollection<DoctorAppointmentDTO> Appointments { get; set; } = new List<DoctorAppointmentDTO>();

        public DoctorResponseDTO(Doctor Doctor)
        {
            Id = Doctor.Id;
            FullName = Doctor.FullName;
            if (Doctor.Appointments != null)
            {
                foreach (Appointment appointment in Doctor.Appointments)
                {
                    Appointments.Add(new DoctorAppointmentDTO(appointment));
                }
            }

        }

        public static List<DoctorResponseDTO> FromRepository(IEnumerable<Doctor> Doctors)
        {
            var results = new List<DoctorResponseDTO>();
            foreach (var Doctor in Doctors)
            {
                results.Add(new DoctorResponseDTO(Doctor));
            }
            return results;
        }

        public static DoctorResponseDTO FromRepository(Doctor Doctor)
        {
            return new DoctorResponseDTO(Doctor);
        }

    }
}