using System.ComponentModel.DataAnnotations;
using workshop.wwwapi.Models;

namespace workshop.wwwapi.Dtoes.DoctorDtos
{
    public class DoctorDto
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public List<AppointmentInDoctorDto> Appointments { get; set; } = new List<AppointmentInDoctorDto>();

        public DoctorDto(Doctor doctor)
        {
            Id = doctor.DoctorId;
            FullName = doctor.FullName;

            foreach(Appointment a in doctor.Appointments)
            {
                Appointments.Add(new AppointmentInDoctorDto(a.PatientId, a.Patient.LastName));
            }
        }
    }
}
