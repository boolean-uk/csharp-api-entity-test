namespace workshop.wwwapi.DTO
{
    public class DTOAppointment
    {
        private DateTime _booking;
        private int _doctorid;
        private int _patientid;

        public DateTime Booking { get => _booking; set => _booking = value; }
        public int DoctorId { get => _doctorid; set => _doctorid = value; }
        public int PatientId { get => _patientid; set => _patientid = value; }
    }
}
