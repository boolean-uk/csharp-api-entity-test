namespace workshop.wwwapi.DTO
{
    //- a patient should include its appointments and
    //each appointment include the doctor's name / id
    public class PatientDTO
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public List<PatientAppointmentDTO> Appointments { get; set; } = [];
    }
}
