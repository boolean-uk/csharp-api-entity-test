namespace workshop.wwwapi.Models.DTOs;

public class DoctorDTO
{
    public string FullName { get; set; }

    public static DoctorDTO ToDTO(Doctor doctor)
    {
        return new DoctorDTO() { FullName = doctor.FullName };
    }
}
