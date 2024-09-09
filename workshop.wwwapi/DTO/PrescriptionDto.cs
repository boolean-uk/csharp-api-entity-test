namespace workshop.wwwapi.DTO
{
    public class PrescriptionDto
    {
        public PrescriptionAppointment Appointment { get; set; }
        public IEnumerable<PrescriptionMedicineDto> Medicines { get; set; }
    }
    public class PrescriptionMedicineDto
    {
        public string Name { get; set; }
        public string Instructions { get; set; }
    }
    public class PrescriptionAppointment
    {
        public DateTime DateTime { get; set; }
        public PrescriptionDoctor Doctor { get; set; }
        public PrescriptionPatient Patient { get; set; }
    }
    public class PrescriptionDoctor
    {
        public string FullName { get; set; }
    }
    public class PrescriptionPatient
    {
        public string FullName { get; set; }
    }
}
