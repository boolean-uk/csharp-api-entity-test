using Microsoft.AspNetCore.Mvc;
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
            surgeryGroup.MapGet("/patient/{id}", GetPatient);
            surgeryGroup.MapPost("/patient/create", CreatePatient);
            surgeryGroup.MapGet("/doctors", GetDoctors);
            surgeryGroup.MapGet("/doctor/{id}", GetDoctor);
            surgeryGroup.MapPost("/doctor/create", CreateDoctor);
            surgeryGroup.MapGet("/appointmentsbydoctor/{id}", GetAppointmentsByDoctor);
            surgeryGroup.MapGet("/appointmentsbypatient/{id}", GetAppointmentsByPatient);
            surgeryGroup.MapGet("/appointments", GetAppointments);
            surgeryGroup.MapGet("/appointment/{id}", GetAppointment);
            surgeryGroup.MapPost("/appointment/create", CreateAppointment);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetPatients(IRepository repository)
        {
            var patients = await repository.GetPatients();
            return TypedResults.Ok(patients.Select(p => new PatientGetDTO(p)).ToList());
        }

        public static async Task<IResult> CreatePatient(IRepository repo, PatientPostDto patient)
        {
            var result = await repo.CreatePatient(patient);
            if (result == null)
            {
                return TypedResults.InternalServerError();
            }
            return TypedResults.Ok(new PatientGetDTO(result));
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetPatient(IRepository repository, int id)
        {
            var patient = await repository.GetPatient(id);
            if (patient == null)
            {
                return TypedResults.NotFound();
            }
            return TypedResults.Ok(new PatientGetDTO(patient));
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetDoctors(IRepository repository)
        {
            var doctors = await repository.GetDoctors();
            return TypedResults.Ok(doctors.Select(d => new DoctorGetDto(d)).ToList());
        }

        public static async Task<IResult> GetDoctor(IRepository repo, int id)
        {
            var doctor = await repo.GetDoctor(id);
            if (doctor == null)
            {
                return TypedResults.NotFound();
            }
            return TypedResults.Ok(new DoctorGetDto(doctor));
        }

        public static async Task<IResult> CreateDoctor(IRepository repository, DoctorPostDto doc)
        {
            var result = await repository.CreateDoctor(doc);
            if (result == null)
            {
                return TypedResults.NotFound();
            }
            return TypedResults.Ok(result);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetAppointmentsByDoctor(IRepository repository, int id)
        {
            var appointments = await repository.GetAppointmentsByDoctor(id);
            return TypedResults.Ok(appointments.Select(a => new AppointmentWithoutDoctor(a)));
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetAppointmentsByPatient(IRepository repository, int id)
        {
            var appointments = await repository.GetAppointmentsByPatient(id);
            return TypedResults.Ok(appointments.Select(a => new AppointmentWithoutPatient(a)));
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetAppointments(IRepository repository)
        {
            var appointments = await repository.GetAppointments();
            return TypedResults.Ok(appointments.Select(a => new AppointmentGetDto(a)));
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetAppointment(IRepository repository, int id)
        {
            var appointment = await repository.GetAppointment(id);
            if (appointment == null)
            {
                return TypedResults.NotFound();
            }
            return TypedResults.Ok(new AppointmentGetDto(appointment));
        }

        public static async Task<IResult> CreateAppointment(
            IRepository repo,
            AppointmentPostDto app
        )
        {
            var result = await repo.CreateAppointment(app);
            if (result == null)
            {
                return TypedResults.NotFound();
            }
            return TypedResults.Ok(new AppointmentGetDto(result));
        }
    }
}
