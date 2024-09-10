using workshop.wwwapi.DTO;
using workshop.wwwapi.Models;

namespace workshop.wwwapi.Extensions
{
    public static class PatientExtensions
    {
        public static PatientDTO ToDTO(this Patient patient)
        {
            return new PatientDTO
            {
                Id = patient.Id,
                FullName = patient.FullName,
                Appointments = [],
            };
        }

        public static PatientAppointmentDTO ToAppointmentDTO(this Appointment appointment, Doctor doctor) 
        {
            return new PatientAppointmentDTO
            {
                DoctorId = appointment.DoctorId,
                DoctorsName = doctor.FullName
            };
        }
    }
}
