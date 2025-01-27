using workshop.wwwapi.Enums;

namespace workshop.wwwapi.ViewModel
{
    public class CreateAppointment
    {
        public int DoctorId { get; set; }
        public int PatientId { get; set; }
        public DateTime Booking {  get; set; }
        public AppointmentType AppointmentType { get; set; }
    }
}
