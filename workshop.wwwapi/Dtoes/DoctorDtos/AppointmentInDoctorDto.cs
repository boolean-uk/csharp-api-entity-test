namespace workshop.wwwapi.Dtoes.DoctorDtos
{
    public class AppointmentInDoctorDto
    {
        public int PatientId { get; set; }
        public string PatientName { get; set; } 

        public AppointmentInDoctorDto(int patientId, string patientName)
        {
            PatientId = patientId;
            PatientName = patientName; 
        }
    }
}
