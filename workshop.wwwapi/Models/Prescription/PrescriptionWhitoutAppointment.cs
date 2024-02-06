namespace workshop.wwwapi.Models
{
    public class PrescriptionWhitoutAppointment
    {
        public int Id { get; set; }
        public IEnumerable<MedicineWhitoutPrescription> Medicines { get; set; }
    }
}
