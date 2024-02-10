using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using workshop.wwwapi.Models.DoctorModels;

namespace workshop.wwwapi.Models.AppointmentModels.DTO
{
    public class DoctorAppointmentDto
    {
        public int DoctorId { get; set; }
        public string Name { get; set; }

        public static DoctorAppointmentDto Create(Doctor doctor)
        {
            return new DoctorAppointmentDto()
            {
                DoctorId = doctor.Id,
                Name = doctor.FullName,
            };
        }
    }
}