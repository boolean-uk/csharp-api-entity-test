using workshop.wwwapi.DTOs;
using workshop.wwwapi.Models;

namespace workshop.wwwapi.Factories
{
    public static class PatientFactory
    {
        public static PatientDto Dto(Patient patient)
        {
            var dto = new PatientDto();
            dto.FullName = patient.FullName;

            var appointments = new List<AppointmentForPatientDto>();
            foreach (var appointment in patient.Appointments)
            {
                appointments.Add(AppointmentFactory.DtoForPatient(appointment));
            }
            dto.Appointments = appointments;

            return dto;
        }
    }
}
