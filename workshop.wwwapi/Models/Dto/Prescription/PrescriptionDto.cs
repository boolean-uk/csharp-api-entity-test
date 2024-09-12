using System.ComponentModel.DataAnnotations.Schema;
using workshop.wwwapi.Models.DatabaseModels;
using workshop.wwwapi.Models.Dto.Appointment;
using workshop.wwwapi.Models.Dto.Doctor;
using workshop.wwwapi.Models.Dto.Patient;
using workshop.wwwapi.Models.Dto.PrescriptionMedicine;

namespace workshop.wwwapi.Models.Dto.Prescription
{
    public class PrescriptionDto
    {
        public int Id { get; set; }
        //public DateTimeOffset AppointmentBookingId { get; set; }
        public int DoctorId { get; set; }
        public int PatientId { get; set; }
        public DoctorPlainDto Doctor { get; set; }
        public PatientPlainDto Patient { get; set; }
        //public AppointmentPlainDto Appointment { get; set; }
        public List<MedicineNoPrescriptionDto> PrescriptionMedicine { get; set; } = new List<MedicineNoPrescriptionDto>();
    }
}
