namespace workshop.wwwapi.DTO
{
    //- a doctor should include its appointments
    //and each appointment include the patient's name / id
    
    public class DoctorDTO
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public List<DoctorsAppointmentDTO> Appointments { get; set; } = [];
    }
}
