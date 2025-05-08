namespace workshop.wwwapi.DTOs
{
    public class PerscriptionDTO
    {
        public int Id { get; set; }

        public int AppointmentId { get; set; }  

        public int doctorId { get; set; }   

        public int patientId { get; set; }
        public List<MedicineDTO> Medicines { get; set; }
    }
}
