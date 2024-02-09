using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace workshop.wwwapi.Models.PatientModels.DTO;


public class AppointmentPatientDto
{
    public DateTime Booking { get; set; }
    public DoctorPatientDto Doctor { get; set; }
}
