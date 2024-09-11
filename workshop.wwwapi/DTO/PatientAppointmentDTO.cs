namespace workshop.wwwapi.DTO
{
    public class PatientAppointmentDTO
    {
        public int DoctorId { get; set; }
        public string DoctorName { get; set; }
        public DateTime? Booking { get; set; }

        public PatientAppointmentDTO(int id, string name, DateTime booking)
        {
            DoctorId = id;
            DoctorName = name;
            Booking = booking;
        }
    }
}
