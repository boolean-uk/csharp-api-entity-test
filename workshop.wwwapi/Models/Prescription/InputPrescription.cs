namespace workshop.wwwapi.Models
{
    public class InputPrescription
    {
        public ICollection<InputMedicine> Medicines { get; set; }

        public int AppointmentId { get; set; }
    }
}
