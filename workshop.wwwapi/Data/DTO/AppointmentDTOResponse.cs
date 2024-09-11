

using workshop.wwwapi.Models;

namespace workshop.wwwapi.Data.DTO {

    public class AppointmentDTO {
        public int Id {get; set;}
        public DateTime Booking {get; set;}

        public DoctorDTO Doctor {get; set;}

        public PatientDTO Patient {get; set;}

        public AppointmentDTO(Appointment appointment) {
            Id = appointment.Id;
            Booking = appointment.Booking;
            Doctor = new DoctorDTO(appointment.Doctor);
            Patient = new PatientDTO(appointment.Patient);
        }

        public static ICollection<PatientDTO> FromRepository(IEnumerable<Patient> patients) {
            List<PatientDTO> result = new List<PatientDTO>();
            foreach (Patient patient in patients)
            {
                result.Add(new PatientDTO(patient));
            }
            return result;

        }


    }
}