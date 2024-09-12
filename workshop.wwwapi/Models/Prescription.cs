using workshop.wwwapi.Models;

public class Prescription
{
    public int Id { get; set; } // Primary Key
    public int DoctorId { get; set; } // Foreign Key to Doctor
    public int PatientId { get; set; } // Foreign Key to Patient

    public List<PrescribedMedicine> PrescribedMedicineList { get; set; } = new List<PrescribedMedicine>();

    public Doctor Doctor { get; set; }
    public Patient Patient { get; set; }
}
