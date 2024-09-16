using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using workshop.wwwapi.DTOs.Core;

namespace workshop.wwwapi.DTOs.Extension
{
    public class PrescriptionDTO_L1
    {
        public int Id { get; set; }
        public string DoctorsNote { get; set; }
        public int AppointmentId { get; set; }
        public AppointmentDTO Appointment { get; set; }
    }
}
