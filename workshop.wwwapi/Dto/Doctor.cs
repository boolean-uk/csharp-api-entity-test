using workshop.wwwapi.Models;

namespace workshop.wwwapi.Repository;

public class DoctorPostDto
{
    public string FullName { get; set; }
}

public class DoctorGetDto
{
    public int Id { get; set; }
    public string FullName { get; set; }
    public IEnumerable<AppointmentWithoutDoctor> Appointments { get; set; }

    public DoctorGetDto() { }

    public DoctorGetDto(Doctor doctor)
    {
        this.Id = doctor.Id;
        this.FullName = doctor.FullName;
        this.Appointments = doctor
            .Appointments.Select(a => new AppointmentWithoutDoctor(a))
            .ToList();
    }
}

public class DoctorShallow
{
    public int Id { get; set; }
    public string FullName { get; set; }

    public DoctorShallow() { }

    public DoctorShallow(Doctor doctor)
    {
        this.Id = doctor.Id;
        this.FullName = doctor.FullName;
    }
}
