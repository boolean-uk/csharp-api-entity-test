using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using workshop.wwwapi.Models;

namespace workshop.wwwapi.DTOs
{
    public class OutAppointmentDTO
    {
     
        public DateTime Booking { get; set; }


        public int DoctorId { get; set; }
        public int PatientId { get; set; }
        public int PrescriptionId { get; set; }

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public AppointmentType Appointmenttype { get; set; }
        public OutPrescriptionDTO Prescription { get; set; }
        //public ICollection<OutPrescriptionMedicineDTO> PrescriptMed { get; set; } = new List<OutPrescriptionMedicineDTO>();


    }
}
