using System.ComponentModel.DataAnnotations.Schema;
using workshop.wwwapi.Models;

namespace workshop.wwwapi.DTO
{
    public class PrescriptionDTO
    {
        
        public int PrescriptionId { get; set; }
        public string? Notes { get; set; }

        public int AppointmentId { get; set; }
        


        public PrescriptionDTO(Prescription prescription) {
            PrescriptionId = prescription.PrescriptionId;
            if (prescription.Notes != null)
            {
                Notes = prescription.Notes;
            } else
            {
                Notes = "No note given";
            }
            AppointmentId = prescription.AppointmentId;
            
        }
    }
}
