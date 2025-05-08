using System;
using workshop.wwwapi.Models;

namespace workshop.wwwapi.DTOs;

public class AppointmentGetPatient
{
    public DateTime Booking { get; set; }
        
    public string Doctor { get; set; }

    public AppointmentGetPatient() {}
    public AppointmentGetPatient(Appointment a)
    {
        Booking = a.Booking;
        Doctor = a.Doctor.FullName;
    }
    

}
