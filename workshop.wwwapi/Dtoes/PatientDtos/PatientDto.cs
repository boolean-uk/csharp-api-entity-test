using System.ComponentModel.DataAnnotations;
using workshop.wwwapi.Models;

namespace workshop.wwwapi.Dtoes.PatientDtos
{
    public class PatientDto
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        //TODO Appointment that contains Time, doctors name and id. 
        public List<AppointmentInPatientDto> Appointments { get; set; } = new List<AppointmentInPatientDto>();

        public PatientDto(Patient patient)
        {
            Id = patient.PatientId;
            FirstName = patient.FirstName;
            LastName = patient.LastName;
            
            foreach(Appointment a in patient.Appointments)
            {
                Appointments.Add(new AppointmentInPatientDto(a.DoctorId, a.Doctor.FullName));
            }
        }
    }
}
