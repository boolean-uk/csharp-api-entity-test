using System;

namespace workshop.wwwapi.DTO;

public class AppointmentDTO
{
    public string DoctorFullName { get; set; }
    public string PatientFullName { get; set; }
    public DateTime AppointmentDate { get; set; }
}
