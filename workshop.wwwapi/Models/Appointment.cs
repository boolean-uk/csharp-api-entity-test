using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace workshop.wwwapi.Models
{
    //TODO: decorate class/columns accordingly
    public class Appointment
    {
        
        public DateTime Booking { get; set; }
        
        public int DoctorId { get; set; }
  
        public int PatientId { get; set; }
        public int Appointment_Id { get; set; }
        public AppointmentType Type { get; set; } 

        
        public int PrescriptionId { get;set; }
        public List<Prescription>prescriptions { get; set; }
    }

    public enum AppointmentType
    {
        InPerson,
        Online
    }
}
