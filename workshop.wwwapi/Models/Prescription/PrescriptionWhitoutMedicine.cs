namespace workshop.wwwapi.Models
{
    public class PrescriptionWhitoutMedicine
    {
        public int Id { get; set; } 
        public AppointmentWhithoutPrescription Appointment { get; set; }
    }
}
