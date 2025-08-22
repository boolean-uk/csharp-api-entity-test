using Microsoft.AspNetCore.Mvc;
using workshop.wwwapi.Models;
using workshop.wwwapi.Repository;
using workshop.wwwapi.DTO;

namespace workshop.wwwapi.Endpoints
{
    public static class PatientEndpoints
    {
        public static void ConfigurePatientEndpoint(this WebApplication app)
        {
            var surgeryGroup = app.MapGroup("patients");

            surgeryGroup.MapGet("/", GetPatients);
            surgeryGroup.MapGet("/{id}", GetPatientById);
            surgeryGroup.MapPost("/{patient}", CreatePatient);

        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetPatients(IRepository repository)
        {
            var patients = await repository.GetPatients();
            return TypedResults.Ok(patients);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetPatientById(int id, IRepository repository)
        {
            var patient = await repository.GetPatientById(id);

            return TypedResults.Ok(patient.ToPatientDTO);
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        public static async Task<IResult> CreatePatient(Patient patient, IRepository repository)
        {
            var created = await repository.CreatePatient(patient);
            return TypedResults.Created($"/patients/{created.Id}", created.ToPatientDTO);
        }
    }
}
