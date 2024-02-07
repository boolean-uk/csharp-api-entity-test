using workshop.wwwapi.Models.Types;

namespace workshop.wwwapi.Models.DTOs;

public class MedicinePrescriptionDTO
{
    public MedicineDTO Medicine { get; set; }
    public int Quantity { get; set; }
    public string Instructions { get; set; }
    public static MedicinePrescriptionDTO ToDTO(MedicinePrescription medicinePrescription)
    {
        return new MedicinePrescriptionDTO()
        {
            Medicine = MedicineDTO.ToDTO(medicinePrescription.Medicine),
            Quantity = medicinePrescription.Quantity,
            Instructions = medicinePrescription.Instructions,
        };
    }
}
