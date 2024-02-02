namespace workshop.wwwapi.Models.DTO
{
    public class OutputDoctor
    {
        public int Id { get; set; }
        public string FullName { get; set; }

        public IEnumerable<AppointmentWhithoutDoctor> Appointments { get; set; }
    }

    public class PatientWhithoutAppointment
    {
        public int Id { get; set; }

        public string FullName { get; set; }
    }
}
