using Microsoft.AspNetCore.Mvc;
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
            surgeryGroup.MapGet("/doctor/{id}", GetDoctor);
            surgeryGroup.MapGet("/createdoctor{Name}", CreateDoctor);


            surgeryGroup.MapGet("/appointmentsbydoctor/{id}", GetAppointmentsByDoctor);
            surgeryGroup.MapGet("/appointments", GetAppointments);

            surgeryGroup.MapGet("/patient{id}", GetPatient);
            surgeryGroup.MapGet("/patients", GetPatients);
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetPatients(IRepository repository)
        { 
            return TypedResults.Ok(await repository.GetPatients());
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetAppointments(IRepository repository)
        {
            return TypedResults.Ok(await repository.GetAppointments());
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
        public static async Task<IResult> GetPatient(IRepository repo , int id)
        {
            return TypedResults.Ok(await repo.GetPatient(id));
        }
        public static async Task<IResult> CreateDoctor (IRepository repository, string name)
        {
            return TypedResults.Ok(await repository.CreateDoctor(name));
        }
        public static async Task<IResult> GetDoctor(IRepository repository, int id)
        {
            return TypedResults.Ok(await repository.GetDoctor(id));
        }
    }
}
