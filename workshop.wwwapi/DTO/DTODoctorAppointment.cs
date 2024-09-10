namespace workshop.wwwapi.DTO
{
    public class DTODoctorAppointment
    {
        private DateTime _booking;
        private int _patientid;

        public DateTime Booking { get => _booking; set => _booking = value; }
        public int PatientId { get => _patientid; set => _patientid = value; }
    }
}
