using workshop.wwwapi.Models.PureModels;
using workshop.wwwapi.Models.TransferModels.Appointments;

namespace workshop.wwwapi.Models.TransferModels.People
{
    public class DoctorDTO(int id, string Name, List<Appointment> appointments)
    {
        public int ID { get; set; } = id;

        public string Name { get; set; } = Name;

        public ICollection<AppointmentWithPasientDTO> Appointments { get; set; } = appointments.Select(a => new AppointmentWithPasientDTO(a.Booking, a.PatientId, a.Patient)).ToList();
    }
}
