using Microsoft.AspNetCore.Mvc;
using workshop.wwwapi.Models;
using workshop.wwwapi.Repository;

namespace workshop.wwwapi.Endpoints
{
    public static class AppointmentEndpoint
    {
        public static void ConfigureAppointmentEndpoint(this WebApplication app)
        {
            var surgeryGroup = app.MapGroup("appointments");

            surgeryGroup.MapGet("/", GetAppointments);
            surgeryGroup.MapGet("/{doctorId}/{patientId}", GetAppointment);
            surgeryGroup.MapGet("/doctor/{id}", GetAppointmentsByDoctor);
            surgeryGroup.MapGet("/patient/{id}", GetAppointmentsByPatient);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetAppointments(IRepository repository)
        {
            IEnumerable<Appointment> appointments = await repository.GetAppointments();
            List<AppointmentDto> appointmentDtos = appointments.Select(appointments => appointments.ToDto()).ToList();
            return TypedResults.Ok(appointmentDtos);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public static async Task<IResult> GetAppointment(IRepository repository, int doctorId, int patientId)
        {
            if (!await repository.DoctorExists(doctorId)) return TypedResults.BadRequest();
            if (!await repository.PatientExists(patientId)) return TypedResults.BadRequest();

            var appointment = await repository.GetAppointment(doctorId, patientId);
            if (appointment == null) return TypedResults.NotFound();
            return TypedResults.Ok(appointment.ToDto());
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> GetAppointmentsByDoctor(IRepository repository, int id)
        {

            if (!await repository.DoctorExists(id)) return TypedResults.NotFound();

            var appointments = await repository.GetAppointmentsByDoctor(id);
            List<AppointmentDto> appointmentDtos = appointments.Select(appointments => appointments.ToDto()).ToList();
            return TypedResults.Ok(appointmentDtos);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetAppointmentsByPatient(IRepository repository, int id)
        {
            if (!await repository.PatientExists(id)) return TypedResults.NotFound();

            var appointments = await repository.GetAppointmentsByPatient(id);
            List<AppointmentDto> appointmentDtos = appointments.Select(appointments => appointments.ToDto()).ToList();
            return TypedResults.Ok(appointmentDtos);
        }
    }
}
