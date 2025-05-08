using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using workshop.wwwapi.Models.AppointmentModels;

namespace workshop.wwwapi.Models.DoctorModels.DTO
{

    public class AppointmentDoctorDto
    {
        public DateTime Booking { get; set; }
        public PatientDoctorDto Patient { get; set; }

        public static AppointmentDoctorDto Create(Appointment appointment)
        {
            return new AppointmentDoctorDto()
            {
                Booking = appointment.Booking,
                Patient = PatientDoctorDto.Create(appointment.Patient)
            };
        }
    }
}
