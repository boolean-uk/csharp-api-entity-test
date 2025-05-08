namespace workshop.wwwapi.DTO.Client
{
    public class perscription_create_dto
    {
        public int PatientId { get; set; }
        public int DoctorId { get; set; }
        public List<perscription_details_client_dto> PerscriptionDetails {  get; set; }
    }
}
