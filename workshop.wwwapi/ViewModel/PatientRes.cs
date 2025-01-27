using workshop.wwwapi.DTOs;

namespace workshop.wwwapi.ViewModel
{
    public class PatientRes
    {
        public List<PatientDTO> Patients { get; set; } = new List<PatientDTO>();
    }
}
