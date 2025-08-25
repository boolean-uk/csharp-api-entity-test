using System.ComponentModel.DataAnnotations.Schema;
using workshop.wwwapi.Models;

namespace workshop.wwwapi.DTOs.AppointmentGets
{
    public class AppointmentGet
    {
        public int Id { get; set; }
        public DateTime Booking { get; set; }
        public int DoctorId { get; set; }
        public AppointmentDoctorGet Doctor { get; set; }
        public int PatientId { get; set; }
        public AppointmentPatientGet Patient { get; set; }
    }
}
