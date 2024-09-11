using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using workshop.wwwapi.Models;

namespace workshop.wwwapi.DTOs
{
    public class ResponsePrescriptionDTO
    {
        public int Id { get; set; }

        public List<ResponseMedicineDTOPrescriptionLess> Medicines { get; set; } = new List<ResponseMedicineDTOPrescriptionLess>();

        public ResponseAppointmentDTOPrescriptionLess? Appointment { get; set; }
    }

    public class ResponsePrescriptionDTOMedicineLess
    {
        public int Id { get; set; }
        public ResponseAppointmentDTOPrescriptionLess? Appointment { get; set; }
    }
}
