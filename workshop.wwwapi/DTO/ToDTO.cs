using Microsoft.EntityFrameworkCore.Metadata;
using workshop.wwwapi.Models;
using workshop.wwwapi.DTO;


namespace workshop.wwwapi.DTO
{
    public static class ToDTO
    {
        public static PatientDTO ToPatientDTO(this Patient patient) =>
            new PatientDTO
            {
                Id = patient.Id,
                FullName = patient.FullName,
                Appointments = patient.Appointments.Select(a => new AppointmentDTO
                {
                    PatientId = a.PatientId,
                    PatientName = a.Patient?.FullName,
                    DoctorId = a.DoctorId,
                    DoctorName = a.Doctor?.FullName,
                    BookingDate = a.Booking
                }).ToList()
            };

        public static DoctorDTO ToDoctorDTO(this Doctor doctor) =>
            new DoctorDTO
            {
                Id = doctor.Id,
                FullName = doctor.FullName,
                Appointments = doctor.Appointments.Select(d => new AppointmentDTO
                {
                    PatientId = d.PatientId,
                    PatientName = d.Patient?.FullName,
                    DoctorId = d.DoctorId,
                    DoctorName = d.Doctor?.FullName,
                    BookingDate = d.Booking
                }).ToList()
            };

        public static AppointmentDTO ToAppointmentDTO(this Appointment appointment) =>
            new AppointmentDTO
            {
                PatientId = appointment.PatientId,
                PatientName = appointment.Patient?.FullName,
                DoctorId = appointment.DoctorId,
                DoctorName = appointment.Doctor?.FullName,
                BookingDate = appointment.Booking,
                Type = appointment.Type.ToString()
            };

        public static List<AppointmentDTO> ToAppointmentDTO(this IEnumerable<Appointment> appointments) =>
            appointments.Select(a => a.ToAppointmentDTO()).ToList();
    }
}
