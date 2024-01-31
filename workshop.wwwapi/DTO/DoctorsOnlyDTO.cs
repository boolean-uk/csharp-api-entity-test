using workshop.wwwapi.Models;

namespace workshop.wwwapi.DTO
{
    public class DoctorsOnlyDTO
    {
        public int Id { get; set; }
        public string doc_name { get; set; }

        public DoctorsOnlyDTO(Doctor doctor) {
            Id = doctor.Id;
            doc_name = doctor.FullName;
        }
    }
}
