using workshop.wwwapi.DTOs.DoctorDTOs;

namespace workshop.wwwapi.DTOs.AppointmentDTOs
{
    public class AppointmentDoctorDTO
    {
        public DateTimeOffset Booking {  get; set; }
        public int DoctorId { get; set; }
        public DoctorDTO Doctor { get; set; }
    }
}
