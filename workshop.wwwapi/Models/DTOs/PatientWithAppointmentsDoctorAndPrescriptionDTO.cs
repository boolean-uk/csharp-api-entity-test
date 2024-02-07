using workshop.wwwapi.Models.Types;

namespace workshop.wwwapi.Models.DTOs;

public class PatientWithAppointmentsDoctorAndPrescriptionDTO
{
    public string FullName { get; set; }
    public ICollection<AppointmentWithDoctorAndPrescriptionDTO> Appointments { get; set; }

    public static PatientWithAppointmentsDoctorAndPrescriptionDTO ToDTO(Patient patient)
    {
        var appointments = new List<AppointmentWithDoctorAndPrescriptionDTO>();
        foreach (var appointment in patient.Appointments)
        {
            appointments.Add(AppointmentWithDoctorAndPrescriptionDTO.ToDTO(appointment));
        }
        return new PatientWithAppointmentsDoctorAndPrescriptionDTO()
        {
            FullName = patient.FullName,
            Appointments = appointments,
        };
    }

}
