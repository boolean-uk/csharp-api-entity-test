using System;
using workshop.wwwapi.Models;

namespace workshop.wwwapi.DTOs;

public class AppointmentGetDTO
{

    public DateTime Booking { get; set; }
        
    public string Doctor { get; set; }
    
    public string Patient { get; set; }

    public AppointmentGetDTO() {}
    public AppointmentGetDTO(Appointment a)
    {
        Booking = a.Booking;
        Doctor = a.Doctor.FullName;
        Patient = a.Patient.FullName;
    }

    
}
