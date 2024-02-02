namespace workshop.wwwapi.Models.DTOs;

public class DoctrorWithappointmentAndPatientDTO
{
    public string FullName { get; set; }
    public ICollection<AppointmentWithPatentDTO> Appointments { get; set; }

    public static DoctrorWithappointmentAndPatientDTO ToDTO(Doctor doctor)
    {
        var appointments = new List<AppointmentWithPatentDTO>();
        foreach (var appointment in doctor.Appointments)
        {
            appointments.Add(AppointmentWithPatentDTO.ToDTO(appointment));
        }

        return new DoctrorWithappointmentAndPatientDTO()
        {
            FullName = doctor.FullName,
            Appointments = appointments,
        };
    }
}
