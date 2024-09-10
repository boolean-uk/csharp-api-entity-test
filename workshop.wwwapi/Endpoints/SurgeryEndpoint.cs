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
            surgeryGroup.MapGet("/patient/{id}", GetPatient);
            surgeryGroup.MapPost("/createpatient", CreatePatient);
            surgeryGroup.MapGet("/doctors", GetDoctors);
            surgeryGroup.MapGet("/doctor/{id}", GetDoctor);
            surgeryGroup.MapPost("/createdoctor", CreateDoctor);
            surgeryGroup.MapGet("/appointments", GetAppointments);
            surgeryGroup.MapGet("/appointmentsbydoctorandpatient/{id}", GetAppointmentsByDoctorAndPatientId);
            surgeryGroup.MapGet("/appointmentsbypatient/{id}", GetAppointmentByPatient);
            surgeryGroup.MapGet("/appointmentsbydoctor/{id}", GetAppointmentByDoctor);
            surgeryGroup.MapPost("/createappointment/", CreateAppointment);
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetPatients(IRepository repository)
        { 
            return TypedResults.Ok(await repository.GetPatients());
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetPatient(IRepository repository, int id)
        {
            return TypedResults.Ok(await repository.GetPatient(id));
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> CreatePatient(IRepository repository, string name)
        {
            return TypedResults.Ok(await repository.CreatePatient(name));
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetDoctors(IRepository repository)
        {
            return TypedResults.Ok(await repository.GetDoctors());
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetDoctor(IRepository repository, int id)
        {
            return TypedResults.Ok(await repository.GetDoctor(id));
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> CreateDoctor(IRepository repository, string name)
        {
            return TypedResults.Ok(await repository.CreatePatient(name));
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetAppointments(IRepository repository)
        {
            return TypedResults.Ok(await repository.GetAppointments());
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetAppointmentsByDoctorAndPatientId(IRepository repository, int patientId, int doctorId)
        {
            return TypedResults.Ok(await repository.GetAppointmentByDoctorAndPatient(patientId, doctorId));
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetAppointmentByPatient(IRepository repository, int patientId)
        {
            return TypedResults.Ok(await repository.GetAppointmentByPatient(patientId));
        }
        [ProducesResponseType(StatusCodes.Status200OK)]

        public static async Task<IResult> GetAppointmentByDoctor(IRepository repository, int doctorId)
        {
            return TypedResults.Ok(await repository.GetAppointmentByDoctor(doctorId));
        }
        [ProducesResponseType(StatusCodes.Status200OK)]

        public static async Task<IResult> CreateAppointment(IRepository repository, int patientId, int doctorId)
        {
            return TypedResults.Ok(await repository.CreateAppointment(patientId, doctorId));
        }
    }
}
