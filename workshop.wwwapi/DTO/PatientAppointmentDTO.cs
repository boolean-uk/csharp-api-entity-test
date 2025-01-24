namespace workshop.wwwapi.DTO
{
    public class PatientAppointmentDTO
    {
        public DateTime PatientAppointmentDate { get; set; }

        public DoctorDTOwithAppointment Doctor { get; set; }
    }
}
