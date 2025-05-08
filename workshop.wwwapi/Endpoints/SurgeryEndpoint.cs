using Microsoft.AspNetCore.Mvc;
using workshop.wwwapi.Dto;
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
            surgeryGroup.MapGet("/patients/{id}", GetPatientById);
            surgeryGroup.MapPost("/patients", CreatePatient);

            surgeryGroup.MapGet("/doctors", GetDoctors);
            surgeryGroup.MapGet("/doctors/{id}", GetDoctorById);
            surgeryGroup.MapPost("/doctors", CreateDoctor);

            surgeryGroup.MapGet("/Appointments", GetAppointments);
            surgeryGroup.MapGet("/appointmentsbydoctor/{id}", GetAppointmentsByDoctor);
            surgeryGroup.MapGet("/appointmentsbyPatient/{id}", GetAppointmentsByPatient);
            surgeryGroup.MapGet("/AppointmentsbyId/{id}", GetAppointmentsById);
            surgeryGroup.MapPost("/ApPointments", CreateAppointment);
        }


        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetPatients(IRepository repository)
        {
            var patients = await repository.GetPatients();

           return TypedResults.Ok(patients);
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> GetPatientById(IRepository repository, int id)
        {
            var patient = await repository.GetPatientById(id);

            if (patient != null)
            {
                return TypedResults.Ok(patient);
            }
            else
            {
                return Results.NotFound($"Patient with ID {id} not found.");
            }
        }


        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public static async Task<IResult> CreatePatient(IRepository repository, CreatePatientDto createPatientDto)
        {
            var createdPatient = await repository.CreatePatient(createPatientDto);

            if (createdPatient != null)
            {
                return TypedResults.Ok(createdPatient);
            }
            else
            {
                return Results.BadRequest("Failed to create the patient.");
            }
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetDoctors(IRepository repository)
        {
            var doctors = await repository.GetDoctors();

            if (doctors.Any())
            {
                return TypedResults.Ok(doctors);
            }
            else
            {
                return Results.NotFound("No doctors found.");
            }
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        private async static Task<IResult> GetDoctorById(IRepository repository, int id)
        {
            var doctor = await repository.GetDoctorById(id);

            if (doctor != null)
            {
                return TypedResults.Ok(doctor);
            }
            else
            {
                return Results.NotFound($"Doctor with ID {id} not found.");
            }
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        private static async Task<IResult> CreateDoctor(IRepository repository, CreateDoctorDto createDoctorDto )
        {
            var createdDoctor = await repository.CreateDoctor(createDoctorDto);

            if (createdDoctor != null)
            {
                return TypedResults.Ok(createdDoctor);
            }
            else
            {
                return Results.BadRequest("Failed to create the Doctor.");
            }
        }

        private static async  Task<IResult> GetAppointments(IRepository repository)
        {
            var appointments = await repository.GetAppointments();

            return TypedResults.Ok(appointments);
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetAppointmentsByDoctor(IRepository repository, int id)
        {
            var appointments = await repository.GetAppointmentsByDoctor(id);

            if (appointments.Any())
            {
                return TypedResults.Ok(appointments);
            }
            else
            {
                return Results.NotFound($"No appointments found for doctor with ID {id}.");
            };
        }
        private static async Task<IResult> GetAppointmentsByPatient(IRepository repository, int id)
        {
            var appointments = await repository.GetAppointmentsByPatient(id);

            if (appointments.Any())
            {
                return TypedResults.Ok(appointments);
            }
            else
            {
                return Results.NotFound($"No appointments found for Patient with ID {id}.");
            };
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        private static async Task<IResult> GetAppointmentsById(IRepository repository, int DoctorId, int PatientId)
        {
            var appointment = await repository.GetAppointmentById(DoctorId, PatientId);

            if (appointment != null)
            {
                return TypedResults.Ok(appointment);
            }
            else
            {
                return Results.NotFound($"Appointment with DoctorID {DoctorId} and PatientID {PatientId} not found.");
            }
        }
        private static async Task<IResult> CreateAppointment(IRepository repository, CreateAppointmentDto createAppointmentDto)
        {
            var createdappointment = await repository.CreateAppointment(createAppointmentDto);

            if (createdappointment != null)
            {
                return TypedResults.Ok(createdappointment);
            }
            else
            {
                return Results.BadRequest("Failed to create the Appointment.");
            }
        }
    }

}
