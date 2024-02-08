namespace workshop.wwwapi.Models.DTOs
{
    public class MedicineDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public string Instructions { get; set; }
        public ICollection<PrescriptionDTOLess> Prescriptions { get; set; }
    }

    public class PrescriptionDTO
    {
        public int Id { get; set; }
        public ICollection<MedicineDTOLess> Medicines { get; set; }
    }

    public class MedicineDTOLess
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public string Instructions { get; set; }
    }

    public class PrescriptionDTOLess
    {
        public int Id { get; set; }
    }
}
