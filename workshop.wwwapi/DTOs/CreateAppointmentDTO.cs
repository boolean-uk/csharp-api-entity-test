using System;

namespace workshop.wwwapi.DTOs;

public class CreateAppointmentDTO
{
    public int DoctorId {get;set;}
    public int PatientId {get;set;}
    public DateTime Booking {get;set;}

}
