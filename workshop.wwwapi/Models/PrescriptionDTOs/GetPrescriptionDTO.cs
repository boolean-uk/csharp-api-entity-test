using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using workshop.wwwapi.Models.DoctorDTOs;
using workshop.wwwapi.Models.AppointmentDTOs;

namespace workshop.wwwapi.Models
{
    public class GetPrescriptionDTO
    {
        public Guid Id { get; set; }

        public Guid AppointmentId { get; set; }

        public GetAppointmentDTO Appointment { get; set; }
        public ICollection<GetMedicineDTO> Medicines { get; set; }

    }
}
