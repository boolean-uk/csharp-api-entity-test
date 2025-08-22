using Microsoft.EntityFrameworkCore.Storage.Json;
using workshop.wwwapi.Models;

namespace workshop.wwwapi.DTOs.AppointmentDTO
{
    public static class AppointmentExtension
    {
        public static AppointmentGet ToDTO(this Appointment entity)
        {
            AppointmentGet appointment = new AppointmentGet();
            appointment.Id = entity.Id;
            appointment.Booking = entity.Booking;
            appointment.Type = entity.Type;
            //appointment.Doctor = new AppointmentGet.DoctorGet();
            appointment.Doctor.DoctorId = entity.DoctorId;
            appointment.Doctor.DoctorName = entity.Doctor.FullName;
            //appointment.Patient = new AppointmentGet.PatientGet();
            appointment.Patient.PatientId = entity.PatientId;
            appointment.Patient.PatientName = entity.Patient.FullName;
            return appointment;
        }
    }
}
