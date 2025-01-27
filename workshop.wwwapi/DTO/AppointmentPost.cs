using System;

namespace workshop.wwwapi.DTO;

public class AppointmentPost
{
    public int DoctorId { get; set; }
    public int PatientId { get; set; }
    public DateTime AppointmentDate { get; set; }
}
