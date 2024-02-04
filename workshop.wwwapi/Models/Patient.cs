using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using workshop.wwwapi.Data.DTO;

namespace workshop.wwwapi.Models
{
    
    //TODO: decorate class/columns accordingly
    [Table("patient")]
    public class Patient
    {
        [Column("id")]
        public int Id { get; set; }
        [Column("full_name")]
        public string FullName { get; set; }
        [Column("appointments")]
        public List<Appointment> Appointments { get; set; } = new List<Appointment>();

        public PatientDTO ToPatientDTO()
        {
            List<AppointmentPatientDTO> appointmentDTO = new List<AppointmentPatientDTO>();

            foreach (Appointment appointment in Appointments)
            {
                appointmentDTO.Add(appointment.ToPatientDTO());
            }

            return new PatientDTO
            {
                PatientId = Id,
                PatientName = FullName,
                Appointments = appointmentDTO
            };
        }
    }
   
}
