using workshop.wwwapi.Models.AppointmentModels.DTO;
using workshop.wwwapi.Models.AppointmentModels;
using System;

namespace workshop.wwwapi.Models.PrescriptionModels.DTO
{
    public class AppointmentPrescriptionDto
    {
        public DateTime Booking { get; set; }

        public DoctorAppointmentDto Doctor { get; set; }

        public PatientAppointmentDto Patient { get; set; }

        public String Type { get; set; }

        public static AppointmentPrescriptionDto Create(Appointment appointment)
        {
            return new AppointmentPrescriptionDto()
            {
                Booking = appointment.Booking,
                Doctor = DoctorAppointmentDto.Create(appointment.Doctor),
                Patient = PatientAppointmentDto.Create(appointment.Patient),
                Type = appointment.Type.ToString()
            };
        }
    }
}
