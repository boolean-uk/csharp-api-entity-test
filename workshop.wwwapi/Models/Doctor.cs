using System.ComponentModel.DataAnnotations.Schema;

namespace workshop.wwwapi.Models
{
    //TODO: decorate class/columns accordingly    
    public class Doctor
    {        
        public int Id { get; set; }        
        public string FirstName { get; set; }
    }
}
