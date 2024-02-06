using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace workshop.wwwapi.Models.Post
{
    public class MedicinePrescriptionPost
    {
        public int MedicineId { get; set; }
        public int Quantity { get; set; }
        public string Instruction { get; set; }
        public int PrescriptionId { get; set; }
        public string DoctorsNote { get; set; }
        public int AppointmentId { get; set; }
    }
}
