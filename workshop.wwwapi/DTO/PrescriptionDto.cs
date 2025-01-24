namespace workshop.wwwapi.DTO
{
    internal class PrescriptionDto
    {
        public DateTime Date { get; set; }
        public List<MedicineDto> Medicines { get; set; }
        public string Patient { get; set; }
        public string Doctor { get; set; }

    }
}