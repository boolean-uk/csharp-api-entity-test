using workshop.wwwapi.Models;

namespace workshop.wwwapi.DTO
{
    public class Appointment_DTO
    {
        public int DoctorID { get; set; }
        public int PasientID { get; set; }
        public DateTime Booking {  get; set; }

        public Appointment_DTO(Appointment appointment)
        {
            this.DoctorID = appointment.DoctorId;
            this.PasientID = appointment.PatientId;
            this.Booking = appointment.Booking;
        }
    }
}
