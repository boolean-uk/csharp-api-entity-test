using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using workshop.wwwapi.Data.DTO;

namespace workshop.wwwapi.Models
{
   
    //TODO: decorate class/columns accordingly    
    [Table("doctor")]
    public class Doctor
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("full_name")]
        public string FullName { get; set; }
        [Column("appointments")]
        public List<Appointment> Appointments { get; set; } = new List<Appointment>();

        public DoctorDTO ToDTO()
        {
            List<AppointmentDoctorDTO> appointmentDTO = new List<AppointmentDoctorDTO>();

            foreach (Appointment appointment in Appointments)
            {
                appointmentDTO.Add(appointment.ToDoctorDTO());
            }

            return new DoctorDTO
            {
                DoctorId = Id,
                DoctorName = FullName,
                Appointments = appointmentDTO
            };
        }
    }
    
   
}

