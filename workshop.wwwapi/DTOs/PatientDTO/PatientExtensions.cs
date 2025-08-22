using workshop.wwwapi.Models;

namespace workshop.wwwapi.DTOs.PatientDTO
{
    public static class PatientExtensions
    {
        public static PatientGet ToDTO(this Patient entity)
        {
            PatientGet patient = new PatientGet();
            patient.FullName = entity.FullName;
            patient.Id = entity.Id;

            foreach (var a in entity.Appointments)
            {
                PatientAppointmentGet appointment = new PatientAppointmentGet();
                appointment.Id = a.Id;
                appointment.DoctorName = a.Doctor.FullName;
                appointment.DoctorId = a.DoctorId;
                appointment.Booking = a.Booking;
                patient.Appointments.Add(appointment);
            }
            return patient;
        }
    }
}
