namespace workshop.wwwapi.Dtoes.PatientDtos
{
    public class AppointmentInPatientDto
    {
        public int DoctorId { get; set; }
        public string DoctorName { get; set; }

        public AppointmentInPatientDto(int id, string name)
        {
            DoctorId = id;
            DoctorName = name;
        }
    }
}
