using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata;
using workshop.wwwapi.DTO;
using workshop.wwwapi.Models;
using workshop.wwwapi.Repository;

namespace workshop.wwwapi.Endpoints
{
    public static class PatientEndpoints
    { 
        public record CreatePatientPayload(string FullName, string Email);
        public static void ConfigurePatientEndpoint(this WebApplication app)
        {
           app.MapGet("/patients", GetPatients);
            app.MapGet("/patientsbyid/{patientId}", GetPatientById);
            app.MapPost("/createpatient", CreatePatient);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetPatients(IPatientRepository IRepository)
        {
            var patients = await IRepository.GetPatients();
            var patientDTO = new List<PatientResponseDTO>();
            foreach (var patient in patients)
            {
                patientDTO.Add(new PatientResponseDTO(patient));
            }
            //return TypedResults.Ok(patientDTO);
            return TypedResults.Ok(PatientResponseDTO.FromRepository(await IRepository.GetPatients()));
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetPatientById(IPatientRepository IRepository, int patientId)
        {
            return TypedResults.Ok(PatientResponseDTO.FromRepository(await IRepository.GetPatientById(patientId)));
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public static async Task<IResult> CreatePatient(CreatePatientPayload payload, IPatientRepository IRepository)
        {
            if (payload.FullName == null || payload.Email == null)
            {
                return Results.BadRequest("All fields are required.");
            }

           Patient? patient = await IRepository.CreatePatient(payload.FullName, payload.Email);
            if (patient == null)
            {
                return TypedResults.BadRequest("Failed to create student!");
            }

            return TypedResults.Ok(patient);
        }
    }   
}
