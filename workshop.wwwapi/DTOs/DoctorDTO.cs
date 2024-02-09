using workshop.wwwapi.Models;

namespace workshop.wwwapi.DTOs
{
    public class DoctorDTO
    {
        int id;
        string doctorName;
        ICollection<Appointment> appointments;
    }
}
