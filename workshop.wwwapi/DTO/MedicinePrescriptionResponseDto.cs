namespace workshop.wwwapi.DTO
{
    public class MedicinePrescriptionResponseDto
    {
        public string Doctor { get; set; }
        public string Patient { get; set; }
        public List<MedicinePrescriptionDto> Medicines { get; set; } = new List<MedicinePrescriptionDto>();
        public DateTime Date { get; set; }

    }
}
