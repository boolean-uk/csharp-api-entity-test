using Microsoft.AspNetCore.Mvc;
using workshop.wwwapi.Models.Payloads;
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
            surgeryGroup.MapGet("/doctors", GetDoctors);
            surgeryGroup.MapGet("/appointmentsbydoctor/{id}", GetAppointmentsByDoctor);
            surgeryGroup.MapGet("/patients/{id}", GetPatientById);
            surgeryGroup.MapPost("/patients/{id}", AddPatient);
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetPatients(IRepository repository)
        {
            return TypedResults.Ok(await repository.GetPatients());
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetDoctors(IRepository repository)
        {
            return TypedResults.Ok(await repository.GetDoctors());
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetAppointmentsByDoctor(IRepository repository, int id)
        {
            return TypedResults.Ok(await repository.GetAppointmentsByDoctor(id));
        }

        public static async Task<IResult> GetPatientById(IRepository repository, int id)
        {
            var patient = repository.GetPatientById(id);
            return patient == null ? TypedResults.BadRequest("Patient not found") : TypedResults.Ok(patient);
        }

        public static async Task<IResult> AddPatient(IRepository repository, PatientPayload payload)
        {
            if (string.IsNullOrWhiteSpace(payload.fullname)) { return TypedResults.BadRequest("Patient must have a name"); }
            var patient = await repository.AddPatient(payload.fullname);

            return patient == null ?
                TypedResults.BadRequest("Patient was not added") :
                TypedResults.Created($"surgery/patients/{patient.Id}", patient);

        }
    }
}
