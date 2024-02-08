using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace workshop.wwwapi.Models
{
    //TODO: decorate class/columns accordingly    
    [Table("doctors")]
    public class Doctor
    {
        
        [Column("doctor_id")]
        public int Id { get; set; }
        [Column("name")]
        public string FullName { get; set; }
        public List<Appointment> Appointments { get; set; } = new();
        public List<Prescription> Prescriptions { get; set; } = new();
    }

    public class DoctorDisplayDto
    {
        public int Id { get; set; }
        public string FullName { get; set; }
    }

    public class DoctorSpecificDto
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public List<DoctorAppointmentDto> Appointments { get; set; } = new();
    }

    public class DoctorCreate
    {
        public string FullName { get; set; }
    }
}
