using System.ComponentModel.DataAnnotations.Schema;

namespace workshop.wwwapi.Models.DTO
{
    public class OutputPatient
    {
        public int Id { get; set; }

        public string FullName { get; set; }
    }
}
