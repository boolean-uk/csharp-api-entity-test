namespace workshop.wwwapi.DTO
{
    public class GetPatientDTO
    {
        private string _firstname;
        readonly string _lastname;
        public GetPatientDTO(string firstname, string lastname)
        {
            _firstname = firstname;
            _lastname = lastname;
        }

        public string Name => $"{_firstname} {_lastname}";
    }
}
