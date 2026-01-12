using Microsoft.AspNetCore.Mvc;
using workshop.wwwapi.DTOs;
using workshop.wwwapi.Models;
using workshop.wwwapi.Repository;
using Microsoft.EntityFrameworkCore;

namespace workshop.wwwapi.Endpoints
{
    public static class AppointmentEndpoints
    {
        public static void ConfigureAppointmentEndpoint(this WebApplication app)
        {
            var appointments = app.MapGroup("appointments");

            appointments.MapGet("/", GetAppointments);
            appointments.MapGet("/{id}", GetAppointmentById);
            appointments.MapGet("/patients/{patientId}", GetAppointmentsByPatientId);
            appointments.MapGet("/doctors/{doctorId}", GetAppointmentByDoctorId);
            appointments.MapPost("/", AddAppointment);

        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetAppointments(IRepository<Appointment> appointmentRepository)
        {
            var appointments = await appointmentRepository.GetWithIncludes(q =>
                q.Include(a => a.Patient)
                 .Include(a => a.Doctor));

            var result = appointments.Select(a => new AppointmentWithDetailsDto
            {
                PatientName = a.Patient?.FullName,
                DoctorName = a.Doctor?.FullName,
                Booking = a.Booking
            });

            return Results.Ok(result);
        }


        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> GetAppointmentById(int id, IRepository<Appointment> appointmentRepository)
        {
            var appointments = await appointmentRepository.GetWithIncludes(q =>
                q.Include(a => a.Patient)
                 .Include(a => a.Doctor)
                 .Where(a => a.Id == id));

            var appointment = appointments.FirstOrDefault();
            if (appointment == null)
                return Results.NotFound($"Appointment with ID {id} not found.");

            var result = new AppointmentWithDetailsDto
            {
                PatientName = appointment.Patient?.FullName,
                DoctorName = appointment.Doctor?.FullName,
                Booking = appointment.Booking
            };

            return Results.Ok(result);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> GetAppointmentsByPatientId(int patientId, IRepository<Appointment> appointmentRepository, IRepository<Patient> patientRepository)
        {
            var patient = await patientRepository.GetById(patientId);
            if (patient == null)
                return Results.NotFound($"Patient with ID {patientId} not found.");

            var appointments = await appointmentRepository.GetWithIncludes(q =>
                q.Include(a => a.Doctor)
                 .Include(a => a.Patient)
                 .Where(a => a.PatientId == patientId));

            if (!appointments.Any())
                return Results.NotFound($"No appointments found for patient with ID {patientId}.");

            var result = appointments.Select(a => new AppointmentWithDetailsDto
            {
                PatientName = patient.FullName,
                DoctorName = a.Doctor?.FullName,
                Booking = a.Booking
            });

            return Results.Ok(result);

        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> GetAppointmentByDoctorId(int doctorId, IRepository<Appointment> appointmentRepository, IRepository<Doctor> doctorRepository)
        {
            var doctor = await doctorRepository.GetById(doctorId);
            if (doctor == null)
                return Results.NotFound($"Doctor with ID {doctorId} not found.");
            var appointments = await appointmentRepository.GetWithIncludes(q =>
                q.Include(a => a.Patient)
                 .Include(a => a.Doctor)
                 .Where(a => a.DoctorId == doctorId));

            if (!appointments.Any())
                return Results.NotFound($"No appointments found for doctor with ID {doctorId}.");

            var result = appointments.Select(a => new AppointmentWithDetailsDto
            {
                PatientName = a.Patient?.FullName,
                DoctorName = doctor.FullName,
                Booking = a.Booking
            });

            return Results.Ok(result);
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public static async Task<IResult> AddAppointment(AppointmentPostDto appointmentPostDto, IRepository<Appointment> appointmentRepository, HttpRequest request)
        {
            if (appointmentPostDto == null || appointmentPostDto.PatientId <= 0 || appointmentPostDto.DoctorId <= 0) { return Results.BadRequest("Invalid appointment data."); }
            
            var newAppointment = new Appointment
            {
                PatientId = appointmentPostDto.PatientId,
                DoctorId = appointmentPostDto.DoctorId,
                Booking = appointmentPostDto.Booking
            };
            var addedAppointment = await appointmentRepository.Add(newAppointment);

            // Eagerly load related entities for the newly added appointment
            var appointments = await appointmentRepository.GetWithIncludes(q =>
                q.Include(a => a.Patient)
                 .Include(a => a.Doctor)
                 .Where(a => a.Id == addedAppointment.Id));
            var appointmentWithDetails = appointments.FirstOrDefault();

            var appointmentDto = new AppointmentWithDetailsDto
            {
                PatientName = appointmentWithDetails?.Patient?.FullName,
                DoctorName = appointmentWithDetails?.Doctor?.FullName,
                Booking = appointmentWithDetails?.Booking ?? addedAppointment.Booking
            };

            var baseUrl = $"{request.Scheme}://{request.Host}{request.PathBase}";
            var location = $"{baseUrl}/patients/{addedAppointment.Id}";
            return TypedResults.Created(location, appointmentDto);
        }
     
    }
}
