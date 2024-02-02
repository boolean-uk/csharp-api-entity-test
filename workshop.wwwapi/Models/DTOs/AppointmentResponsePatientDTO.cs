﻿namespace workshop.wwwapi.Models.DTOs
{
    public class AppointmentResponsePatientDTO
    {
        public int PatientId { get; set; }
        public string PatientName { get; set; }
        public List<AppointmentPatientDTO> Appointments { get; set; } = new List<AppointmentPatientDTO>();
    }
}