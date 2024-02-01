namespace workshop.wwwapi.Models.TransferModels
{
    public class PatientDTO(int id, string name)
    {
        public int Id { get; set; } = id;

        public string Name { get; set; } = name;
    }
}
