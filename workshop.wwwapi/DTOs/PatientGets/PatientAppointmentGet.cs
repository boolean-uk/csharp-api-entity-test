using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace workshop.wwwapi.Models
{
    //TODO: decorate class/columns accordingly
    public class PatientAppointmentGet
    {

        public int Id { get; set; }
        public DateTime Booking { get; set; }
        public int DoctorId { get; set; }
        public PatientDoctorGet Doctor { get; set; }


    }
}
