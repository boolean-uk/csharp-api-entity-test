namespace workshop.wwwapi.Models.DTO
{
    public class OutputPatient
    {
        public int Id { get; set; }

        public string FullName { get; set; }

        public IEnumerable<AppointmentWhithoutPatient> Appointments { get; set; }
    }

    public class DoctorWhithoutAppointment
    {
        public int Id { get; set; }

        public string FullName { get; set; }
    }
}
