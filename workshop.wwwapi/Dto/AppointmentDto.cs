using workshop.wwwapi.Enum;

namespace workshop.wwwapi.Dto
{
    public class AppointmentDto
    {
       
        public int PatientId { get; set; }
        public string PatientFullName { get; set; }
        public int DoctorId { get; set; }
        public string DoctorFullName { get; set; }
        public DateTime AppointmentDate { get; set; }

        public AppointmentType Type { get; set; }
    }
}
