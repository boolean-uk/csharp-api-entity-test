using System.ComponentModel.DataAnnotations.Schema;

namespace workshop.wwwapi.DTO
{
    public class PatientInfo
    {
        public int Id { get; set; }
        public string FullName { get; set; }
    }
}
