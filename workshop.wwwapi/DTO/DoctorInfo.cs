using System.ComponentModel.DataAnnotations.Schema;

namespace workshop.wwwapi.DTO
{
    public class DoctorInfo
    {
        public int Id { get; set; }
        public string FullName { get; set; }
    }
}
