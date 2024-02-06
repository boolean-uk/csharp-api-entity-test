namespace workshop.wwwapi.Models
{
    public class OutputPrescription
    {
        public int Id { get; set; }
        public IEnumerable<MedicineWhitoutPrescription> Medicines { get; set; }
        public AppointmentWhithoutPrescription Appointment { get; set; }
    }
}
