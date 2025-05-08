namespace workshop.wwwapi.Models.DataTransfer.Appointment
{
    public class AppointmentInsertDTO
    {
        public int DoctorID { get; set; }
        public int PatientID { get; set; }
        public int year { get; set; }
        public int month { get; set; }
        public int day { get; set; }
        public int hour { get; set; }
        public int minute { get; set; }
    }
}
