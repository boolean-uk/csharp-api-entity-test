using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace workshop.wwwapi.Models.Post.Extension
{

    public class MedicinePost
    {
        public string Name { get; set; }
        public int Quantity { get; set; }
        public string Instruction { get; set; }
    }
}
