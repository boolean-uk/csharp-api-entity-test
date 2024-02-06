namespace workshop.wwwapi.Models.DTObjects
{
    public class DTAppointment
    {
        public int Id { get; set; }
        public DateTime Booking {  get; set; }
        public int DoctorId {  get; set; }
        public string DoctorName { get; set; }
        public int PatientId { get; set; }
        public string PatientName { get; set;}
    }
}
