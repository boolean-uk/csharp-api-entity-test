namespace workshop.wwwapi.Models.DTOs;

public class PrescriptionWithMedicinesDTO
{
    public string Name { get; set;}
    public ICollection<MedicinePrescriptionDTO> Medicines { get; set;}
    public static PrescriptionWithMedicinesDTO ToDTO(Prescription prescription)
    {
        var medicines = new List<MedicinePrescriptionDTO>();
        foreach (var medPres in prescription.MedicinePrescriptions)
        {
            medicines.Add(MedicinePrescriptionDTO.ToDTO(medPres));
        }
        return new PrescriptionWithMedicinesDTO()
        {
            Name = prescription.Name,
            Medicines = medicines,
        };
    }
}
