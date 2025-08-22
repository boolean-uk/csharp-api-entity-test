using Microsoft.AspNetCore.Mvc;
using workshop.wwwapi.Models;
using workshop.wwwapi.Repository;
using workshop.wwwapi.DTO;

namespace workshop.wwwapi.Endpoints
{
    public static class AppointmentEndpoints
    {
        public static void ConfigureAppointmentEndpoint(this WebApplication app)
        {
            var surgeryGroup = app.MapGroup("appointments");

            surgeryGroup.MapGet("/", GetAppointments);
            surgeryGroup.MapGet("/{patientId}/{doctorId}", GetAppointmentById);
            surgeryGroup.MapGet("/doctorId/{doctorId}", GetAppointmentByDoctor);
            surgeryGroup.MapGet("/patientId/{patientId}", GetAppointmentByPatient);
            surgeryGroup.MapPost("/", CreateAppointment);

        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetAppointments(IRepository repository)
        {
            var appointments = await repository.GetAppointments();
            return TypedResults.Ok(appointments);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetAppointmentById(int patientId, int doctorId, IRepository repository)
        {
            var appointment = await repository.GetAppointmentById(patientId, doctorId);

            return TypedResults.Ok(appointment.ToAppointmentDTO);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetAppointmentByDoctor(int doctorId, IRepository repository)
        {
            var appointment = await repository.GetAppointmentsByDoctor(doctorId);

            return TypedResults.Ok(appointment.ToAppointmentDTO);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetAppointmentByPatient(int patientId, IRepository repository)
        {
            var appointment = await repository.GetAppointmentsByPatient(patientId);

            return TypedResults.Ok(appointment.ToAppointmentDTO);
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        public static async Task<IResult> CreateAppointment(Appointment appointment, IRepository repository)
        {
            var created = await repository.CreateAppointment(appointment);

            return TypedResults.Created($"/appointments/{created.PatientId}", created);
        }
    }
}
