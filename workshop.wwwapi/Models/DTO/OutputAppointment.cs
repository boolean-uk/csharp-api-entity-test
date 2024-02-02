using System.ComponentModel.DataAnnotations.Schema;

namespace workshop.wwwapi.Models.DTO
{
    public class OutputAppointment
    {
        public DateTime Booking { get; set; }
        public DoctorWhithoutAppointment Doctor { get; set; }
        public PatientWhithoutAppointment Patient { get; set; }
    }
}