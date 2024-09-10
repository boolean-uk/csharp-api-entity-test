namespace workshop.wwwapi.DTO
{
    public class GetDoctorDTO
    {
        private string _firstname;
        private string _lastname;
        public GetDoctorDTO(string firstname, string lastname)
        {
            _firstname = firstname;
            _lastname = lastname;
        }

        public string Name => $"{_firstname} {_lastname}";
        
        public List<DTODoctorAppointment> Appointments { get; set; } = new List<DTODoctorAppointment>();
    }
}
