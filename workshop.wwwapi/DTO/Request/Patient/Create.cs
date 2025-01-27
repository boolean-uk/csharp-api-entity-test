using System.ComponentModel.DataAnnotations.Schema;

namespace workshop.wwwapi.DTO.Request.Patient
{
    public class Create 
    {
        public Create(){}
        public Create(Models.Patient p)
        {
            FullName = p.FullName;
        }
        public string FullName { get; set; }
    }
}
