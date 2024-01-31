using Microsoft.AspNetCore.Mvc;
using workshop.wwwapi.Models.Payloads;
using workshop.wwwapi.Repository;

namespace workshop.wwwapi.Endpoints
{
    public static class SurgeryEndpoint
    {
        //TODO:  add additional endpoints in here according to the requirements in the README.md 
        public static void ConfigurePatientEndpoint(this WebApplication app)
        {
            var surgeryGroup = app.MapGroup("surgery");

            surgeryGroup.MapGet("/doctors", GetDoctors);
            surgeryGroup.MapGet("/doctors/{id}", GetDoctorById);
            surgeryGroup.MapPost("/doctors/{id}", AddDoctor);

            surgeryGroup.MapGet("/patients", GetPatients);
            surgeryGroup.MapGet("/patients/{id}", GetPatientById);
            surgeryGroup.MapPost("/patients/{id}", AddPatient);

            surgeryGroup.MapGet("/appointments", GetAppointments);
            surgeryGroup.MapGet("/appointmentsbydoctor/{id}", GetAppointmentsByDoctor);
            surgeryGroup.MapGet("/appointmentsbypatient/{id}", GetAppointmentsByPatient);
            surgeryGroup.MapGet("/appointments/{id}", GetAppointmentById);
            surgeryGroup.MapPost("/appointments/{id}", AddAppointment);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetDoctors(IRepository repository)
        {
            return TypedResults.Ok(await repository.GetDoctors());
        }
        public static async Task<IResult> GetDoctorById(IRepository repository, int id)
        {
            var doctor = await repository.GetDoctorById(id);
            return doctor == null ? TypedResults.NotFound("Doctor not found") : TypedResults.Ok(doctor);
        }
        public static async Task<IResult> AddDoctor(IRepository repository, NamePayload payload)
        {
            if (string.IsNullOrWhiteSpace(payload.Fullname)) { return TypedResults.BadRequest("Doctor must have a name"); }
            var doctor = await repository.AddDoctor(payload.Fullname);

            return doctor == null ?
                TypedResults.BadRequest("Doctor was not added") :
                TypedResults.Created($"surgery/doctors/{doctor.Id}", doctor);
        }


        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetPatients(IRepository repository)
        {
            return TypedResults.Ok(await repository.GetPatients());
        }

        public static async Task<IResult> GetPatientById(IRepository repository, int id)
        {
            var patient = await repository.GetPatientById(id);
            return patient == null ? TypedResults.BadRequest("Patient not found") : TypedResults.Ok(patient);
        }

        public static async Task<IResult> AddPatient(IRepository repository, NamePayload payload)
        {
            if (string.IsNullOrWhiteSpace(payload.Fullname)) { return TypedResults.BadRequest("Patient must have a name"); }
            var patient = await repository.AddPatient(payload.Fullname);

            return patient == null ?
                TypedResults.BadRequest("Patient was not added") :
                TypedResults.Created($"surgery/patients/{patient.Id}", patient);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetAppointments(IRepository repository)
        {
            return TypedResults.Ok(await repository.GetAppointments());
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetAppointmentsByDoctor(IRepository repository, int doctorId)
        {
            return TypedResults.Ok(await repository.GetAppointmentsByDoctor(doctorId));
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetAppointmentsByPatient(IRepository repository, int patientId)
        {
            return TypedResults.Ok(await repository.GetAppointmentsByPatient(patientId));
        }
        public static async Task<IResult> GetAppointmentById(IRepository repository, int doctorId, int patientId)
        {
            var appointment = await repository.GetAppointmentById(doctorId, patientId);
            return appointment == null ? TypedResults.BadRequest("Appointment not found") : TypedResults.Ok(appointment);
        }

        public static async Task<IResult> AddAppointment(IRepository repository, AppointmentPayload payload)
        {

            var appointment = await repository.AddAppointment(payload.Doctor_id, payload.Patient_id);

            //TODO update appoinment URL
            return appointment == null ?
                TypedResults.BadRequest("Appointment failed to be added") :
                TypedResults.Created($"surgery/patients/{appointment}", appointment);

        }

    }
}
