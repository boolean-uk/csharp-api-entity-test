using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace workshop.wwwapi.Models
{
    public class Doctor
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public List<Appointment> Appointments { get; set; }
    }
}
