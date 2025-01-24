using workshop.wwwapi.Models;

namespace workshop.wwwapi.ViewModel
{
    public class DetailsDTO
    {
        public DateTime date {  get; set; }
        public int Id { get; set; }
        public string Name { get; set; }

        public DetailsDTO(int id, string name, DateTime date)
        {
            this.Id = id;
            this.Name = name;
            this.date = date;
        }
    }
}
