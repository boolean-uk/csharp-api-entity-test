using System;
using workshop.wwwapi.Models;

namespace workshop.wwwapi.DTOs;

public class PatientGetDTO
{

    
    public int Id { get; set; }   
        
    public string FullName { get; set; }
    public List<AppointmentGetPatient> Appointments {get;set;} = new List<AppointmentGetPatient>();

    public PatientGetDTO() { }

    public PatientGetDTO(Patient p)
    {
        Id = p.Id;
        FullName = p.FullName;
        p.Appointments.ForEach(a => Appointments.Add(new AppointmentGetPatient(a)));
    }



}
