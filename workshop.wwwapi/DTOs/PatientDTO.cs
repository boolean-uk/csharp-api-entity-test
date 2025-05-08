using workshop.wwwapi.Models;

namespace workshop.wwwapi.DTOs
{
    public class PatientDTO
    {
        public PatientDTO() 
        {

        }

        public int id;
        public string Name;
        public string DoctorName;
        public ICollection<Appointment> Appointments;
    }
}
