using Microsoft.AspNetCore.Mvc;
using workshop.wwwapi.DTO;
using workshop.wwwapi.Models;
using workshop.wwwapi.Repository;

namespace workshop.wwwapi.Endpoints
{
    public static class SurgeryEndpoint
    {
        //TODO:  add additional endpoints in here according to the requirements in the README.md 
        public static void ConfigurePatientEndpoint(this WebApplication app)
        {
            var surgeryGroup = app.MapGroup("surgery");

            surgeryGroup.MapGet("/patients", GetPatients);
            surgeryGroup.MapGet("/patients{id}", GetPatientById);
            surgeryGroup.MapPost("/patients{id}", CreatePatient);
            surgeryGroup.MapGet("/doctors", GetDoctors);
            surgeryGroup.MapGet("/doctors{id}", GetDoctorById);
            surgeryGroup.MapPost("/doctors{id}", CreateDoctor);
            surgeryGroup.MapGet("/appointments", GetAppointments);
            surgeryGroup.MapGet("/appointments{id}", GetAppointmentById);
            surgeryGroup.MapGet("/appointments{doctorId}", GetAppointmentsByDoctor);
            surgeryGroup.MapGet("/appointments{patientId}", GetAppointmentsByPatient);
            surgeryGroup.MapPost("/appointments{id}", CreateAppointment);
        }

        // Patients

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetPatients(IRepository repository)
        {
            return TypedResults.Ok(await repository.GetPatients());
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetPatientById(IRepository repository, int id)
        {
            return TypedResults.Ok(await repository.GetPatientById(id));
        }
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public static async Task<IResult> CreatePatient(IRepository repository, PatientPost patient, int id)
        {
            if (patient.FullName == null)
            {
                return TypedResults.BadRequest();
            }
            var newPatient = await repository.CreatePatient(patient, id);
            var PatientDto = new PatientDto()
            {
                Id = newPatient.Id,
                FullName = newPatient.FullName,
            };
            return TypedResults.Created($"{PatientDto.Id}", PatientDto);
        }

        // Doctors

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetDoctors(IRepository repository)
        {
            return TypedResults.Ok(await repository.GetDoctors());
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetDoctorById(IRepository repository, int id)
        {
            return TypedResults.Ok(await repository.GetDoctorById(id));
        }
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public static async Task<IResult> CreateDoctor(IRepository repository, DoctorPost doctor, int id)
        {
            if (doctor.FullName == null)
            {
                return TypedResults.BadRequest();
            }
            var newDoctor = await repository.CreateDoctor(doctor, id);
            var DoctorDto = new DoctorDto()
            {
                Id = newDoctor.Id,
                FullName = newDoctor.FullName,
            };
            return TypedResults.Created($"{DoctorDto.Id}", DoctorDto);
        }

        // Appointments
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetAppointments(IRepository repository)
        {
            return TypedResults.Ok(await repository.GetAppointments());
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetAppointmentById(IRepository repository, int doctorId, int patientId)
        {
            return TypedResults.Ok(await repository.GetAppointmentById(doctorId, patientId));
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetAppointmentsByDoctor(IRepository repository, int id)
        {
            return TypedResults.Ok(await repository.GetAppointmentsByDoctor(id));
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetAppointmentsByPatient(IRepository repository, int id)
        {
            return TypedResults.Ok(await repository.GetAppointmentByPatient(id));
        }
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public static async Task<IResult> CreateAppointment(IRepository repository, AppointmentPost appointment, int doctorId, int patientId)
        {
            var newAppointment = await repository.CreateAppointment(appointment, doctorId, patientId);

            if (newAppointment.DoctorId == 0 || newAppointment.PatientId == 0)
            {
                return TypedResults.BadRequest();
            }

            var AppointmentDto = new AppointmentDto()
            {
                Booking = newAppointment.Booking,
                DoctorId = newAppointment.DoctorId,
                DoctorName = newAppointment.Doctor.FullName,
                PatientId = newAppointment.PatientId,
                PatientName = newAppointment.Patient.FullName,
                Type = newAppointment.Type
            };
            return TypedResults.Created($"{AppointmentDto.Booking}", AppointmentDto);
        }
    }  
}
