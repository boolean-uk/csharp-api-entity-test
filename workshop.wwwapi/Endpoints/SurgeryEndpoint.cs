using Microsoft.AspNetCore.Mvc;
using workshop.wwwapi.DTOs;
using workshop.wwwapi.DTOs.AppointmentDTO;
using workshop.wwwapi.DTOs.DoctorDTO;
using workshop.wwwapi.DTOs.PatientDTO;
using workshop.wwwapi.Models;
using workshop.wwwapi.Repository;

namespace workshop.wwwapi.Endpoints
{
    public static class SurgeryEndpoint
    {
        public static void ConfigurePatientEndpoint(this WebApplication app)
        {
            var surgeryGroup = app.MapGroup("");

            surgeryGroup.MapGet("/patients", GetPatients);
            surgeryGroup.MapGet("/patients/{id}", GetPatientById);
            surgeryGroup.MapPost("/patients", CreatePatient);

            surgeryGroup.MapGet("/doctors", GetDoctors);
            surgeryGroup.MapGet("/doctors/{id}", GetDoctorById);
            surgeryGroup.MapPost("/doctors", CreateDoctor);

            surgeryGroup.MapGet("/appointments", GetAppointments);
            surgeryGroup.MapGet("/appointments/{id}", GetAppointmentById);
            surgeryGroup.MapGet("/appointmentsbypatient/{id}", GetAppointmentsByPatient);
            surgeryGroup.MapGet("/appointmentsbydoctor/{id}", GetAppointmentsByDoctor);
            surgeryGroup.MapPost("/appointments", CreateAppointment);
        }

        // Patients
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetPatients(IRepository repository)
        {
            List<PatientGet> result = new List<PatientGet>();
            var entities = await repository.GetPatients();
            foreach (var entity in entities)
            {
                result.Add(entity.ToDTO());
            }
            return TypedResults.Ok(result);
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> GetPatientById(IRepository repository, int id)
        {
            var entity = await repository.GetPatientById(id);
            if (entity == null) return TypedResults.NotFound(new { Error = $"Found no patient with id '{id}'." });

            return TypedResults.Ok(entity.ToDTO());
        }
        [ProducesResponseType(StatusCodes.Status201Created)]
        public static async Task<IResult> CreatePatient(IRepository repository, PatientPost model)
        {
            Patient newPatient = new Patient();
            newPatient.FullName = model.FullName;

            var entity = await repository.CreatePatient(newPatient);
            return TypedResults.Created($"{entity.ToDTO()}");
        }

        // Doctors
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetDoctors(IRepository repository)
        {
            var entities = await repository.GetDoctors();
            List<DoctorGet> result = new List<DoctorGet>();
            foreach (var entity in entities)
            {
                result.Add(entity.ToDTO());
            }

            return TypedResults.Ok(result);
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> GetDoctorById(IRepository repository, int id)
        {
            var entity = await repository.GetDoctorById(id);
            if (entity == null) return TypedResults.NotFound(new { Error = $"Found no doctor with id '{id}'." });

            return TypedResults.Ok(entity.ToDTO());
        }
        [ProducesResponseType(StatusCodes.Status201Created)]
        public static async Task<IResult> CreateDoctor(IRepository repository, DoctorPost model)
        {
            Doctor newDoctor = new Doctor();
            newDoctor.FullName = model.FullName;

            var entity = await repository.CreateDoctor(newDoctor);
            return TypedResults.Created($"{entity.ToDTO()}");
        }


        // Appointments
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetAppointments(IRepository repository)
        {
            var entities = await repository.GetAppointments();
            List<AppointmentGet> result = new List<AppointmentGet>();
            foreach (var entity in entities)
            {
                result.Add(entity.ToDTO());
            }

            return TypedResults.Ok(result);
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> GetAppointmentById(IRepository repository, int id)
        {
            var entity = await repository.GetAppointmentById(id);
            if (entity == null) return TypedResults.NotFound(new { Error = $"Found no appointment with id '{id}'." });

            return TypedResults.Ok(entity.ToDTO());
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> GetAppointmentsByDoctor(IRepository repository, int id)
        {
            var entities = await repository.GetAppointmentsByDoctor(id);
            List<AppointmentGet> result = new List<AppointmentGet>();
            foreach (var entity in entities)
            {
                result.Add(entity.ToDTO());
            }

            return TypedResults.Ok(result);
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> GetAppointmentsByPatient(IRepository repository, int id)
        {
            var entities = await repository.GetAppointmentsByPatient(id);
            List<AppointmentGet> result = new List<AppointmentGet>();
            foreach (var entity in entities)
            {
                result.Add(entity.ToDTO());
            }

            return TypedResults.Ok(result);
        }
        [ProducesResponseType(StatusCodes.Status201Created)]
        public static async Task<IResult> CreateAppointment(IRepository repository, AppointmentPost model)
        {
            Appointment newAppointment = new Appointment();
            newAppointment.Booking = model.Booking;
            newAppointment.DoctorId = model.DoctorId;
            newAppointment.PatientId = model.PatientId;

            var entity = await repository.CreateAppointment(newAppointment);
            return TypedResults.Created($"", new 
            {
                Id = entity.Id,
                Booking = entity.Booking,
                DoctorId = entity.DoctorId,
                PatientId = entity.PatientId
            });
        }
    }
}
