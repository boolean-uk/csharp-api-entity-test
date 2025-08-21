using workshop.wwwapi.DTOs;
using workshop.wwwapi.Models;

namespace workshop.wwwapi.Factories
{
    public static class PrescribedMedicineFactory
    {
        public static PrescribedMedicine PrescribedMedicineFromDto(PrescribedMedicineDto dto)
        {
            var entity = new PrescribedMedicine();
            entity.MedicineId = dto.MedicineId;
            entity.Quantity = dto.Quantity;
            entity.Notes = dto.Notes;

            return entity;
        }

        public static PrescribedMedicineDto DtoFromPrescribedMedicine(PrescribedMedicine entity)
        {
            var dto = new PrescribedMedicineDto();
            dto.Quantity = entity.Quantity;
            dto.Notes = entity.Notes;
            dto.MedicineId = entity.MedicineId;

            return dto;
        }
    }
}
