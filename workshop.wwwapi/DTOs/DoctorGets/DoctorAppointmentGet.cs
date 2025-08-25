using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace workshop.wwwapi.Models
{
    //TODO: decorate class/columns accordingly
    public class DoctorAppointmentGet
    {

        public int Id { get; set; }
        public DateTime Booking { get; set; }
        public int PatientId { get; set; }
        public DoctorPatientGet Patient { get; set; }


    }
}
