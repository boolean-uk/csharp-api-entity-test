using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using workshop.wwwapi.Models;
using workshop.wwwapi.Repository;
using workshop.wwwapi.Services;

namespace workshop.wwwapi.Endpoints
{
    public static class AppointmentEndpoint
    {
        public static void ConfigureAppointmentEndpoint(this WebApplication app)
        {
            var group = app.MapGroup("/appointments");

            group.MapGet("/", GetAll);
            group.MapGet("/patients/{id}", GetByPatient);
            group.MapGet("/doctors/{id}", GetByDoctor);
            group.MapGet("/doctors/{doctorId}/patients/{patientId}", GetByDoctorAndPatient);
            group.MapGet("/patients/{patientId}/doctors/{doctorId}", GetByDoctorAndPatient);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetAll(IAppointmentRepository repository)
        {
            IEnumerable<Appointment> appointments = await repository.Get();

            if (appointments.Count() == 0)
                return TypedResults.NotFound();

            IEnumerable<OutputAppointment> outputAppointments = AppointmentDtoManager.Convert(appointments);
            return TypedResults.Ok(outputAppointments);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetByPatient(IAppointmentRepository repository, int id)
        {
            IEnumerable<Appointment?> appointments = await repository.GetByPatient(id);

            if (appointments.Count() == 0)
                return TypedResults.NotFound();

            IEnumerable<OutputAppointment> outputAppointment = AppointmentDtoManager.Convert(appointments);
            return TypedResults.Ok(outputAppointment);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetByDoctor(IAppointmentRepository repository, int id)
        {
            IEnumerable<Appointment?> appointments = await repository.GetByDoctor(id);

            if (appointments.Count() == 0)
                return TypedResults.NotFound();

            IEnumerable<OutputAppointment> outputAppointment = AppointmentDtoManager.Convert(appointments);
            return TypedResults.Ok(outputAppointment);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetByDoctorAndPatient(IAppointmentRepository repository, int doctorId, int patientId)
        {
            IEnumerable<Appointment?> appointments = await repository.GetByDoctorAndPatient(doctorId, patientId);

            if (appointments.Count() == 0)
                return TypedResults.NotFound();

            IEnumerable<OutputAppointment> outputAppointment = AppointmentDtoManager.Convert(appointments);
            return TypedResults.Ok(outputAppointment);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetByPatientAndDoctor(IAppointmentRepository repository, int doctorId, int patientId)
        {
            IEnumerable<Appointment?> appointments = await repository.GetByDoctorAndPatient(doctorId, patientId);

            if (appointments.Count() == 0)
                return TypedResults.NotFound();

            IEnumerable<OutputAppointment> outputAppointment = AppointmentDtoManager.Convert(appointments);
            return TypedResults.Ok(outputAppointment);
        }
    }
}
