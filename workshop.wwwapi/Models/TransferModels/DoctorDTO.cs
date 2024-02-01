namespace workshop.wwwapi.Models.TransferModels
{
    public class DoctorDTO(int id, string Name)
    {
        public int ID { get; set; } = id;

        public string Name { get; set; } = Name;
    }
}
