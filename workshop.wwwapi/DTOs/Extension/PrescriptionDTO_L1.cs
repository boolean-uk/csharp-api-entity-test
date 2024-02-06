using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace workshop.wwwapi.DTOs.Extension
{
    public class PrescriptionDTO_L1
    {
        public int Id { get; set; }
        public string DoctorsNote { get; set; }
    }
}
