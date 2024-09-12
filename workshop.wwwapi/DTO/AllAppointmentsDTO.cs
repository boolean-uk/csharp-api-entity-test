namespace workshop.wwwapi.DTO
{
    public class AllAppointmentsDTO
    {
        public DateTime Booking { get; set; }
        public DoctorDTOWithoutAppointments Doctor { get; set; }
        public PatientDTOWithoutAppointments Patient { get; set; }
    }
}
