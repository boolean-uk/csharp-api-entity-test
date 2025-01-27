using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using workshop.wwwapi.DTO;
using workshop.wwwapi.Enums;
using workshop.wwwapi.Exceptions;
using workshop.wwwapi.Models;
using workshop.wwwapi.Repository;

namespace workshop.wwwapi.Endpoints
{
    public static class AppointmentEndpoints
    {
        public static string Path { get; private set; } = "appointments";

        public static void ConfigureAppointmentEndpoints(this WebApplication app)
        {
            var group = app.MapGroup(Path);

            group.MapPost("/", CreateAppointment);
            group.MapGet("/", GetAppointments);
            group.MapGet("/{doctorId}/{patientId}", GetAppointment);
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public static async Task<IResult> CreateAppointment(
            IRepository<Appointment, int> appointmentRepository,
            IRepository<Doctor, int> doctorRepository,
            IRepository<Patient, int> patientRepository,
            IMapper mapper,
            AppointmentPost entity)
        {
            try
            {
                Doctor doctor = await doctorRepository.Get(entity.DoctorId);
                Patient patient = await patientRepository.Get(entity.PatientId);
                AppointmentType appointmentType;
                if (!Enum.TryParse(entity.AppointmentType, true, out appointmentType))
                {
                    return TypedResults.BadRequest($"That is not a valid appointment type! Choose one of {string.Join(", ", Enum.GetValues<AppointmentType>())}");
                }
                Appointment appointment = await appointmentRepository.Add(new Appointment
                {
                    AppointmentType = appointmentType,
                    Booking = DateTime.UtcNow.AddDays(entity.DaysTilBooking),
                    DoctorId = doctor.Id,
                    PatientId = patient.Id,
                });
                return TypedResults.Created($"/{Path}", mapper.Map<AppointmentView>(appointment));
            }
            catch (IdNotFoundException ex)
            {
                return TypedResults.NotFound(new { ex.Message });
            }
            catch (DbUpdateException)
            {
                return TypedResults.BadRequest("A booking between those two already exists!");
            }
            catch (Exception ex)
            {
                return TypedResults.Problem(ex.Message);
            }
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public static async Task<IResult> GetAppointments(
            IRepository<Appointment, int> repository, 
            IMapper mapper,
            string? doctorId,
            string? patientId)
        {
            try
            {
                IEnumerable<Appointment> appointments = await repository.GetAllWithIncludes(
                    q => q.Include(x => x.Doctor),
                    q => q.Include(x => x.Patient)
                );
                if (!string.IsNullOrEmpty(doctorId))
                {
                    int id;
                    if (!int.TryParse(doctorId, out id)) return TypedResults.BadRequest("The doctorId must be of type int!");
                    appointments = appointments.Where(a => a.DoctorId == id);
                }
                if (!string.IsNullOrEmpty(patientId))
                {
                    int id;
                    if (!int.TryParse(patientId, out id)) return TypedResults.BadRequest("The patientId must be of type int!");
                    appointments = appointments.Where(a => a.PatientId == id);
                }
                return TypedResults.Ok(mapper.Map<List<AppointmentView>>(appointments));
            }
            catch (Exception ex)
            {
                return TypedResults.Problem(ex.Message);
            }
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public static async Task<IResult> GetAppointment(
            IRepository<Appointment, int> repository,
            IMapper mapper,
            int doctorId,
            int patientId)
        {
            try
            {
                Appointment appointment = await repository.FindWithIncludes(
                    a => a.PatientId == patientId && a.DoctorId == doctorId,
                    q => q.Include(a => a.Doctor),
                    q => q.Include(a => a.Patient)
                );
                return TypedResults.Ok(mapper.Map<AppointmentView>(appointment));
            }
            catch (IdNotFoundException ex)
            {
                return TypedResults.NotFound(new { ex.Message });
            }
            catch (Exception ex)
            {
                return TypedResults.Problem(ex.Message);
            }
        }
    }
}
