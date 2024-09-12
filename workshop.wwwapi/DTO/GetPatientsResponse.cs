namespace workshop.wwwapi.DTO
{
    public class GetPatientsResponse
    {
        public List<PatientDTOWithAppointments> Patients { get; set; } = new List<PatientDTOWithAppointments>();
    }
}
