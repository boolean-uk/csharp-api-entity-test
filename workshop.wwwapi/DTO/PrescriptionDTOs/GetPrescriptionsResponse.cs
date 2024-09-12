namespace workshop.wwwapi.DTO.PrescriptionDTOs
{
    public class GetPrescriptionsResponse
    {
        public List<GetPrescriptionDTO> Prescriptions { get; set; } = new List<GetPrescriptionDTO>();
    }
}
