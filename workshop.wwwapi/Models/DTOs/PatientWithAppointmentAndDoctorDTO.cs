namespace workshop.wwwapi.Models.DTOs;

public class PatientWithAppointmentAndDoctorDTO
{
    public string FullName { get; set; }
    public ICollection<AppointmentWithDoctorDTO> Appointments { get; set; }

    public static PatientWithAppointmentAndDoctorDTO ToDTO(Patient patient)
    {
        var appointments = new List<AppointmentWithDoctorDTO>();
        foreach (var appointment in patient.Appointments)
        {
            appointments.Add(AppointmentWithDoctorDTO.ToDTO(appointment));
        }
        return new PatientWithAppointmentAndDoctorDTO()
        {
            FullName = patient.FullName,
            Appointments = appointments,
        };
    }

}
