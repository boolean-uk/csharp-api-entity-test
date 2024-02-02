namespace workshop.wwwapi.DTOs.Appointments
{
    public class GetAppointmentDTO
    {
        public string PatientFullName { get; set; }
        public string DoctorName { get; set; }
        public DateTime AppointmentDate { get; set; }
    }
}
