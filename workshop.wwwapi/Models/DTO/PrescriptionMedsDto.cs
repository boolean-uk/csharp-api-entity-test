namespace workshop.wwwapi.Models.DTO
{
    public class PrescriptionMedsDto
    {
        public int DoctorId { get; set; }
        public string DoctorName { get; set; }

        public int PatientId { get; set; }
        public string PatientName { get; set; }
        public string MedicineName { get; set; }

        public string Instructions { get; set; }
        public int Quantity { get; set; }
    }
}
