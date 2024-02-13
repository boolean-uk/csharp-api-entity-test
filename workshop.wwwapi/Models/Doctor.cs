using System.ComponentModel.DataAnnotations.Schema;

namespace workshop.wwwapi.Models
{
    //TODO: decorate class/columns accordingly
    [Table("doctors")]
    public class Doctor
    {
        [Column("doctor_id")]
        public int Id { get; set; }

        [Column("doctor_name")]
        public string FullName { get; set; }
        public ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();
    }

    public class DoctorDto
    {
        public string Name { get; set; }
        public ICollection<AppointmentDoctorDto> Appointments { get; set; } = new List<AppointmentDoctorDto>();
        public DoctorDto(Doctor doctor)
        {
            Name = doctor.FullName;
            foreach(Appointment appointment in doctor.Appointments)
            {
                Appointments.Add(new AppointmentDoctorDto(appointment));
            }
        }
        public DoctorDto()
        {
            
        }
    }
    public class DoctorPatch
    {
        public string Name { get; set; }
    }
    }

