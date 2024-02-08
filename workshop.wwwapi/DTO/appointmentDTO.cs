using System.ComponentModel.DataAnnotations.Schema;
using workshop.wwwapi.Models;

namespace workshop.wwwapi.DTO
{
    public class appointmentDTO
    {
        
        public int id { get; set; }
       
        public DateTime appointmentDate { get; set; }
       
        public int DoctorId { get; set; }

        public doctorDTO Doctor { get; set; }

        
        public int PatientId { get; set; }

        public patientDTO Patient { get; set; }
    }
}
