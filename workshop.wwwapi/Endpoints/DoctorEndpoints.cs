using Microsoft.AspNetCore.Mvc;
using workshop.wwwapi.Models;
using workshop.wwwapi.Repository;
using workshop.wwwapi.DTO;

namespace workshop.wwwapi.Endpoints
{
    public static class DoctorEndpoints
    {
        public static void ConfigureDoctorEndpoint(this WebApplication app)
        {
            var surgeryGroup = app.MapGroup("doctors");

            surgeryGroup.MapGet("/", GetDoctor);
            surgeryGroup.MapGet("/{id}", GetDoctorById);
            surgeryGroup.MapPost("/{doctor}", CreateDoctor);

        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetDoctor(IRepository repository)
        {
            var doctors = await repository.GetDoctors();
            return TypedResults.Ok(doctors);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetDoctorById(int id, IRepository repository)
        {
            var doctor = await repository.GetDoctorById(id);

            return TypedResults.Ok(doctor.ToDoctorDTO);
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        public static async Task<IResult> CreateDoctor(Doctor doctor, IRepository repository)
        {
            var created = await repository.CreateDoctor(doctor);
            return TypedResults.Created($"/doctors/{created.Id}", created.ToDoctorDTO);
        }
    }
}
