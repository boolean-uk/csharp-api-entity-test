using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using workshop.wwwapi.DTOs.Core;
using workshop.wwwapi.Models;

namespace workshop.wwwapi.DTOs.Extension
{
    public class MedicinePrescriptionDTO
    {
        public int Id { get; set; }
        public int MedicineId { get; set; }
        public MedicineDTO_L1 Medicine { get; set; }
        public int PrescriptionId { get; set; }
        public PrescriptionDTO_L1 Prescription { get; set; }
        public int AppointmentId { get; set; }
        public AppointmentDTO Appointment { get; set; }
    }
}
