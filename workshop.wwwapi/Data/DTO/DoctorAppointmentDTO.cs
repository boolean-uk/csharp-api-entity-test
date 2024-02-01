using workshop.wwwapi.Models;

namespace workshop.wwwapi.Data.DTO
{
    public class DoctorAppointmentDTO
    {
        public int Id { get; set; }
        public DateTime Booking { get; set; }

        public DoctorDTO Patient { get; set; }


        public DoctorAppointmentDTO(Appointment appointment)
        {
            Id = appointment.Id;
            Booking = appointment.Booking;
            Patient = new DoctorDTO(appointment.Doctor);
        }

        public static ICollection<DoctorAppointmentDTO> FromRepository(IEnumerable<Appointment> appointments)
        {
            List<DoctorAppointmentDTO> result = new List<DoctorAppointmentDTO>();
            foreach (Appointment appointment in appointments)
            {
                result.Add(new DoctorAppointmentDTO(appointment));
            }
            return result;

        }

    }
}
