using workshop.wwwapi.DTOs.Appointment;

namespace workshop.wwwapi.DTOs.Patient;

public class PatientPost
{
    public string FullName { get; init; }
    public ICollection<AppointmentPost> Appointments { get; init; }

    public static PatientPost FromPatient(Models.Patient patient)
    {
        return new PatientPost
        {
            FullName = patient.FullName,
            Appointments = patient.Appointments.Select(AppointmentPost.FromAppointment).ToList(),
        };
    }
}