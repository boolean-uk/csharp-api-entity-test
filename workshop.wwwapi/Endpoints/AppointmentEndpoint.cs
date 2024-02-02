using Microsoft.AspNetCore.Mvc;
using workshop.wwwapi.Models.DTOs;
using workshop.wwwapi.Repository;

namespace workshop.wwwapi.Endpoints
{
    public static class AppointmentEndpoint
    {
        //TODO:  add additional endpoints in here according to the requirements in the README.md 
        public static void ConfigureAppointmentEndpoint(this WebApplication app)
        {
            var appointmentGroup = app.MapGroup("appointments");
            appointmentGroup.MapGet("/", GetAppointments);
            appointmentGroup.MapGet("/patient/{id}", GetAppointmentsByPatientId);
            appointmentGroup.MapGet("/doctor/{id}", GetAppointmentsByDoctorId);
            appointmentGroup.MapGet("/{doctorid}/{patientid}", GetAppointmentByIds);
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetAppointments(IRepository repository)
        {
            IEnumerable<AppointmentDTO> result = await repository.GetAppointments();
            return TypedResults.Ok(result);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetAppointmentsByPatientId(int id, IRepository repository)
        {
            IEnumerable<AppointmentDTO> result = await repository.GetAppointmentsByPatientId(id);
            if (!result.Any()) { return TypedResults.NotFound($"Appointments for Patient with id: {id} was not found"); }
            return TypedResults.Ok(result);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetAppointmentsByDoctorId(int id, IRepository repository)
        {
            IEnumerable<AppointmentDTO> result = await repository.GetAppointmentsByDoctorId(id);
            if (!result.Any()) { return TypedResults.NotFound($"Appointments for Doctor with id: {id} was not found"); }
            return TypedResults.Ok(result);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> GetAppointmentByIds(int doctorid, int patientid, IRepository repository)
        {
            AppointmentDTO? result = await repository.GetAppointmentByIds(doctorid, patientid);
            if (result == null) { return TypedResults.NotFound($"Appointment with doctor id: {doctorid}, patient id: {patientid} was not found"); }
            return TypedResults.Ok(result);
        }
    }
}
