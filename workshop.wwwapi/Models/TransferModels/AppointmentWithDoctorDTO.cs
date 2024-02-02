using workshop.wwwapi.Models.PureModels;

namespace workshop.wwwapi.Models.TransferModels
{
    public class AppointmentWithDoctorDTO(DateTime Time, int DoctorId, Doctor doctor)
    {
        public DateTime Time { get; set; } = Time;

        public int DoctorId { get; set; } = DoctorId;
        public string Doctor { get; set; } = doctor.FullName;
    }
}
