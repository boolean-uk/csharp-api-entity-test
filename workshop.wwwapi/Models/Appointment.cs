using System.ComponentModel.DataAnnotations.Schema;
using workshop.wwwapi.enums;

namespace workshop.wwwapi.Models
{
    //TODO: decorate class/columns accordingly
    public class Appointment
    {
        
        public DateTime Booking { get; set; }
        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; }
        public int PatientId { get; set; }
        public Patient Patient { get; set; }
        public AppointmentTypeEnum Type { get; set; }
        public int? PrescriptionId { get; set; }
        public Prescription? Prescription { get; set; }

    }
}
