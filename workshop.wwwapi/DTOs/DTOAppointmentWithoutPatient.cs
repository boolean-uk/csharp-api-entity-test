namespace workshop.wwwapi.DTOs
{
    public class DTOAppointmentWithoutPatient
    {
        public string Booking {  get; set; }
        public DTODoctorWithoutAppointment  Doctor { get; set; }
    }
}
