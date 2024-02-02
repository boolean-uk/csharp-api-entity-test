using Microsoft.AspNetCore.Mvc;
using workshop.wwwapi.Models;
using workshop.wwwapi.Models.DTO;
using workshop.wwwapi.Repository;
using workshop.wwwapi.Services;

namespace workshop.wwwapi.Endpoints
{
    public static class DoctorEndpoint
    {
        public static void ConfigureDoctorEndpoint(this WebApplication app)
        {
            var doctorGroup = app.MapGroup("doctors");

            doctorGroup.MapGet("/", GetAll);
            doctorGroup.MapGet("/{id}", Get);
            doctorGroup.MapPost("/", Create);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> Get(IDoctorRepository repository, int id)
        {
            Doctor? doctor = await repository.Get(id);

            if (doctor == null)
                return TypedResults.NotFound();

            OutputDoctor outputDoctor = DoctorDtoManager.Convert(doctor);
            return TypedResults.Ok(outputDoctor);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetAll(IDoctorRepository repository)
        {
            IEnumerable<Doctor> doctors = await repository.Get();

            if (doctors.Count() == 0)
                return TypedResults.NotFound();

            IEnumerable<OutputDoctor> outputDoctor = DoctorDtoManager.Convert(doctors);
            return TypedResults.Ok(outputDoctor);
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        public static async Task<IResult> Create(IDoctorRepository repository, InputDoctor inputDoctor)
        {
            Doctor newDoctor = new Doctor
            {
                FullName = inputDoctor.FullName
            };

            Doctor? result = await repository.Create(newDoctor);

            if (result == null)
                return TypedResults.BadRequest();

            OutputDoctor outputDoctor = DoctorDtoManager.Convert(result);
            return TypedResults.Created("url", outputDoctor);
        }
    }
}
