using Microsoft.AspNetCore.Mvc;
using workshop.wwwapi.DTO;
using workshop.wwwapi.Models;
using workshop.wwwapi.Repository;

namespace workshop.wwwapi.Endpoints
{
    public static class AppointmentEndpoint
    {

        public static void ConfigureAppointmentEndpoint(this WebApplication app)
        {
            var doctors = app.MapGroup("appointment");

            doctors.MapGet("/", GetAppointments);
            doctors.MapPost("/", CreateAppointment);
            doctors.MapGet("/patient/{id}", GetAppointmentsByPatient);
            doctors.MapGet("/doctor/{id}", GetAppointmentsByDoctor);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetAppointments(IRepository<Appointment> repository)
        {
            var appointments = await repository.GetWithIncludes(a => a.Patient, a => a.Doctor);
            return TypedResults.Ok(
                appointments
                .Select(a => new AppointmentDto()
                {
                    Doctor = a.Doctor.FullName,
                    Patient = a.Patient.FullName
                }));
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> GetAppointmentsByPatient(IRepository<Appointment> repository, int id)
        {
            var appointments = await repository.GetWithIncludes(a => a.Patient, a => a.Doctor);
            var patientAppointments = appointments.Where(a => a.PatientId == id);
            if (patientAppointments == null)
            {
                return TypedResults.NotFound();
            }
            return TypedResults.Ok(
                patientAppointments
                .Select(a => new AppointmentDto()
                {
                    Doctor = a.Doctor.FullName,
                    
                    Patient = a.Patient.FullName
                    
                })); 
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> GetAppointmentsByDoctor(IRepository<Appointment> repository, int id)
        {
            var appointments = await repository.GetWithIncludes(a => a.Patient, a => a.Doctor);
            var doctorAppointments = appointments.Where(a => a.DoctorId == id);
            if (doctorAppointments == null)
            {
                return TypedResults.NotFound();
            }
            return TypedResults.Ok(
                doctorAppointments
                .Select(a => new AppointmentDto()
                {
                    Doctor  = a.Doctor.FullName,
                    Patient = a.Patient.FullName
                    
                }));
        }
        [ProducesResponseType(StatusCodes.Status201Created)]
        public static async Task<IResult> CreateAppointment(IRepository<Appointment> repository, CreateAppointmentDto appointmentDto)
        {
            var appointment = new Appointment()
            {
                DoctorId = appointmentDto.DoctorId,
                PatientId = appointmentDto.PatientId,
                Booking = appointmentDto.Date
            };
            await repository.Insert(appointment);
            return TypedResults.Created("somepath", new CreateAppointmentDto()
            {
                DoctorId = appointment.DoctorId,
                PatientId = appointment.PatientId,
                Date = appointment.Booking
            });
        }
    }
}
