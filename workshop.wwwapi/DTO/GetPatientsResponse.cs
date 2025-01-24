namespace workshop.wwwapi.DTO
{
    public class GetPatientsResponse
    {
        public ICollection<PatientAppointmentsDTO> Patients { get; set; } = new List<PatientAppointmentsDTO>();
    }
}
