namespace workshop.wwwapi.DTO
{
    public class GetAppointmentsDTO
    {
        private DateTime _booking;
        private int _doctorid;
        private string _doctorname;
        private int _patientid;
        private string _patientname;

        public DateTime Booking { get => _booking; set => _booking = value; }
        public int DoctorId { get => _doctorid; set => _doctorid = value; }
        public string DoctorName { get => _doctorname; set => _doctorname = value; }
        public int PatientId { get => _patientid; set => _patientid = value; }
        public string Patientname { get => _patientname; set => _patientname = value; }
    }
}
