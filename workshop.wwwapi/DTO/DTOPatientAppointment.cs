namespace workshop.wwwapi.DTO
{
    public class DTOPatientAppointment
    {
        private DateTime _booking;
        private int _doctorid;

        public DateTime Booking { get => _booking; set => _booking = value; }
        public int DoctorId { get => _doctorid; set => _doctorid = value; }
    }
}
