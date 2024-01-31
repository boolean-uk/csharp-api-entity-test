using Microsoft.AspNetCore.Mvc;
using workshop.wwwapi.Data.DTO;
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
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetPatients(IRepository repository)
        { 
            return TypedResults.Ok(PatientDTOResponse.FromRepository(await repository.GetPatients()));
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetDoctors(IRepository repository)
        {
            return TypedResults.Ok(DoctorDTOResponse.FromRepository(await repository.GetDoctors()));
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetAppointmentsByDoctor(IRepository repository, int id)
        {
            if(id == 0 || id < 0)
                return Results.BadRequest("Requires a positive ID");
            
            IEnumerable<Appointment> appointment = await repository.GetAppointmentsByDoctor(id);
            if(appointment == null) {
                return Results.NotFound("No Appointments Found with that ID");
            }
            return TypedResults.Ok(DoctorAppointmentDTO.FromRepository(appointment));
        }
    }
}
