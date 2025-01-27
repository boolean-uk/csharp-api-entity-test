using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using workshop.wwwapi.DTO;
using workshop.wwwapi.Exceptions;
using workshop.wwwapi.Models;
using workshop.wwwapi.Repository;

namespace workshop.wwwapi.Endpoints
{
    public static class PatientsEnpoint
    {
        //TODO:  add additional endpoints in here according to the requirements in the README.md 
        public static void ConfigurePatientsEndpoint(this WebApplication app)
        {
            var group = app.MapGroup("patients");

            group.MapGet("/", GetPatients);
            group.MapGet("/{id}", GetPatientById);
            group.MapPost("/", CreatePatient);

        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public static async Task<IResult> GetPatients(IRepository<Patient> repository, IMapper mapper)
        {
            try
            {
                var patients = await repository.GetAll();

                if (!patients.Any()) return TypedResults.NotFound();

                return TypedResults.Ok(mapper.Map<IEnumerable<PatientDTO>>(patients));
            }
            catch (Exception ex) 
            {
                var errorResponse = new ErrorResponse
                {
                    Message = "An unexpected error occurred while processing the request.",
                    Detail = ex.Message
                };

                return TypedResults.InternalServerError(errorResponse);
            }
           
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public static async Task<IResult> GetPatientById(IRepository<Patient> repository, IMapper mapper, int id)
        {
            try
            {
                var patient = await repository.GetWithCustomQuery(p => p.Id == id, include: query => query.Include(p => p.Appointments).ThenInclude(a => a.Doctor));

                if (patient == null) return TypedResults.NotFound($"No patient with id:{id} was found.");

                return TypedResults.Ok(mapper.Map<PatientWithAppointmentsDTO>(patient));
            }
            catch (Exception ex)
            {
                var errorResponse = new ErrorResponse
                {
                    Message = "An unexpected error occurred while processing the request.",
                    Detail = ex.Message
                };

                return TypedResults.InternalServerError(errorResponse);
            }

        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public static async Task<IResult> CreatePatient(IRepository<Patient> repository, IMapper mapper, PatientDTO entity)
        {
            try
            {
                Patient newPatient = new Patient();
                newPatient.FullName = entity.FullName;

                var patient = await repository.Add(newPatient);

                return TypedResults.Created($"https://localhost:7235/patients/", mapper.Map<PatientDTO>(patient));
            }
            catch (Exception ex)
            {
                var errorResponse = new ErrorResponse
                {
                    Message = "An unexpected error occurred while processing the request.",
                    Detail = ex.Message
                };

                return TypedResults.InternalServerError(errorResponse);
            }

        }

    }
}
