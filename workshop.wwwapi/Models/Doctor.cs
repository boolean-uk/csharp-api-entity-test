using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace workshop.wwwapi.Models
{
    //doctors class
    [Table("doctors")]
    public class Doctor
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("full_name")]
        public string FullName { get; set; }

        public List<Appointment> Appointments { get; set; }
    }

    //DTO
    public class DoctorsResponseDTO
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public List<AppointmentsResponseDTO> appointments { get; set; }
        public DoctorsResponseDTO(Doctor doctor)
        {
            Id = doctor.Id;
            FullName = doctor.FullName;
            appointments = doctor.Appointments?
                .Select(appointment => new AppointmentsResponseDTO(appointment))
                .ToList() ?? new List<AppointmentsResponseDTO>();
        }
    }
}