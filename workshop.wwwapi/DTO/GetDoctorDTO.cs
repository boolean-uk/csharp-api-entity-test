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

        public string FirstName { get => _firstname; set => _firstname = value; }
        public string LastName { get => _lastname; set => _lastname = value; }
    }
}
