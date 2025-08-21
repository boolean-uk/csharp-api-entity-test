using workshop.wwwapi.Models;

namespace workshop.wwwapi.DTOs.DoctorDTO
{
    public static class DoctorExtensions
    {
        public static DoctorGet ToDTO(this Doctor entity)
        {
            // DTO stuff
            DoctorGet doctor = new DoctorGet();
            doctor.Id = entity.Id;
            doctor.FullName = entity.FullName;

            foreach (var a in entity.Appointments)
            {
                DoctorAppointmentGet appointment = new DoctorAppointmentGet();
                appointment.Id = a.Id;
                appointment.Booking = a.Booking;
                appointment.PatientName = a.Patient.FullName;
                appointment.PatientId = a.PatientId;
                doctor.Appointments.Add(appointment);
            }
            return doctor;
        }
    }
}
