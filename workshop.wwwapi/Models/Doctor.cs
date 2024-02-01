using System.ComponentModel.DataAnnotations.Schema;

namespace workshop.wwwapi.Models
{
    //TODO: decorate class/columns accordingly    
    [Table("doctors")]
    public class Doctor
    {
        [Column("id")]
        public int Id { get; set; }
        [Column("fullname")]
        public string FullName { get; set; }
        public ICollection<Appointment> Appointments { get; set; }
    }
    public record DoctorPayload(string fullName);

    public class AppointmentDoctorDTO
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public AppointmentDoctorDTO(Doctor doctor)
        {
            Id = doctor.Id;
            FullName = doctor.FullName;
        }
    }

    public class DoctorResponseDTO
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public ICollection<DoctorAppointmentDTO> Appointment { get; set; }

        public DoctorResponseDTO(Doctor doctor)
        {
            Id = doctor.Id;
            FullName = doctor.FullName;
            Appointment = new List<DoctorAppointmentDTO>();
            foreach (Appointment appointment in doctor.Appointments)
            {
                Appointment.Add(new DoctorAppointmentDTO(appointment));
            }
        }
    }



}
