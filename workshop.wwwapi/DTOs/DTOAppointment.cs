using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;

namespace workshop.wwwapi.DTOs
{
    public class DTOAppointment
    {
        public DateTime AppointmentDate {  get; set; }
        public string AppointmentType { get; set; }
        public string Doctor { get; set; }
        public string Patient { get; set; }

    }
}
