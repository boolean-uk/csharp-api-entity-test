using Microsoft.AspNetCore.Mvc;
using workshop.wwwapi.Models.DTOs;
using workshop.wwwapi.Repository;

namespace workshop.wwwapi.Endpoints
{
    public static class DoctorEndpoint
    {
        public static void ConfigureDoctorEndpoint(this WebApplication app)
        {
            var doctorGroup = app.MapGroup("doctors");
            doctorGroup.MapGet("/", GetDoctors);
            doctorGroup.MapGet("/{id}", GetDoctorsById);
            doctorGroup.MapPost("/", CreateDoctor);
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetDoctors(IRepository repository)
        {
            IEnumerable<DoctorDTO> result = await repository.GetDoctors();
            return TypedResults.Ok(result);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> GetDoctorsById(int id, IRepository repository)
        {
            DoctorDTO? result = await repository.GetDoctorById(id);
            if (result == null) { return TypedResults.NotFound($"Doctor with id: {id} was not found"); }
            return TypedResults.Ok(result);
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public static async Task<IResult> CreateDoctor(CreateDoctorDTO cDTO, IRepository repository)
        {
            DoctorDTO? result = await repository.CreateDoctor(cDTO);
            if (result == null) { return TypedResults.BadRequest($"Doctor with id: {cDTO.DoctorId} already exists!"); }
            return TypedResults.Created("", result);
        }
    }
}
