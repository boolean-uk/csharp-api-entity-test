using workshop.wwwapi.Models;

namespace workshop.wwwapi.DTO
{
    public class DoctorAppointmentDTO
    {
        public DateTime DoctorAppointmentDate {  get; set; }
        public PatientDTOwithoutAppointment Patient {  get; set; }
    }
}
