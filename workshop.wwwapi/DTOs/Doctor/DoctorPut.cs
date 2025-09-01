namespace workshop.wwwapi.DTOs.Doctor;

public class DoctorPut
{
    public string FullName { get; set; }

    public Models.Doctor ToDoctor()
    {
        return new Models.Doctor()
        {
            FullName = FullName,
            Appointments = [],
        };
    }
}