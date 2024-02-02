using workshop.wwwapi.Models.PureModels;

namespace workshop.wwwapi.Models.TransferModels
{
    public class DoctorDTO(int id, string Name, List<Appointment> appointments)
    {
        public int ID { get; set; } = id;

        public string Name { get; set; } = Name;

        public ICollection<AppointmentWithPasientDTO> Appointments { get; set; } = appointments.Select(a => new AppointmentWithPasientDTO(a.Booking, a.PatientId, a.Patient)).ToList();
    }
}
