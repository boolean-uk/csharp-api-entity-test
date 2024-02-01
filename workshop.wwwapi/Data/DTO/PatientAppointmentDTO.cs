using workshop.wwwapi.Models;

namespace workshop.wwwapi.Data.DTO
{
    public class PatientAppointmentDTO
    {
        public int Id { get; set; }
        public DateTime Booking { get; set; }

        public PatientDTO Doctor { get; set; }


        public PatientAppointmentDTO(Appointment appointment)
        {
            Id = appointment.Id;
            Booking = appointment.Booking;
            Doctor = new PatientDTO(appointment.Patient);
        }

        public static ICollection<PatientAppointmentDTO> FromRepository(IEnumerable<Appointment> appointments)
        {
            List<PatientAppointmentDTO> result = new List<PatientAppointmentDTO>();
            foreach (Appointment patient in appointments)
            {
                result.Add(new PatientAppointmentDTO(patient));
            }
            return result;

        }
       

    }
}
