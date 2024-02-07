using workshop.wwwapi.Models;

namespace workshop.wwwapi.DTOs
{
    public class PatientDTO
    {
        public PatientDTO() 
        {

        }

        int id;
        string doctorName;
        ICollection<Appointment> appointments;
    }
}
