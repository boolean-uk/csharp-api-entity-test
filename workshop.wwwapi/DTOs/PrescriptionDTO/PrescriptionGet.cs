using workshop.wwwapi.DTOs.AppointmentDTO;

namespace workshop.wwwapi.DTOs.PrescriptionDTO
{
    public class PrescriptionGet
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public AppointmentGet Appointment { get; set; }
        //public AppointmentGet Appointment { get; set; } = new AppointmentGet();
        //public class AppointmentGet
        //{
        //    public int AppointmentId { get; set; }
        //    public string AppointmentName { get; set; }

        //}
    }
}
