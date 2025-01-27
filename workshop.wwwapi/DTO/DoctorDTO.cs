using System;

namespace workshop.wwwapi.DTO;

public class DoctorDTO
{
    public string FullName { get; set; }
    public ICollection<AppointmentDTO> Appointments { get; set; }
}
