using System.ComponentModel.DataAnnotations.Schema;
using workshop.wwwapi.Models;

namespace workshop.wwwapi.DTO
{
    public class PrescriptionDTO
    {
        
        public int PrescriptionId { get; set; }

        
        public string? Notes { get; set; }

        public int AppointmentId { get; set; }
        public Appointment Appointment { get; set; }


        public PrescriptionDTO(Prescription prescription) {
            PrescriptionId = prescription.PrescriptionId;
            Notes = prescription.Notes;
            AppointmentId = prescription.AppointmentId;
            Appointment = prescription.Appointment;

        }
    }
}
