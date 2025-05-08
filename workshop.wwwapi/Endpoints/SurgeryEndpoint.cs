using Microsoft.AspNetCore.Mvc;
using workshop.wwwapi.Repository;
using workshop.wwwapi.DTO;
using workshop.wwwapi.Models;

namespace workshop.wwwapi.Endpoints
{
    public static class SurgeryEndpoint
    {
        //TODO:  add additional endpoints in here according to the requirements in the README.md 
        public static void ConfigureSurgeryEndpoint(this WebApplication app)
        {
            var surgeryGroup = app.MapGroup("surgery");

            surgeryGroup.MapGet("/doctors", GetDoctors);
            surgeryGroup.MapGet("/appointmentsbydoctor/{id}", GetAppointmentsByDoctor);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetDoctors(IDoctorRepository iDoctorRepository)
        {
            var doctors = await iDoctorRepository.GetDoctors();
            var doctorDTO = new List<DoctorResponseDTO>();
            foreach (var doctor in doctors)
            {
                doctorDTO.Add(new DoctorResponseDTO(doctor));
            }
            //return TypedResults.Ok(patientDTO);
            return TypedResults.Ok(DoctorResponseDTO.FromRepository(await iDoctorRepository.GetDoctors()));
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetAppointmentsByDoctor(IAppointmentRepository repository, int id)
        {
            var appointments = await repository.GetAppointmentsByDoctor(id);
            if (appointments == null || !appointments.Any())
            {
                return TypedResults.NotFound($"Appointment with id: {id}, is not found");
            }
            return TypedResults.Ok(await repository.GetAppointmentsByDoctor(id));
        }
    }
}
