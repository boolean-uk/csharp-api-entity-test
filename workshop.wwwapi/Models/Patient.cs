using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Numerics;

namespace workshop.wwwapi.Models
{
    //TODO: decorate class/columns accordingly    
    [Table("patients")]
    public class Patient
    {
        
        [Column("patient_id")]
        public int Id { get; set; }

        [Column("patient_name")]
        public string FullName { get; set; }
        public ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();
    }

    public class PatientDto
    {
        public string Name { get; set; }
        public ICollection<AppointmentPatientDto> Appointments { get; set; } = new List<AppointmentPatientDto>();
    public PatientDto(Patient patient)
        {
            Name = patient.FullName;
            foreach (Appointment appointment in patient.Appointments)
            {
                Appointments.Add(new AppointmentPatientDto(appointment));
            }
        }
        public PatientDto()
        {
        }
    }
 }