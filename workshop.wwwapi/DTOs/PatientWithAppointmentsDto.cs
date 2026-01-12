using System.Collections.Generic;

namespace workshop.wwwapi.DTOs
{
    // each appointment of a patient should the patients id, name and appointments
    public class PatientWithAppointmentsDto
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public List<AppointmentWithDoctorDto> Appointments { get; set; }
    }
}