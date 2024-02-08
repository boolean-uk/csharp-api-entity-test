using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace workshop.wwwapi.Models.ModelsDto
{

    public class AppointmentDto
    {

        public int DoctorId { get; set; }
        public int PatientId { get; set; }
        public DateTime Booking { get; set; }
        public DoctorDto Doctor { get; set; }
        public PatientDto Patient { get; set; }
    }
}
