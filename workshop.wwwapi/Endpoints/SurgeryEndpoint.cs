using Microsoft.AspNetCore.Mvc;
using workshop.wwwapi.Dto;
using workshop.wwwapi.Repository;

namespace workshop.wwwapi.Endpoints
{
    public static class SurgeryEndpoint
    {
        //TODO:  add additional endpoints in here according to the requirements in the README.md 
        public static void ConfigurePatientEndpoint(this WebApplication app)
        {
            var surgeryGroup = app.MapGroup("surgery");

            surgeryGroup.MapGet("/patients", GetPatients);
            surgeryGroup.MapGet("/patients/{id}", GetPatientById);
            surgeryGroup.MapPost("/patients", CreatePatient);
            surgeryGroup.MapGet("/doctors", GetDoctors);
            surgeryGroup.MapGet("/appointmentsbydoctor/{id}", GetAppointmentsByDoctor);
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetPatients(IRepository repository)
        {
            var patients = await repository.GetPatients();

            if (patients.Any())
            {
                return TypedResults.Ok(patients);
            }
            else
            {
                return Results.NotFound("No patients found.");
            }
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> GetPatientById(IRepository repository, int id)
        {
            var patient = await repository.GetPatientById(id);

            if (patient != null)
            {
                return TypedResults.Ok(patient);
            }
            else
            {
                return Results.NotFound($"Patient with ID {id} not found.");
            }
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public static async Task<IResult> CreatePatient(IRepository repository, [FromBody] CreatePatientDto createPatientDto)
        {
            var createdPatient = await repository.CreatePatient(createPatientDto);

            if (createdPatient != null)
            {
                return TypedResults.Ok(createdPatient);
            }
            else
            {
                return Results.BadRequest("Failed to create the patient.");
            }
        }


        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetDoctors(IRepository repository)
        {
            var doctors = await repository.GetDoctors();

            if (doctors.Any())
            {
                return TypedResults.Ok(doctors);
            }
            else
            {
                return Results.NotFound("No doctors found.");
            }
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetAppointmentsByDoctor(IRepository repository, int id)
        {
            var appointments = await repository.GetAppointmentsByDoctor(id);

            if (appointments.Any())
            {
                return TypedResults.Ok(appointments);
            }
            else
            {
                return Results.NotFound($"No appointments found for doctor with ID {id}.");
            };
        }
    }
}
