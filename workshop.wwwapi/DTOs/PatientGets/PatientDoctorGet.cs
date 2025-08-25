using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace workshop.wwwapi.Models
{
    //TODO: decorate class/columns accordingly    
    public class PatientDoctorGet
    {
        public int Id { get; set; }
        public string FullName { get; set; }

    }
}
