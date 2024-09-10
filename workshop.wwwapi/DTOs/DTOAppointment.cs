using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace workshop.wwwapi.DTOs
{
    public class DTOAppointment
    {

        public DateTime Booking { get; set; }

        public int DoctorId { get; set; }

        public int PatientId { get; set; }

    }
}
