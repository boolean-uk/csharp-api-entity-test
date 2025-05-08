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

            surgeryGroup.MapGet("/patients", GetPatients);
            surgeryGroup.MapGet("/doctors", GetDoctors);
            surgeryGroup.MapGet("/appointmentsbydoctor/{id}", GetAppointmentsByDoctor);
            surgeryGroup.MapGet("/doctors/{id}", GetDoctor);
            surgeryGroup.MapGet("/appointments", GetAppointments);
            surgeryGroup.MapGet("/appointments/{id}", GetAppointment);
            surgeryGroup.MapGet("/appointments/patient/{id}", GetAppointmentsByPatient);
            surgeryGroup.MapPost("/appointments", CreateAppointments);
        }

        private static async Task<IResult> CreateAppointments(IRepository repository, int month, int day, int doctorId, int patientId)
        {
            return TypedResults.Ok(repository.CreateAppointment(month, day, doctorId, patientId));
        }

        private static async Task<IResult> GetAppointmentsByPatient(IRepository repository, int id)
        {
            return TypedResults.Ok(repository.GetAppointmentsByPatient(id));
        }

        private static async Task<IResult> GetAppointment(IRepository repository, int patientId, int doctorId)
        {
            return TypedResults.Ok(repository.GetAppointment(patientId, doctorId));
        }

        private static async Task<IResult> GetAppointments(IRepository repository)
        {
            return TypedResults.Ok(repository.GetAppointments());
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

        public static async Task<IResult> GetDoctor(IRepository repository, int id)
        {
            return TypedResults.Ok(await repository.GetDoctor(id));
        }
    }
}
