namespace workshop.wwwapi.DTO
{
    public class GetAppointmentForDoctorsDTO
    {
        public DateTime Booking {  get; set; }

        public PatientDTO Patient { get; set; }
    }
}
