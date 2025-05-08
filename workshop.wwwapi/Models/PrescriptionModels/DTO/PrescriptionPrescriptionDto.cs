using workshop.wwwapi.Models.AppointmentModels;
using workshop.wwwapi.Models.PrescriptionMedicineModels;

namespace workshop.wwwapi.Models.PrescriptionModels.DTO
{
    public class PrescriptionPrescriptionDto
    {
        public int PrescriptionId { get; set; }
        public AppointmentPrescriptionDto Appointment { get; set; }
        public IEnumerable<PrescriptionMedicinePrescriptionDto> PrescriptionMedicines { get; set; }

        public static PrescriptionPrescriptionDto Create(Prescription prescription)
        {
            return new PrescriptionPrescriptionDto
            {
                PrescriptionId = prescription.PrescriptionId,
                Appointment = AppointmentPrescriptionDto.Create(prescription.Appointment),
                PrescriptionMedicines = prescription.PrescriptionMedicines.Select(PrescriptionMedicinePrescriptionDto.Create)
            };
        }
    }
}