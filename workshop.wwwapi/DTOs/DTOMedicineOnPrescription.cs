using workshop.wwwapi.Models;

namespace workshop.wwwapi.DTOs
{
    public class DTOMedicineOnPrescription
    {
        public int MedicneID { get; set; }
        public string Name { get; set; }
        public int DoseInMg { get; set; }
        public string Instruction { get; set; }
    }
}