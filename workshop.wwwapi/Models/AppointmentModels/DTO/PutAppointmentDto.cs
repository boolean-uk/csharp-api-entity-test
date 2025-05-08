namespace workshop.wwwapi.Models.AppointmentModels.DTO
{
    public class PutAppointmentDto
    {
        public DateTime Booking { get; set; }

        public int DoctorId { get; set; }

        public int PatientId { get; set; }

        public AppointmentType AppointmentType { get; set; }
    }
}
