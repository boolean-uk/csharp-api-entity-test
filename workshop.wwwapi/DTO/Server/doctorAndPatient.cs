namespace workshop.wwwapi.DTO.Server
{
    public class doctorAndPatient
    {
        public string FullName { get; set; }
        public IEnumerable<doctorAndPatientAppointment> appointments { get; set; }
    }
}
