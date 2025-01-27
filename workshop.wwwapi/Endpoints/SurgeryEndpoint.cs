using Microsoft.AspNetCore.Mvc;
using workshop.wwwapi.Models;
using workshop.wwwapi.Repository;

namespace workshop.wwwapi.Endpoints
{
    public static class SurgeryEndpoint
    {
        // NOTE: OLD CODE FROM ASSIGNMNET

        //TODO:  add additional endpoints in here according to the requirements in the README.md 
        //public static void ConfigureSurgeryEndpoint(this WebApplication app)
        //{
        //    var surgeryGroup = app.MapGroup("surgery");

        //    surgeryGroup.MapGet("/patients", GetPatients);
        //    surgeryGroup.MapGet("/doctors", GetDoctors);
        //    surgeryGroup.MapGet("/appointmentsbydoctor/{id}", GetAppointmentsByDoctor);
        //}
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //public static async Task<IResult> GetPatients(IRepository<Patient> repository)
        //{ 
        //    return TypedResults.Ok(await repository.GetEntries());
        //}
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //public static async Task<IResult> GetDoctors(IRepository<Doctor> repository)
        //{
        //    return TypedResults.Ok(await repository.GetEntries());
        //}
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //public static async Task<IResult> GetAppointmentsByDoctor(IRepository<Doctor> repository, int id)
        //{
        //    return TypedResults.Ok(await repository.GetAppointmentsByDoctor(id));
        //}
    }
}
