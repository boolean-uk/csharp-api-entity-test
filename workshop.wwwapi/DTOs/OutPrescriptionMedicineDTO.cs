using System.ComponentModel.DataAnnotations.Schema;
using workshop.wwwapi.Models;

namespace workshop.wwwapi.DTOs
{
    public class OutPrescriptionMedicineDTO
    {

        public int MedicineId { get; set; }
    
      // public int PrescriptionId { get; set; }
       
        public int Quatity { get; set; }
        public string Note { get; set; }
    }
}
