namespace workshop.wwwapi.DTO
{
    public class GetPatientDTO
    {
        private string _firstname;
        private string _lastname;
        public GetPatientDTO(string firstname, string lastname)
        {
            _firstname = firstname;
            _lastname = lastname;
        }

        public GetPatientDTO()
        {
            
        }
        public string Name => $"{_firstname} {_lastname}";

        public List<DTOPatientAppointment> Appointments { get; set; } = new List<DTOPatientAppointment>();

        public string FirstName { get => _firstname; set => _firstname = value; }
        public string LastName { get => _lastname; set => _lastname = value; }
    }
}
