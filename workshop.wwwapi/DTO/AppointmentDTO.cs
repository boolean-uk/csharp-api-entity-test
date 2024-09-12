namespace workshop.wwwapi.DTO
{
    public class AppointmentDTO
    {
        public int Id { get; set; }
        public string Booking { get; set; }
        public PatientOnlyDTO Patient { get; set; }
        public DoctorsOnlyDTO Doctor { get; set; }
        public ICollection<PrescriptionWithMedicineDTO> Prescriptions { get; set; }
    }
}
