using System.ComponentModel.DataAnnotations.Schema;
using workshop.wwwapi.Models;

namespace workshop.wwwapi.DTOs
{
    public class OutAppointmentDTO
    {
     
        public DateTime Booking { get; set; }


        public int DoctorId { get; set; }
        public int PatientId { get; set; }

        public AppointmentType Appointmenttype { get; set; }
    }
}
