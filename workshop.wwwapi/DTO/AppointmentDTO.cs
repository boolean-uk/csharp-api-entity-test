namespace workshop.wwwapi.DTO
{
    public class AppointmentDTO
    {
        public string doctorName {  get; set; }
        public int doctorID { get; set; }
        public string PatientName { get; set; }
        public int PatientID { get; set; }

        public DateTime? booking { get; set; } = default(DateTime?);
    }
}
