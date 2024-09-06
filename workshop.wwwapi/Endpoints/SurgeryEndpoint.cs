using Microsoft.AspNetCore.Mvc;
using workshop.wwwapi.Models;
using workshop.wwwapi.Repository;
using workshop.wwwapi.ViewModels;

namespace workshop.wwwapi.Endpoints
{
    public static class SurgeryEndpoint
    {
        //TODO:  add additional endpoints in here according to the requirements in the README.md 
        public static void ConfigurePatientEndpoint(this WebApplication app)
        {
            var surgeryGroup = app.MapGroup("surgery");

            surgeryGroup.MapGet("/patients", GetPatients);
            surgeryGroup.MapPost("/patients/{patient}", CreatePatient);
            surgeryGroup.MapGet("/doctors", GetDoctors);
            surgeryGroup.MapGet("/appointmentsbydoctor/{id}", GetAppointmentsByDoctor);
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetPatients(IRepository repository)
        { 
            return TypedResults.Ok(await repository.GetPatients());
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetDoctors(IRepository repository)
        {
            return TypedResults.Ok(await repository.GetPatients());
        }
        [ProducesResponseType(StatusCodes.Status201Created)]
        public static async Task<IResult> CreatePatient(IRepository repository, PatientPostModel patientPost)
        {
            Patient patient = new() { FullName = patientPost.FullName};
            patient = repository.CreatePatient(patient).Result;
            return TypedResults.Created($"https://localhost:7235/surgery/patients/{patient.Id}");
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetAppointmentsByDoctor(IRepository repository, int id)
        {
            return TypedResults.Ok(await repository.GetAppointmentsByDoctor(id));
        }
    }
}
