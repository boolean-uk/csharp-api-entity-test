using workshop.wwwapi.Enums;

namespace workshop.wwwapi.DTOs
{
    public class AppointmentDTO
    {
        public AppointmentDTO(string DoctorName, string PatientName, DateTime booking, AppointmentType type)
        {
            this.DoctorName = DoctorName;
            this.PatientName = PatientName;
            Booking = booking;
            this.Type = type;
        }
        public AppointmentDTO()
        {
        }

        public string DoctorName { get; set; }
        public string PatientName { get; set; }
        public AppointmentType Type { get; set; }

        public DateTime Booking {  get; set; }

    }
}
