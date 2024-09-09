using workshop.wwwapi.DTO;
using workshop.wwwapi.Models;

namespace workshop.wwwapi.Extensions
{
    public static class AppointmentExtensions
    {
        public static AppointmentDTO ToDTO(this Appointment appointment, Patient patient, Doctor doctor) 
        {
            return new AppointmentDTO
            {
                Booking = appointment.Booking,
                PatientId = patient.Id,
                PatientName = patient.FullName,
                DoctorId = doctor.Id,
                DoctorName = doctor.FullName
            };
        }
    }
}
