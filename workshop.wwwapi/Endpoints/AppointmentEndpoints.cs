using workshop.wwwapi.Models.Responses;
using workshop.wwwapi.Models;
using workshop.wwwapi.Repository;
using Microsoft.AspNetCore.Mvc;

namespace workshop.wwwapi.Endpoints
{
    public static class AppointmentEndpoints
    {
        public static void ConfigureAppointmentEndpoints(this WebApplication app)
        {
            var appointments = app.MapGroup("/appointments");

            appointments.MapGet("/", GetAppointments);
            appointments.MapGet("/{patientId}/{doctorId}", GetAppointmentById);
            appointments.MapGet("/doctor/{doctorId}", GetAppointmentsByDoctor);
            appointments.MapGet("/patient/{patientId}", GetAppointmentsByPatient);
            appointments.MapPost("/", CreateAppointment);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetAppointments(IAppointmentRepository repository)
        {
            var appointments = await repository.GetAllAsync();

            var appointmentDTOs = appointments.Select(a => new AppointmentDTO
            {
                PatientId = a.PatientId,
                PatientName = a.Patient != null ? a.Patient.FullName : "Unknown",
                DoctorId = a.DoctorId,
                DoctorName = a.Doctor != null ? a.Doctor.FullName : "Unknown", 
                Booking = a.Booking
            }).ToList();

            return TypedResults.Ok(appointmentDTOs);
        }


        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetAppointmentById(IAppointmentRepository repository, int patientId, int doctorId)
        {
            var appointment = await repository.GetAppointmentDetails(patientId, doctorId);
            if (appointment == null) return TypedResults.NotFound();

            var appointmentDTO = new AppointmentDTO
            {
                PatientId = appointment.PatientId,
                PatientName = appointment.Patient?.FullName ?? "Unknown", 
                DoctorId = appointment.DoctorId,
                DoctorName = appointment.Doctor?.FullName ?? "Unknown",
                Booking = appointment.Booking
            };

            return TypedResults.Ok(appointmentDTO);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetAppointmentsByDoctor(IAppointmentRepository repository, int doctorId)
        {
            var appointments = await repository.GetAppointmentsByDoctorId(doctorId);
            return TypedResults.Ok(appointments);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetAppointmentsByPatient(IAppointmentRepository repository, int patientId)
        {
            var appointments = await repository.GetAppointmentsByPatientId(patientId);
            return TypedResults.Ok(appointments);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public static async Task<IResult> CreateAppointment(
            IAppointmentRepository repository, IPatientRepository patientRepository, IDoctorRepository doctorRepository, Appointment appointment)
        {
            var patientExists = await patientRepository.GetByIdAsync(appointment.PatientId);
            if (patientExists == null)
            {
                return TypedResults.BadRequest($"No Patient found with ID {appointment.PatientId}");
            }

            var doctorExists = await doctorRepository.GetByIdAsync(appointment.DoctorId);
            if (doctorExists == null)
            {
                return TypedResults.BadRequest($"No Doctor found with ID {appointment.DoctorId}");
            }

            var existingAppointment = await repository.GetAppointmentDetails(appointment.PatientId, appointment.DoctorId);
            if (existingAppointment != null)
            {
                return TypedResults.BadRequest($"Appointment already exists between Patient {appointment.PatientId} and Doctor {appointment.DoctorId}");
            }

            var createdAppointment = await repository.AddAsync(appointment);
            return TypedResults.Created($"/appointments/{createdAppointment.PatientId}/{createdAppointment.DoctorId}", createdAppointment);
        }


    }
}
