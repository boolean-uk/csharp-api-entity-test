using System.ComponentModel.DataAnnotations;

namespace workshop.wwwapi.Models
{
    public class PostPerson
    {
        [Required]
        public string FullName { get; set; }
    }
}
