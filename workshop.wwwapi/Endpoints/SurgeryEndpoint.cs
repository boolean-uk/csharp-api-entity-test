using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using workshop.wwwapi.Models;
using workshop.wwwapi.Repository;

namespace workshop.wwwapi.Endpoints
{
    public static class SurgeryEndpoint
    {
        //TODO: Add additional endpoints in here according to the requirements in the README.md 
        public static void ConfigurePatientEndpoint(this WebApplication app)
        {
            var surgeryGroup = app.MapGroup("surgery");
            var patientGroup = app.MapGroup("surgery/patients");
            var doctorGroup = app.MapGroup("surgery/doctors");
            var appointmentGroup = app.MapGroup("surgery/appointments");

            patientGroup.MapGet("", GetPatients);
            patientGroup.MapGet("{id}", GetPatientByID);
            patientGroup.MapPost("", CreatePatient);
            doctorGroup.MapGet("", GetDoctors);
            doctorGroup.MapGet("{id}", GetDoctorByID);
            doctorGroup.MapPost("", CreateDoctor);
            appointmentGroup.MapGet("", GetAppointments);
            appointmentGroup.MapGet("{id}", GetAppointmentsByID);
            appointmentGroup.MapGet("/by_doctor{id}", GetAppointmentsByDoctor);
            appointmentGroup.MapGet("/by_patient{id}", GetAppointmentsByPatient);
            appointmentGroup.MapPost("", CreateAppointment);
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetPatients(IRepository repository)
        { 
            return TypedResults.Ok(await repository.GetPatients());
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetPatientByID(IRepository repository, int id)
        {
            return TypedResults.Ok(await repository.GetPatient(id));
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> CreatePatient(IRepository repository, string patientFullName)
        {
            return TypedResults.Ok(await repository.CreatePatient(patientFullName));
        }


        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetDoctors(IRepository repository)
        {
            return TypedResults.Ok(await repository.GetDoctors());
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetDoctorByID(IRepository repository, int id)
        {
            return TypedResults.Ok(await repository.GetDoctor(id));
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> CreateDoctor(IRepository repository, string doctorFullName)
        {
            return TypedResults.Ok(await repository.CreateDoctor(doctorFullName));
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetAppointmentsByID(IRepository repository, int id)
        {
            return TypedResults.Ok(await repository.GetAppointment(id));
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetAppointments(IRepository repository)
        {
            return TypedResults.Ok(await repository.GetAppointments());
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
        public static async Task<IResult> CreateAppointment(IRepository repository, Appointment appointment)
        {
            return TypedResults.Ok(await repository.CreateAppointment(appointment));
        }
    }
}
