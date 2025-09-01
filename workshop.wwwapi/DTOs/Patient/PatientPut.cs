namespace workshop.wwwapi.DTOs.Patient;

public class PatientPut
{
    public string FullName { get; set; }

    public Models.Patient ToPatient()
    {
        return new Models.Patient {FullName = FullName, Appointments = []};
    }
}