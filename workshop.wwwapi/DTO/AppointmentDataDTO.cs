using workshop.wwwapi.Models;

namespace workshop.wwwapi.DTO
{
    public class AppointmentDataDTO
    {
        public int Id { get; set; }
        public string BookingDate { get; set; }
        public int DocktorId { get; set; }
        public int PationId { get; set; }

        public AppointmentDataDTO(Appointment appointment)
        {
            Id = appointment.Id;
            BookingDate = appointment.Booking;
            DocktorId = appointment.DoctorId;
            PationId = appointment.PatientId;
        }
    }
}
