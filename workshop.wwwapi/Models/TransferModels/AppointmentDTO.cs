using workshop.wwwapi.Models.PureModels;

namespace workshop.wwwapi.Models.TransferModels
{
    public class AppointmentDTO(DateTime time, int patientId, int doctorId, Doctor doctor, Patient patient)
    {

        public DateTime time { get; set; } = time;
        public int patientId { get; set; } = patientId;
        public int doctorId { get; set;} = doctorId;
        public string Doctor { get; set; } = doctor.FullName;
        public string Patient { get; set; } = patient.FullName;

    }
}
