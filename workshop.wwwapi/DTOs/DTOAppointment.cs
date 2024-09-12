namespace workshop.wwwapi.DTOs
{
    public class DTOAppointment
    {
        public string Booking {  get; set; }
        public DTODoctorWithoutAppointment Doctor { get; set; }
        public DTOPatientWithoutAppointment Patient { get; set; }
        
    }
}
