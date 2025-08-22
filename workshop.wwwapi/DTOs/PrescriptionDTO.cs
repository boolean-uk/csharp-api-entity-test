using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using workshop.wwwapi.Models;

namespace workshop.wwwapi.DTOs
{
    public class PrescriptionDTO
    {
        public AppointmentDTO Appointment { get; set; }

        public List<MedicineDTO> Medicine { get; set; } = new();
    }
}
