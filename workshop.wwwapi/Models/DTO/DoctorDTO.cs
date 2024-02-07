namespace workshop.wwwapi.Models.DTO
{
    public class DoctorDTO
    {
        public string fullName { get; set; }

        public ICollection<AppointmentDoctor> Appointments { get; set; } = new List<AppointmentDoctor>();

    }
}
