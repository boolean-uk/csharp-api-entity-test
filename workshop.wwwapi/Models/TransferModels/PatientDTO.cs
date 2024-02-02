using workshop.wwwapi.Models.PureModels;

namespace workshop.wwwapi.Models.TransferModels
{
    public class PatientDTO(int id, string name, List<Appointment> appointments)
    {
        public int Id { get; set; } = id;

        public string Name { get; set; } = name;

        public ICollection<AppointmentWithDoctorDTO> Appointments { get; set; } = new List<AppointmentWithDoctorDTO>(appointments.Select(a => new AppointmentWithDoctorDTO(a.Booking, a.DoctorId, a.Doctor)));
    }
}
