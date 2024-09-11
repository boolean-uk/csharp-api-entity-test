using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using workshop.wwwapi.Models;

namespace workshop.wwwapi.DTOs
{
    public class ResponseMedicineDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public string Instructions { get; set; }
        public List<ResponsePrescriptionDTOMedicineLess> Prescriptions { get; set; } = new List<ResponsePrescriptionDTOMedicineLess>();
    }

    public class ResponseMedicineDTOPrescriptionLess
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public string Instructions { get; set; }
    }
}
