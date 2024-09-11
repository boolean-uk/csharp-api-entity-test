namespace workshop.wwwapi.DTO
{
    public class DoctorAppointmentDTO
    {
        public int PatientId {  get; set; }
        public string PatientName { get; set; }
        public DateTime? Booking { get; set; }

        public DoctorAppointmentDTO(int id, string name, DateTime booking)
        {
            PatientId = id;
            PatientName = name;
            Booking = booking;
        }
    }
}
