using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using workshop.wwwapi.DTOs.Person;
using workshop.wwwapi.Models;

namespace workshop.wwwapi.DTOs.Patient
{
    public class AppointmentsForPatientDTO
    {
        public int Id { get; set; }
        public DateTime AppointmentDate { get; set; }

        public NestedPersonForAppointmentDTO Doctor { get; set; }
    }
}
