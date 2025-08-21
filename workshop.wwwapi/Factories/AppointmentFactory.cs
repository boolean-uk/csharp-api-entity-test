using workshop.wwwapi.DTOs;
using workshop.wwwapi.Models;

namespace workshop.wwwapi.Factories
{
    public class AppointmentFactory
    {
        public static AppointmentForDoctorDto DtoForDoctor(Appointment appointment)
        {
            var dto = new AppointmentForDoctorDto();
            dto.PatientId = appointment.PatientId;
            dto.PatientName = appointment.Patient.FullName;
            dto.Booking = appointment.Booking;
            dto.Type = appointment.Type;

            return dto;
        }

        public static AppointmentForPatientDto DtoForPatient(Appointment appointment)
        {
            var dto = new AppointmentForPatientDto();
            dto.DoctorId = appointment.DoctorId;
            dto.DoctorName = appointment.Doctor.FullName;
            dto.Booking = appointment.Booking;
            dto.Type = appointment.Type;

            return dto;
        }
        public static AppointmentDto DtoFromAppointment(Appointment appointment)
        {
            var dto = new AppointmentDto();
            dto.PatientId = appointment.PatientId;
            dto.PatientName = appointment.Patient.FullName;
            dto.DoctorId = appointment.DoctorId;
            dto.DoctorName = appointment.Doctor.FullName;
            dto.Booking = appointment.Booking;
            dto.Type = appointment.Type;

            return dto;
        }

        public static Appointment AppointmentFromPost(AppointmentPostDto dto)
        {
            var appointment = new Appointment();
            appointment.PatientId = dto.PatientId;
            appointment.DoctorId = dto.DoctorId;
            appointment.Booking = dto.Booking;
            appointment.Type = dto.Type;

            return appointment;
        }
    }
}
