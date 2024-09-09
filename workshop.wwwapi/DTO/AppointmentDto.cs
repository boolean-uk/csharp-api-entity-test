using Swashbuckle.AspNetCore.Annotations;

namespace workshop.wwwapi.DTO
{
    public class AppointmentDto
    {
        public DateTime dateTime {  get; set; }
        [SwaggerSchema(ReadOnly = true)]
        public AppointmentDoctor Doctor { get; set; }
        [SwaggerSchema(ReadOnly = true)]
        public AppointmentPatient Patient { get; set; }
        [SwaggerSchema(ReadOnly = true)]
        public List<AppointmentMedicine> Medicines { get; set; }

    }
    public class AppointmentDoctor
    {
        public string FullName { get; set; }
    }
    public class AppointmentPatient
    {
        public string FullName { get; set; }
    }
    public class AppointmentMedicine
    {
        public string Name { get; set; }
        public string Instruction { get; set; }
    }

}
