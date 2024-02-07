namespace workshop.wwwapi.Models.DTOs;

public class MedicinePrescriptionDTO
{
    public MedicineDTO MedicineDTO { get; set; }
    public int quantity { get; set; }
    public string instructions { get; set; }
    public static MedicinePrescriptionDTO ToDTO(MedicinePrescription medicinePrescription)
    {
        return new MedicinePrescriptionDTO()
        {
            MedicineDTO = MedicineDTO.ToDTO(medicinePrescription.Medicine),
            quantity = medicinePrescription.Quantity,
            instructions = medicinePrescription.Instructions,
        };
    }
}
