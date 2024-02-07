using workshop.wwwapi.Models.Types;

namespace workshop.wwwapi.Models.DTOs;

public class MedicineDTO
{
    public string Name { get; set; }
    public static MedicineDTO ToDTO(Medicine medicine)
    {
        return new MedicineDTO() { Name = medicine.Name };
    }
}
