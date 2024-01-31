using Microsoft.AspNetCore.Mvc;
using workshop.wwwapi.DTO;
using workshop.wwwapi.Models;
using workshop.wwwapi.Repository;

namespace workshop.wwwapi.Endpoints
{
    public record PatientPostPayload(string fullName);
    public record DoctorPostPayload(string fullName);
    public record AppointmentPostPayload(string booking, int patientId, int doctorId);
    public record PrescriptionPostPayload(string name);

    public static class SurgeryEndpoint
    {
        //TODO:  add additional endpoints in here according to the requirements in the README.md 
        public static void ConfigurePatientEndpoint(this WebApplication app)
        {
            var surgeryGroup = app.MapGroup("surgery");

            surgeryGroup.MapGet("/patients", GetPatients);
            surgeryGroup.MapGet("/patients/{id}", GetPatient);
            surgeryGroup.MapPost("/patients", CreatePatient);

            surgeryGroup.MapGet("/doctors", GetDoctors);
            surgeryGroup.MapGet("/doctors/{id}", GetDoctor);
            surgeryGroup.MapPost("/doctors", CreateDoctor);

            surgeryGroup.MapGet("/appointments", GetAppointments);
            surgeryGroup.MapGet("/appointments/{booking}", GetAppointment);
            surgeryGroup.MapPost("/appointments", CreateAppointment);

            surgeryGroup.MapGet("/prescription", GetPrescriptions);
            surgeryGroup.MapGet("/prescription/{id}", GetPrescription);
            surgeryGroup.MapPost("/prescription", CreatePrescription);

            surgeryGroup.MapGet("/appointmentsbydoctor/{id}", GetAppointmentsByDoctor);
            surgeryGroup.MapGet("/appointmentsbypatient/{id}", GetAppointmentsByPatient);
        }

        // PATIENTS
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetPatients(IRepository repository)
        {
            return TypedResults.Ok(PatientResponseDTO.FromRepository(await repository.GetPatients()));
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetPatient(IRepository repository, int id)
        {
            Patient? patient = await repository.GetPatient(id);
            if (patient == null)
                return Results.NotFound("Id out of scope");

            return TypedResults.Ok(PatientResponseDTO.FromARepository(patient));
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> CreatePatient(IRepository repository, PatientPostPayload payload)
        {
            if (payload.fullName == null || payload.fullName == "")
                return Results.BadRequest("Must have name");

            Patient patient = await repository.CreatePatient(payload.fullName);
            return TypedResults.Ok(PatientResponseDTO.FromARepository(patient));
        }


        // DOCTORS
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetDoctors(IRepository repository)
        {
            return TypedResults.Ok(DoctorResponseDTO.FromRepository(await repository.GetDoctors()));
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetDoctor(IRepository repository, int id)
        {
            Doctor? doctor = await repository.GetDoctor(id);
            if (doctor == null)
                return Results.NotFound("Id out of scope");

            return TypedResults.Ok(DoctorResponseDTO.FromARepository(doctor));
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> CreateDoctor(IRepository repository, DoctorPostPayload payload)
        {
            if (payload.fullName == null || payload.fullName == "")
                return Results.BadRequest("Must have name");

            Doctor doctor = await repository.CreateDoctor(payload.fullName);
            return TypedResults.Ok(DoctorResponseDTO.FromARepository(doctor));
        }


        // APPOINTMENTS
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetAppointments(IRepository repository)
        {
            return TypedResults.Ok(AppointmentResponseDTO.FromRepository(await repository.GetAppointments()));
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetAppointment(IRepository repository, string booking)
        {
            Appointment? appointment = await repository.GetAppointment(booking);
            if (appointment == null)
                return Results.NotFound("Id out of scope");

            return TypedResults.Ok(AppointmentResponseDTO.FromARepository(appointment));
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> CreateAppointment(IRepository repository, AppointmentPostPayload payload)
        {
            //Checking booking
            if (payload.booking == null || payload.booking == "")
                return Results.BadRequest("Must have booking name");

            Patient? patient = await repository.GetPatient(payload.patientId);
            if (patient == null)
                return Results.NotFound("Id out of scope");

            Doctor? doctor = await repository.GetDoctor(payload.doctorId);
            if (doctor == null)
                return Results.NotFound("Id out of scope");

            //Creates the appointment
            Appointment appointment = await repository.CreateAppointment(payload.booking, payload.patientId, payload.doctorId);
            return TypedResults.Ok(AppointmentResponseDTO.FromARepository(appointment));
        }


        //Extra appointment functions
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetAppointmentsByDoctor(IRepository repository, int id)
        {
            Doctor? doctor = await repository.GetDoctor(id);
            if (doctor == null)
                return Results.NotFound("Id out of scope");

            return TypedResults.Ok(AppointmentResponseDTO.FromRepository(await repository.GetAppointmentsByDoctor(id)));
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetAppointmentsByPatient(IRepository repository, int id)
        {
            Patient? patient = await repository.GetPatient(id);
            if (patient == null)
                return Results.NotFound("Id out of scope");

            return TypedResults.Ok(AppointmentResponseDTO.FromRepository(await repository.GetAppointmentsByPatient(id)));
        }

        // PRESCRIPTIONS
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetPrescriptions(IRepository repository)
        {
            return TypedResults.Ok(PrescriptionResponseDTO.FromRepository(await repository.GetPrescriptions()));
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetPrescription(IRepository repository, int id)
        {
            Prescription? prescription = await repository.GetPrescription(id);
            if (prescription == null)
                return Results.NotFound("Id out of scope");

            return TypedResults.Ok(PrescriptionResponseDTO.FromARepository(prescription));
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> CreatePrescription(IRepository repository, PrescriptionPostPayload payload)
        {
            if (payload.name == null || payload.name == "")
                return Results.BadRequest("Must have name");

            Prescription prescription = await repository.CreatePrescription(payload.name);
            return TypedResults.Ok(PrescriptionResponseDTO.FromARepository(prescription));
        }
    }
}
