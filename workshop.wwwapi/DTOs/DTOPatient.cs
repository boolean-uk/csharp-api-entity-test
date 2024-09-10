namespace workshop.wwwapi.DTOs
{
    public class DTOPatient
    {
        public string PatientName {  get; set; }

        public List<DTOPatientAppointment> Appointments { get; set; } = new List<DTOPatientAppointment>();
    }
}
