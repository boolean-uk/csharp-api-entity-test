using Swashbuckle.AspNetCore.Annotations;

namespace workshop.wwwapi.DTO
{
    public class DoctorDto
    {
        public string FullName { get; set; }
        [SwaggerSchema(ReadOnly = true)]
        public List<DoctorAppointement> Appointements { get; set; } = new List<DoctorAppointement>();
    }

    public class DoctorAppointement
    {
        public DateTime time { get; set; }
        public DoctorPatient Patient { get; set; }
    }
    public class DoctorPatient
    {
        public string Name { get; set; }
    }
}
