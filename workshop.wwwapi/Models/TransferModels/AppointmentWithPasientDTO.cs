using workshop.wwwapi.Models.PureModels;

namespace workshop.wwwapi.Models.TransferModels
{
    public class AppointmentWithPasientDTO(DateTime Time, Patient patient)
    {
        public DateTime Time { get; set; } = Time;

        public string Patient { get; set; } = patient.FullName;
    }
}
