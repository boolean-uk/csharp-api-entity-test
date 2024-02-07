using System.Text.Json.Serialization;
using workshop.wwwapi.Models;

namespace workshop.wwwapi.DTO
{
    public class AppointmentDto
    {
        public DateTime Booking {  get; set; }
        public int DoctorId { get; set; }
        public string DoctorName { get; set; }
        public int PatientId { get; set; }
        public string PatientName { get; set;}

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public AppointmentType Type { get; set; }
    }
}
