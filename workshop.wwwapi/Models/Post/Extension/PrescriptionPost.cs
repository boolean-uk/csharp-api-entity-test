using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace workshop.wwwapi.Models.Post.Extension
{
    public class PrescriptionPost
    {
        public string DoctorsNote { get; set; }
        public int AppointmentId { get; set; }
        public List<int> MedicineIds { get; set; }
    }
}
