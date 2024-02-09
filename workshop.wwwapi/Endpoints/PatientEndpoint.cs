using workshop.wwwapi.Repository;
using workshop.wwwapi.DTO;
using Microsoft.AspNetCore.Mvc;
using workshop.wwwapi.Models;
namespace workshop.wwwapi.Endpoints
{
    public static class PatientEndpoint
    {
        public static void ConfigurePatientEndpoint(this WebApplication app)
        {
            var patientGroup = app.MapGroup("surgery");

            patientGroup.MapGet("/patients", GetPatients);
            patientGroup.MapGet("/patients/{id}", GetPatientById);
            patientGroup.MapPost("/patients", CreatePatient);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetPatients(IRepository repository)
        { 
            var patients = await repository.GetPatients();
            var PatientDTO = new List<PatientDTO>();
            foreach (Patient patient in patients)
            {
                PatientDTO.Add(new PatientDTO(patient));
            }
            return TypedResults.Ok(PatientDTO);
        }

        public static async Task<IResult> GetPatientById(IRepository repository, int id)
        {
            if (id <= 0)
            {
                return TypedResults.BadRequest("Id must be greater than 0");
            }
            if (id == null)
            {
                return TypedResults.NotFound();
            }
            var patient = await repository.GetPatientById(id, PreloadPolicy.PreloadRelations);
            var patientDTO = new PatientDTO(patient);
            return TypedResults.Ok(patientDTO);
        }

        public static async Task<IResult> CreatePatient(CreatePatientPayload payload ,IRepository repository)
        {
            if (string.IsNullOrEmpty(payload.FullName))
            {
                return TypedResults.BadRequest("Full name is required");
            }
            Patient? patient = await repository.CreatePatient(payload.FullName);
            if (patient == null)
            {
                return TypedResults.BadRequest("Patient could not be created");
            }
            return TypedResults.Ok(new PatientResponseDTO(patient));
        }

    }
}