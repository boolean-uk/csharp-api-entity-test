using workshop.wwwapi.Models;

namespace workshop.wwwapi.ViewModel
{
    public class CreatePrescription
    {
        public int DoctorId { get; set; }
        public int PatientId { get; set; }
        public DateTime IssueDate { get; set; }
    }
}
