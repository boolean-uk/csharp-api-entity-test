using System;
using workshop.wwwapi.Models;

namespace workshop.wwwapi.DTOs;

public class DoctorGetDTO
{
    public int Id {get;set;}
    public string FullName {get;set;}
    public List<AppointmentGetDoctor> Appointments {get;set;} = new List<AppointmentGetDoctor>();

    public DoctorGetDTO() {}
    public DoctorGetDTO(Doctor d)
    {
        Id = d.Id;
        FullName = d.FullName;
        d.Appointments.ForEach(a => Appointments.Add(new AppointmentGetDoctor {
            Patient = a.Patient.FullName, Booking = a.Booking
        }));
    }

}
