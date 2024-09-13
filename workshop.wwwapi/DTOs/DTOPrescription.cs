namespace workshop.wwwapi.DTOs
{
    public class DTOPrescription
    {
        public int ID { get; set; }
        public DTOAppointment  Appointment {get; set;}

        public List<DTOMedicineOnPrescription> Medicines { get; set;} = new List<DTOMedicineOnPrescription>();
    }
}
