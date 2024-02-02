using Microsoft.AspNetCore.Mvc;
using workshop.wwwapi.Models.DTOs;
using workshop.wwwapi.Repository;

namespace workshop.wwwapi.Endpoints
{
    public static class PatientEndpoint
    {
        public static void ConfigurePatientEndpoint(this WebApplication app)
        {
            var patientGroup = app.MapGroup("patients");
            patientGroup.MapGet("/patients", GetPatients);
            patientGroup.MapGet("/patients/{id}", GetPatientById);
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetPatients(IRepository repository)
        {
            IEnumerable<PatientDTO> result = await repository.GetPatients();
            return TypedResults.Ok(result);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetPatientById(int id, IRepository repository)
        {
            PatientDTO? result = await repository.GetPatientById(id);
            if (result == null) { return TypedResults.NotFound($"Patient with id: {id} was not found"); }
            return TypedResults.Ok(result);
        }
    }
}
