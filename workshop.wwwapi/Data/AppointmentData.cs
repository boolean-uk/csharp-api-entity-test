using System;
using workshop.wwwapi.Models;

namespace workshop.wwwapi.Data;

public class AppointmentData
{
    public List<Appointment> Appointments { get; set; } = new List<Appointment>
    {
        new Appointment
        {
            AppointmentDate = DateTime.UtcNow,
            DoctorId = 1,
            PatientId = 1
        },
        new Appointment
        {
            AppointmentDate = DateTime.UtcNow,
            DoctorId = 2,
            PatientId = 2
        }
    };
}
