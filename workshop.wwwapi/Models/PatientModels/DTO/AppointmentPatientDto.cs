using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using workshop.wwwapi.Models.AppointmentModels;
using workshop.wwwapi.Models.DoctorModels;

namespace workshop.wwwapi.Models.PatientModels.DTO;


public class AppointmentPatientDto
{
    public DateTime Booking { get; set; }
    public DoctorPatientDto Doctor { get; set; }

    public static AppointmentPatientDto Create(Appointment appointment)
    {
        return new AppointmentPatientDto()
        {
            Booking = appointment.Booking,
            Doctor = DoctorPatientDto.Create(appointment.Doctor)
        };
    }
    
}
