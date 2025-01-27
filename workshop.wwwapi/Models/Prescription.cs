namespace workshop.wwwapi.Models
{
    public class Prescription
    {
        public int PrescriptionId { get; set; }

        public int PatientId { get; set; }
        public int DoctorId { get; set; }
        public int AppointmentId { get; set; }
        public Appointment appointment { get; set; }
        public MedicinePrescription MedicinePrescriptions { get; set; }
       
      

    }
}
