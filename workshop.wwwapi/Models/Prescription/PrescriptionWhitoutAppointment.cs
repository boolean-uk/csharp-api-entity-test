namespace workshop.wwwapi.Models
{
    public class PrescriptionWhitoutAppointment
    {
        public int Id { get; set; }
        public ICollection<MedicineWhitoutPrescription> Medicines { get; set; }
    }
}
