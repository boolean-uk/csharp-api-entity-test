using Microsoft.AspNetCore.Mvc;
using workshop.wwwapi.Models;
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
            surgeryGroup.MapPost("/patients", CreatePatient);
            surgeryGroup.MapGet("/patients/{id}", GetPatient);
            surgeryGroup.MapPost("/appointments", AddAppointment);
            surgeryGroup.MapGet("/doctors/{id}", GetDoctor);
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
        public static async Task<IResult> GetPatient(IRepository repository, int patientId)
        {
            return TypedResults.Ok(await repository.GetPatient(patientId));
        }
        public static async Task<IResult> CreatePatient(IRepository repository, string fullName)
        {
            return TypedResults.Ok(await repository.CreatePatient(fullName));
        }
        public static async Task<IResult> GetDoctor(IRepository repository, int patientId)
        {
            return TypedResults.Ok(await repository.GetDoctor(patientId));
        }
        public static async Task<IResult> AddAppointment(IRepository repository, int patientId, int doctorId, DateTime appointmentDate)
        {

            Patient? patient = await repository.GetPatient(patientId);
            if(patient == null) { return TypedResults.NotFound(); }

            Doctor? doctor = await repository.GetDoctor(doctorId);
            if (doctor == null) { return TypedResults.NotFound(); }

            return TypedResults.Ok(await repository.AddAppointment(patient, doctor, appointmentDate.ToUniversalTime()));
        }
    }
}
