namespace workshop.wwwapi.DTO.Server
{
    public class perscription_server_dto
    {
        public int Id { get; set; }
        public string DoctorName { get; set; }
        public string PatientName { get; set; }
        public ICollection<perscription_details> Perscription_Details { get; set; }
    }
}
