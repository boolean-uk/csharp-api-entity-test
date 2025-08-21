using workshop.wwwapi.DTOs;
using workshop.wwwapi.Models;

namespace workshop.wwwapi.Factories
{
    public static class DoctorFactory
    {
        public static DoctorDto Dto(Doctor doctor)
        {
            var dto = new DoctorDto();
            dto.FullName = doctor.FullName;

            var appointments = new List<AppointmentForDoctorDto>();
            foreach (var appointment in doctor.Appointments)
            {
                appointments.Add(AppointmentFactory.DtoForDoctor(appointment));
            }
            dto.Appointments = appointments;

            return dto;
        }
    }
}
