using workshop.wwwapi.Models.PureModels;

namespace workshop.wwwapi.Models.TransferModels.Appointments
{
    public class AppointmentWithPasientDTO(DateTime Time, int patientId, Patient patient)
    {
        public DateTime Time { get; set; } = Time;

        public int PatientId { get; set; } = patientId;

        public string Patient { get; set; } = patient.FullName;
    }
}
