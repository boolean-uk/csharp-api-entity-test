using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using workshop.wwwapi.Models;
using workshop.wwwapi.Repository;

namespace workshop.wwwapi.Endpoints
{
    public static class SurgeryEndpoint
    {
        //TODO:  add additional endpoints in here according to the requirements in the README.md 
        public static void ConfigurePatientEndpoint(this WebApplication app)
        {
            var surgeryGroup = app.MapGroup("surgery");

            surgeryGroup.MapGet("/patients", GetPatients);
            surgeryGroup.MapGet("/patients{id}", GetPatient);
            surgeryGroup.MapGet("/doctors", GetDoctors);
            surgeryGroup.MapGet("/appointmentsbydoctor/{id}", GetAppointmentsByDoctor);
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetPatients(IRepository repository, IMapper mapper)
        {
            var patients = await repository.GetPatients();
            var patientDtos = mapper.Map<IEnumerable<GetPatientDTO>>(patients);

            return TypedResults.Ok(patientDtos);
        }

        public static async Task<IResult> GetPatient(int id, IRepository repository, IMapper mapper)
        {
            Patient patient = null;

            try
            {
                patient = await repository.GetPatient(id);
            }
            catch (Exception ex)
            {
                return TypedResults.NotFound(ex.Message);
            }
            
            var patientDto = mapper.Map<GetPatientDTO>(patient);

            return TypedResults.Ok(patientDto);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetDoctors(IRepository repository)
        {
            return TypedResults.Ok(await repository.GetPatients());
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetAppointmentsByDoctor(IRepository repository, int id)
        {
            
            return TypedResults.Ok(await repository.GetAppointmentsByDoctor(id));
        }
    }
}
