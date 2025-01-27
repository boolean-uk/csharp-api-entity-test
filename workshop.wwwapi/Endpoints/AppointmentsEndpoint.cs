using System.Numerics;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using workshop.wwwapi.DTO;
using workshop.wwwapi.Exceptions;
using workshop.wwwapi.Models;
using workshop.wwwapi.Repository;
using workshop.wwwapi.ViewModel;

namespace workshop.wwwapi.Endpoints
{
    public static class AppointmentsEndpoint
    {
        //TODO:  add additional endpoints in here according to the requirements in the README.md 
        public static void ConfigureAppointmentsEndpoint(this WebApplication app)
        {
            var group = app.MapGroup("appointments");

            group.MapGet("/", GetAppointments);
            group.MapGet("/{doctorId}/{patientId}", GetAppointmentById);
            group.MapGet("/patients/{id}", GetAppointmentsByPatientId);
            group.MapPost("/", CreateAppointment);

        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public static async Task<IResult> GetAppointments(IRepository<Appointment> repository, IMapper mapper)
        {
            try
            {
                var doctors = await repository.GetAll(a => a.Patient, a => a.Doctor);

                if (!doctors.Any()) return TypedResults.NotFound();

                return TypedResults.Ok(mapper.Map<IEnumerable<AppointmentDTO>>(doctors));
            }
            catch (Exception ex) 
            {
                return TypedResults.InternalServerError(ex);
            }
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public static async Task<IResult> GetAppointmentById(IRepository<Appointment> repository, IRepository<Doctor> repositoryDoctors, IRepository<Patient> repositoryPatients, IMapper mapper, int doctorId, int patientId)
        {
            try
            {
                var doctor = await repositoryDoctors.Get(p => p.Id.Equals(doctorId));
                if (doctor == null) return TypedResults.NotFound($"No doctor with id:{doctorId} was found.");

                var patient = await repositoryPatients.Get(p => p.Id.Equals(patientId));
                if (patient == null) return TypedResults.NotFound($"No patient with id:{patientId} was found.");

                var appointment = await repository.Get(a => a.PatientId == patient.Id && a.DoctorId == doctor.Id, a => a.Patient, a => a.Doctor);
                if (appointment == null) return TypedResults.NotFound("Appointment not found for the specified doctor and patient.");

                return TypedResults.Ok(mapper.Map<AppointmentDTO>(appointment));
            }
            catch (Exception ex)
            {
                var errorResponse = new ErrorResponse
                {
                    Message = "An unexpected error occurred while processing the request.",
                    Detail = ex.Message
                };

                return TypedResults.InternalServerError(errorResponse);
            }

        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public static async Task<IResult> GetAppointmentsByPatientId(IRepository<Appointment> repository, IRepository<Patient> repositoryPatients, IMapper mapper, int patientId)
        {
            try
            {
                var patient = await repositoryPatients.Get(p => p.Id.Equals(patientId));
                if (patient == null) return TypedResults.NotFound($"No patient with id:{patientId} was found.");

                var appointments = await repository.FindAll(a => a.PatientId == patient.Id, a => a.Patient, a => a.Doctor);
                if (appointments == null) return TypedResults.NotFound("Appointments not found for the specified patient.");

                return TypedResults.Ok(mapper.Map<IEnumerable<AppointmentDTO>>(appointments));
            }
            catch (Exception ex)
            {
                var errorResponse = new ErrorResponse
                {
                    Message = "An unexpected error occurred while processing the request.",
                    Detail = ex.Message
                };

                return TypedResults.InternalServerError(errorResponse);
            }

        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public static async Task<IResult> CreateAppointment(IRepository<Appointment> repository, IMapper mapper, CreateAppointment model)
        {
            try
            {
                Appointment newAppointment = new Appointment
                {
                    DoctorId = model.DoctorId,
                    PatientId = model.PatientId,
                    Booking = model.Booking,
                    AppointmentType = model.AppointmentType
                };

                var appointment = await repository.Add(newAppointment);

                var newAppointmentWithIncludes = await repository.Get(a => a.Booking.Equals(appointment.Booking) ,a => a.Patient, a => a.Doctor);
                return TypedResults.Created($"https://localhost:7235/patients/", mapper.Map<AppointmentDTO>(newAppointmentWithIncludes));

            }
            catch (Exception ex)
            {
                var errorResponse = new ErrorResponse
                {
                    Message = "An unexpected error occurred while processing the request.",
                    Detail = ex.Message
                };

                return TypedResults.InternalServerError(errorResponse);
            }

        }

    }
}
