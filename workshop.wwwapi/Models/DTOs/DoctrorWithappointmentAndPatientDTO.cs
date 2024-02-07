namespace workshop.wwwapi.Models.DTOs;

public class DoctrorWithAppointmentAndPatientDTO
{
    public string FullName { get; set; }
    public ICollection<AppointmentWithPatentDTO> Appointments { get; set; }

    public static DoctrorWithAppointmentAndPatientDTO ToDTO(Doctor doctor)
    {
        var appointments = new List<AppointmentWithPatentDTO>();
        foreach (var appointment in doctor.Appointments)
        {
            appointments.Add(AppointmentWithPatentDTO.ToDTO(appointment));
        }

        return new DoctrorWithAppointmentAndPatientDTO()
        {
            FullName = doctor.FullName,
            Appointments = appointments,
        };
    }
}
