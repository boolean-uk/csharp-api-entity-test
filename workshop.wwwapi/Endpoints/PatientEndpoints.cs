using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using workshop.wwwapi.DTO;
using workshop.wwwapi.Exceptions;
using workshop.wwwapi.Models;
using workshop.wwwapi.Repository;

namespace workshop.wwwapi.Endpoints
{
    public static class PatientEndpoints
    {
        public static string Path { get; private set; } = "patients";

        public static void ConfigurePatientsEndpoints(this WebApplication app)
        {
            var group = app.MapGroup(Path);

            group.MapPost("/", CreatePatient);
            group.MapGet("/", GetPatients);
            group.MapGet("/{id}", GetPatient);
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public static async Task<IResult> CreatePatient(IRepository<Patient, int> repository, IMapper mapper, PatientPost entity)
        {
            try
            {
                Patient patient = await repository.Add(new Patient
                {
                    FirstName = entity.FirstName,
                    LastName = entity.LastName,
                });
                return TypedResults.Created($"/{Path}/{patient.Id}", mapper.Map<PatientView>(patient));
            }
            catch (Exception ex)
            {
                return TypedResults.Problem(ex.Message);
            }
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public static async Task<IResult> GetPatients(IRepository<Patient, int> repository, IMapper mapper)
        {
            try
            {
                IEnumerable<Patient> patients = await repository.GetAllWithIncludes(
                    q => q.Include(x => x.Appointments).ThenInclude(x => x.Doctor)
                );
                return TypedResults.Ok(mapper.Map<List<PatientView>>(patients));
            }
            catch (Exception ex)
            {
                return TypedResults.Problem(ex.Message);
            }
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public static async Task<IResult> GetPatient(IRepository<Patient, int> repository, IMapper mapper, int id)
        {
            try
            {
                Patient patient = await repository.FindWithIncludes((p => p.Id == id), q => q.Include(x => x.Appointments).ThenInclude(x => x.Doctor));
                return TypedResults.Ok(mapper.Map<PatientView>(patient));
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
