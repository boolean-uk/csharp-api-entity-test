namespace workshop.wwwapi.DTO.Server
{
    public class patientAndDoctor_dto
    {
        public string FullName { get; set; }
        public IEnumerable<patientAndDoctorAppointments> appointments { get; set; }
    }
}
