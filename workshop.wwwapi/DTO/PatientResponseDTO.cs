namespace workshop.wwwapi.DTO
{
    public class PatientResponseDTO
    {
        public List<PatientDTOwithoutAppointment> Patients { get; set; } = new List<PatientDTOwithoutAppointment>();
    }
}
