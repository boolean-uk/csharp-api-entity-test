namespace workshop.wwwapi.DTO
{
    public class DoctorAppointmentsDTO
    {
        public int Id { get; set; }
        public string FullName { get; set; }

        public ICollection<GetAppointmentForDoctorsDTO> Appointments { get; set; } = new List<GetAppointmentForDoctorsDTO>();

    }
}
