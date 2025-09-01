using workshop.wwwapi.DTOs.Appointment;

namespace workshop.wwwapi.DTOs.Doctor;

public class DoctorPost
{
    public string FullName { get; set; }
    public ICollection<AppointmentPost> Appointments { get; set; }
    
    public static DoctorPost FromDoctor(Models.Doctor doctor)
    {
        return new DoctorPost
        {
            FullName = doctor.FullName,
            Appointments = doctor.Appointments.Select(AppointmentPost.FromAppointment).ToList(),
        };
    }
}