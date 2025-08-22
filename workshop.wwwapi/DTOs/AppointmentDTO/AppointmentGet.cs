using workshop.wwwapi.Enums;

namespace workshop.wwwapi.DTOs.AppointmentDTO
{
    public class AppointmentGet
    {
        public int Id { get; set; }
        public DateTime Booking { get; set; }
        public AppointmentType Type { get; set; }
        public DoctorGet Doctor { get; set; } = new DoctorGet();
        public PatientGet Patient { get; set; } = new PatientGet();

        public class PatientGet
        {
            public int PatientId { get; set; }
            public string PatientName { get; set; }
        }
        public class DoctorGet
        {
            public int DoctorId { get; set; }
            public string DoctorName { get; set; }
        }
    }
}
