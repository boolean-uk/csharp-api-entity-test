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

            surgeryGroup.MapGet("/doctors", GetDoctors);
            surgeryGroup.MapGet("/doctors/{id}", GetDoctorById);
            surgeryGroup.MapPost("/doctors/{id}", AddDoctor);
            surgeryGroup.MapGet("/appointmentsbydoctor/{id}", GetAppointmentsByDoctor);
            surgeryGroup.MapGet("/patients", GetPatients);
            surgeryGroup.MapGet("/patients/{id}", GetPatientById);
            surgeryGroup.MapPost("/patients/{id}", AddPatient);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetDoctors(IRepository repository)
        {
            return TypedResults.Ok(await repository.GetDoctors());
        }
        public static async Task<IResult> GetDoctorById(IRepository repository, int id)
        {
            return TypedResults.Ok(await repository.GetDoctors());
        }
        public static async Task<IResult> AddDoctor(IRepository repository, NamePayload payload)
        {
            if (string.IsNullOrWhiteSpace(payload.fullname)) { return TypedResults.BadRequest("Patient must have a name"); }
            var doctor = await repository.AddDoctor(payload.fullname);

            return doctor == null ?
                TypedResults.BadRequest("Doctor was not added") :
                TypedResults.Created($"surgery/doctors/{doctor.Id}", doctor);

        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetAppointmentsByDoctor(IRepository repository, int id)
        {
            return TypedResults.Ok(await repository.GetAppointmentsByDoctor(id));
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetPatients(IRepository repository)
        {
            return TypedResults.Ok(await repository.GetPatients());
        }

        public static async Task<IResult> GetPatientById(IRepository repository, int id)
        {
            var patient = repository.GetPatientById(id);
            return patient == null ? TypedResults.BadRequest("Patient not found") : TypedResults.Ok(patient);
        }

        public static async Task<IResult> AddPatient(IRepository repository, NamePayload payload)
        {
            if (string.IsNullOrWhiteSpace(payload.fullname)) { return TypedResults.BadRequest("Patient must have a name"); }
            var patient = await repository.AddPatient(payload.fullname);

            return patient == null ?
                TypedResults.BadRequest("Patient was not added") :
                TypedResults.Created($"surgery/patients/{patient.Id}", patient);

        }
    }
}
