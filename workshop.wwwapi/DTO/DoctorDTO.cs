using System.ComponentModel.DataAnnotations.Schema;
using workshop.wwwapi.Models;

namespace workshop.wwwapi.DTO
{
    public class DoctorDTO
    {
        [Column("Id")]

        public int Id { get; set; }
        public string FullName { get; set; }
        public List<string> Appointments { get; set; } = new List<string>();
        public DoctorDTO() { }
        public DoctorDTO(Doctor doctor)
        {
            Id = doctor.Id;
            FullName = doctor.FullName;
            //making string representation of Appointments
            
            doctor.Appointments.ForEach(a => Appointments.Add($"Patient: {a.Patient.FullName}, Doctor: {FullName}, Time: {a.Booking}"));
        }
    }
}
