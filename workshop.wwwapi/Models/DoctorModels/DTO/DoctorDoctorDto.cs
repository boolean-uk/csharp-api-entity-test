using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using workshop.wwwapi.Models.AppointmentModels;

namespace workshop.wwwapi.Models.DoctorModels.DTO
{

    public class DoctorDoctorDto
    {
        public int DoctorId { get; set; }
        public string Name { get; set; }
        public ICollection<AppointmentDoctorDto> Appointments { get; set; }

        public static DoctorDoctorDto Create(Doctor doctor)
        {

            return new DoctorDoctorDto()
            {

                DoctorId = doctor.Id,
                Name = doctor.FullName,
                Appointments = doctor.Appointments.Select(AppointmentDoctorDto.Create).ToList()
            };
        }
    }
}
