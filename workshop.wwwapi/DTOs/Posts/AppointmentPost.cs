using System.ComponentModel.DataAnnotations.Schema;
using workshop.wwwapi.Models;

namespace workshop.wwwapi.DTOs.Posts
{
    public class AppointmentPost
    {
        public int DoctorId { get; set; }
        public int PatientId { get; set; }
    }
}
