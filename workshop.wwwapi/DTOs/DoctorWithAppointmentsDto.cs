using System.Collections.Generic;

namespace workshop.wwwapi.DTOs
{
    public class DoctorWithAppointmentsDto
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public List<AppointmentWithPatientDto> Appointments { get; set; }
    }
}