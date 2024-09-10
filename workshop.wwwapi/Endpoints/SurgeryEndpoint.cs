using Microsoft.AspNetCore.Mvc;
using workshop.wwwapi.DTO;
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
            surgeryGroup.MapGet("/patient/{id}", GetPatient);
            surgeryGroup.MapGet("/doctor/{id}", GetDoctor);
            surgeryGroup.MapGet("/appointmentsbypatient/{id}", GetAppointmentsByPatient);
            surgeryGroup.MapPost("/doctors/{FullName}", AddDoctor);
            surgeryGroup.MapPost("/appointments/{doctorId}/{patientId}", AddAppointment);
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetPatients(IRepository repository)
        { 
            return TypedResults.Ok(await repository.GetPatients());
        }
        
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetPatient(IRepository repository, int id)
        {
            return TypedResults.Ok(await repository.GetPatientById(id));
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetDoctors(IRepository repository)
        {
            return TypedResults.Ok(await repository.GetDoctors());
        }
        public static async Task<IResult> GetDoctor(IRepository repository, int id)
        {
            return TypedResults.Ok(await repository.GetDoctorById(id));
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetAppointmentsByDoctor(IRepository repository, int id)
        {
            return TypedResults.Ok(await repository.GetAppointmentsByDoctor(id));
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetAppointmentsByPatient(IRepository repository, int id)
        {
            return TypedResults.Ok(await repository.GetAppointmentsByPatient(id));
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> AddDoctor(IRepository repository,  string doctor)
        {
            return TypedResults.Ok(await repository.AddDoctor(doctor));
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> AddAppointment(IRepository repository, int doctorId, int patientId)
        {
            return TypedResults.Ok(await repository.AddAppointment(doctorId, patientId));
        }
    }
}
