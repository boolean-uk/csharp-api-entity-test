using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace workshop.wwwapi.Models.AppointmentModels.DTO
{
    public class AppointmentAppointmentDto
    {

        public DateTime Booking { get; set; }

        public DoctorAppointmentDto Doctor { get; set; }

        public PatientAppointmentDto Patient { get; set; }

        public AppointmentType Type { get; set; }

        public static AppointmentAppointmentDto Create(Appointment appointment)
        {
            return new AppointmentAppointmentDto()
            {
                Booking = appointment.Booking,
                Doctor = DoctorAppointmentDto.Create(appointment.Doctor),
                Patient = PatientAppointmentDto.Create(appointment.Patient),
                Type = appointment.Type
            };
        }
    }
}


