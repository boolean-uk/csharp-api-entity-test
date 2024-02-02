using Microsoft.AspNetCore.Mvc;
using workshop.wwwapi.Models;
using workshop.wwwapi.Models.DTO;
using workshop.wwwapi.Repository;
using workshop.wwwapi.Services;

namespace workshop.wwwapi.Endpoints
{
    public static class PatientEndpoint
    {
        public static void ConfigurePatientEndpoint(this WebApplication app)
        {
            var patientGroup = app.MapGroup("patients");

            patientGroup.MapGet("/", GetAll);
            patientGroup.MapGet("/{id}", Get);
            patientGroup.MapPost("/", Create);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> Get(IPatientRepository repository, int id)
        {
            Patient? patient = await repository.Get(id);

            if (patient == null) 
                return TypedResults.NotFound();

            OutputPatient outputPatient = PatientDtoManager.Convert(patient);
            return TypedResults.Ok(outputPatient);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetAll(IPatientRepository repository)
        {
            IEnumerable<Patient> patients = await repository.Get();

            if (patients.Count() == 0)
                return TypedResults.NotFound();

            IEnumerable<OutputPatient> outputPatient = PatientDtoManager.Convert(patients);
            return TypedResults.Ok(outputPatient);
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        public static async Task<IResult> Create(IPatientRepository repository, InputPatient inputPatient)
        {
            Patient newPatient = new Patient
            {
                FullName = inputPatient.FullName
            };

            Patient? result = await repository.Create(newPatient);

            if (result == null)
                return TypedResults.BadRequest();

            OutputPatient outputPatient = PatientDtoManager.Convert(result);
            return TypedResults.Created("url", outputPatient);
        }
    }
}
