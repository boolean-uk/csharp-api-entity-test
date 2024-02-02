namespace workshop.wwwapi.Models.DTOs;

public class PatientDTO
{
    public string FullName { get; set; }

    public static PatientDTO ToDTO(Patient patient)
    {
        return new PatientDTO { FullName = patient.FullName };
    }
}
