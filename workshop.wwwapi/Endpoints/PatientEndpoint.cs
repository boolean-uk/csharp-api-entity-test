
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using workshop.wwwapi.Models;
using workshop.wwwapi.Models.Interface;
using workshop.wwwapi.Repository;

namespace workshop.wwwapi.Endpoints
{
    public static class PatientEndpoint
    {
        public static void ConfigurePatientEndpoint(this WebApplication app)
        {
            var patients = app.MapGroup("/patients");
            patients.MapGet("/", GetPatients);
            patients.MapPost("/", CreatePatient);
            patients.MapGet("/{id}", GetPatient);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        private static async Task<IResult> GetPatient(HttpContext context, IRepository<Patient> repo, int id)
        {
            try
            {
                var p = await DTO.Response.Patient.Get.DTO(repo, id);
                return TypedResults.Ok(p);
            }
            catch (Exception ex)
            {
                if (ex is KeyNotFoundException) return TypedResults.NotFound($"Patient with id[{id}] was not found");
                return TypedResults.BadRequest($"Bad request...");
            }
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        private static async Task<IResult> GetPatients(HttpContext context, IRepository<Patient> repo)
        {
            var p = await DTO.Response.Patient.Get.DTO(repo);
            if (p.Count() == 0) return TypedResults.NotFound($"No patients was found");

            return TypedResults.Ok(p);
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        private static async Task<IResult> CreatePatient(HttpContext context, IRepository<Patient> repo, DTO.Request.Patient.Create dto)
        {
            Patient patient = new()
            {
                FullName = dto.FullName
            };

            var p = await repo.CreateEntry(patient);
            if (p == null) return TypedResults.BadRequest($"Not a valid DTO");

            return TypedResults.Ok(await DTO.Response.Patient.Get.DTO(repo,p.Id)); 
        }
    }
}
