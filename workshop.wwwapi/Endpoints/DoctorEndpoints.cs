using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using workshop.wwwapi.DTO;
using workshop.wwwapi.Exceptions;
using workshop.wwwapi.Models;
using workshop.wwwapi.Repository;

namespace workshop.wwwapi.Endpoints
{
    public static class DoctorEndpoints
    {
        public static string Path { get; private set; } = "doctors";

        public static void ConfigureDoctorsEndpoints(this WebApplication app)
        {
            var group = app.MapGroup(Path);

            group.MapPost("/", CreateDoctor);
            group.MapGet("/", GetDoctors);
            group.MapGet("/{id}", GetDoctor);
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public static async Task<IResult> CreateDoctor(IRepository<Doctor, int> repository, IMapper mapper, DoctorPost entity)
        {
            try
            {
                Doctor doctor = await repository.Add(new Doctor
                {
                    FirstName = entity.FirstName,
                    LastName = entity.LastName,
                });
                return TypedResults.Created($"/{Path}/{doctor.Id}", mapper.Map<DoctorView>(doctor));
            }
            catch (Exception ex)
            {
                return TypedResults.Problem(ex.Message);
            }
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public static async Task<IResult> GetDoctors(IRepository<Doctor, int> repository, IMapper mapper)
        {
            try
            {
                IEnumerable<Doctor> doctors = await repository.GetAllWithIncludes(
                    q => q.Include(x => x.Appointments).ThenInclude(x => x.Patient)
                );
                return TypedResults.Ok(mapper.Map<List<DoctorView>>(doctors));
            }
            catch (Exception ex)
            {
                return TypedResults.Problem(ex.Message);
            }
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public static async Task<IResult> GetDoctor(IRepository<Doctor, int> repository, IMapper mapper, int id)
        {
            try
            {
                Doctor doctor = await repository.FindWithIncludes((d => d.Id == id), q => q.Include(x => x.Appointments).ThenInclude(x => x.Patient));
                return TypedResults.Ok(mapper.Map<DoctorView>(doctor));
            }
            catch (IdNotFoundException ex)
            {
                return TypedResults.NotFound(new { ex.Message });
            }
            catch (Exception ex)
            {
                return TypedResults.Problem(ex.Message);
            }
        }
    }
}
