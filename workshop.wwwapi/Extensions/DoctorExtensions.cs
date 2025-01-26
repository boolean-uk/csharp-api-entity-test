using Microsoft.EntityFrameworkCore.Query.Internal;
using System.ComponentModel.DataAnnotations;
using workshop.wwwapi.Data;
using workshop.wwwapi.DTO;
using workshop.wwwapi.Models;

namespace workshop.wwwapi.Extensions
{
    public static class DoctorExtensions
    {

        public static DoctorDTO ToDTO(this Doctor doctor) 
        {
            return new DoctorDTO
            {
                Id = doctor.Id,
                FullName = doctor.FullName,
                Appointments = [],
            };
        }

        public static DoctorsAppointmentDTO ToAppointmentDTO(this Appointment appointment, Patient patient)
        {
            return new DoctorsAppointmentDTO
            {
                PatientId = patient.Id,
                PatientName = patient.FullName
            };
        }
    }
}
