using workshop.wwwapi.DTOs;
using workshop.wwwapi.Models;

namespace workshop.wwwapi.Factories
{
    public static class PrescriptionFactory
    {
        public static Prescription PrescriptionFromDto(PrescriptionPostDto dto)
        {
            var entity = new Prescription();
            entity.PatientId = dto.PatientId;
            entity.DoctorId = dto.DoctorId;

            return entity;
        }

        public static PrescriptionDto DtoFromPrescription(Prescription entity)
        {
            var dto = new PrescriptionDto();
            dto.Id = entity.Id;
            dto.PatientId = entity.PatientId;
            dto.DoctorId = entity.DoctorId;

            List<PrescribedMedicineDto> medicines = new();
            foreach (var med in entity.Medicines) 
            { 
                medicines.Add(PrescribedMedicineFactory.DtoFromPrescribedMedicine(med));
            }
            dto.Medicines = medicines;

            return dto;
        }
    }
}
