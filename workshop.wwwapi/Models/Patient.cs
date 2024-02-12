using System.ComponentModel.DataAnnotations.Schema;
using System.Data;

namespace workshop.wwwapi.Models
{
    [Table("patients")]
    public class Patient
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("full_name")]
        public string FullName { get; set; }

        public List<Appointment> Appointments { get; set; }

        public PatientDto ToDto()
        {
            return new PatientDto
            {
                FullName = FullName,
                Appointments = Appointments.Select(a => a.ToDto()).ToList()
            };
        }

        public PatientDataDto ToDataDto()
        {
            return new PatientDataDto
            {
                Id = Id,
                FullName = FullName
            };
        }
    }

    public struct PatientDto
    {
        public string FullName { get; set; }
        public List<AppointmentDto> Appointments { get; set; }
    }

    public struct PatientDataDto
    {
        public int Id { get; set; }
        public string FullName { get; set; }
    }
}
