namespace workshop.wwwapi.DTO
{
    public class DTOCreateAppointment
    {
        public DateTime Booking { get; set; }
        public int DoctorId { get; set; }
        public int PatientId { get; set; }

    }
}
