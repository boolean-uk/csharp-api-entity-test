using Swashbuckle.AspNetCore.Annotations;

namespace workshop.wwwapi.DTO
{
    public class AppointmentDto
    {
        public DateTime dateTime {  get; set; }
        [SwaggerSchema(ReadOnly = true)]
        public AppointmentDoctor doctor { get; set; }
        [SwaggerSchema(ReadOnly = true)]
        public AppointmentPatient patient { get; set; }

    }
    public class AppointmentDoctor
    {
        public string FullName { get; set; }
    }
    public class AppointmentPatient
    {
        public string FullName { get; set; }
    }

}
