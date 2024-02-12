using System.ComponentModel.DataAnnotations.Schema;

namespace workshop.wwwapi.Models
{
    //TODO: decorate class/columns accordingly    
    [Table("doctors")]
    public class Doctor
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("full_name")]
        public string FullName { get; set; }

        public List<Appointment> Appointments { get; set; }

        public DoctorDto ToDto()
        {
            return new DoctorDto
            {
                FullName = FullName,
                Appointments = Appointments.Select(a => a.ToDto()).ToList()
            };
        }

        public DoctorDataDto ToDataDto()
        {
            return new DoctorDataDto
            {
                Id = Id,
                FullName = FullName
            };
        }
    }

    public struct DoctorDto
    {
        public string FullName { get; set; }
        public List<AppointmentDto> Appointments { get; set; }
    }

    public struct DoctorDataDto
    {
        public int Id { get; set; }
        public string FullName { get; set; }
    }
}
