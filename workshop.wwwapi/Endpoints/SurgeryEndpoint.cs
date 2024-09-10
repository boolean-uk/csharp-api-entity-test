using Microsoft.AspNetCore.Mvc;
using workshop.wwwapi.Repository;
using static System.Runtime.InteropServices.JavaScript.JSType;

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
            surgeryGroup.MapGet("/appointments", GetAllAppointments);
            surgeryGroup.MapGet("/appointmentById{id}", GetAppointment);
            surgeryGroup.MapGet("/appointmentbypatient{id}", GetAppointmentByPatient);
            surgeryGroup.MapPost("createappointment{doctorId, patientId}", CreateNewAppointment);
            surgeryGroup.MapPost("createPatient{firstName, LastName}", CreateNewPatient);
            surgeryGroup.MapPost("createDoctor{firstName, LastName}", CreateNewDoctor);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public static async Task<IResult> CreateNewDoctor(IRepository repository, string firstName, string lastName)
        {
            if (firstName == "" || firstName == null || lastName == "" || lastName == null)
            {
                return TypedResults.BadRequest();
            }
            return TypedResults.Ok(await repository.AddDoctor(firstName, lastName));
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public static async Task<IResult> CreateNewPatient(IRepository repository, string firstName, string lastName)
        {
            if (firstName == "" || firstName == null || lastName == "" || lastName == null)
            {
                return TypedResults.BadRequest();
            }
            return TypedResults.Ok(await repository.AddPatient(firstName, lastName));
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> CreateNewAppointment(IRepository repository,int doctorId, int patientId)
        {
            if (!await repository.CheckExists(0, doctorId))
            {
                return TypedResults.NotFound();
            }
            if (!await repository.CheckExists(1, patientId))
            {
                return TypedResults.NotFound();
            }
            return TypedResults.Ok(await repository.CreateAppointment( doctorId, patientId));
        }
       

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> GetAppointmentByPatient(IRepository repository, int id)
        {
            var result = await repository.GetAppointmentsByPatient(id);
            if (result == null)
            {
                return TypedResults.NotFound();
            }
            return TypedResults.Ok(result);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> GetAppointment(IRepository repository, int id)
        {
            var result = await repository.GetAppointment(id);
            if (result == null)
            {
                return TypedResults.NotFound();
            }
            return TypedResults.Ok(result);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetAllAppointments(IRepository repository)
        {
            return TypedResults.Ok(await repository.GetAllAppointments());
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
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> GetAppointmentsByDoctor(IRepository repository, int id)
        {
           var result = await repository.GetAppointmentsByDoctor(id);
            if(result == null)
            {
                return TypedResults.NotFound();
            }
            return TypedResults.Ok(result);
        }
    }
}
