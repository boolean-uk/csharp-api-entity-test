
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using workshop.wwwapi.Models;
using workshop.wwwapi.Repository;

namespace workshop.wwwapi.Endpoints
{
    public static class DoctorEndpoint
    {
        public static void ConfigureDoctorEndpoint(this WebApplication app)
        {
            var doctors = app.MapGroup("/doctors");
            doctors.MapGet("/", GetDoctors);
            doctors.MapPost("/", CreateDoctor);
            doctors.MapGet("/{id}", GetDoctor);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        private static async Task<IResult> GetDoctor(HttpContext context, IRepository<Doctor> repo, int id)
        {
            try
            {
                var p = await DTO.Response.Doctor.Get.DTO(repo, id);
                return TypedResults.Ok(p);
            }
            catch (Exception ex)
            {
                if (ex is KeyNotFoundException) return TypedResults.NotFound($"Doctor with id[{id}] was not found");
                return TypedResults.BadRequest($"Bad request...");
            }
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        private static async Task<IResult> GetDoctors( IRepository<Doctor> repo)
        {
            var p = await DTO.Response.Doctor.Get.DTO(repo);
            
            if (p.Count() == 0) return TypedResults.NotFound($"No doctors was found");
            return TypedResults.Ok(p);
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        private static async Task<IResult> CreateDoctor(HttpContext context, IRepository<Doctor> repo, DTO.Request.Doctor.Create dto)
        {
            Doctor doctors = new()
            {
                FullName = dto.FullName
            };

            var p = await repo.CreateEntry(doctors);
            if (p == null) return TypedResults.BadRequest($"Not a valid DTO");
            return TypedResults.Ok(await DTO.Response.Doctor.Get.DTO(repo,p.Id)); 
        }
    }
}
