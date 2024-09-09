using Microsoft.AspNetCore.Mvc;
using workshop.wwwapi.DTO;
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
            surgeryGroup.MapGet("/patients/{id}", GetPatient);
            surgeryGroup.MapPost("/patients", CreatePatient);

            surgeryGroup.MapGet("/doctors", GetDoctors);
            surgeryGroup.MapGet("/doctors/{id}", GetDoctor);
            surgeryGroup.MapPost("/doctors", CreateDoctor);

            surgeryGroup.MapGet("/appointments", GetAppointments);
            surgeryGroup.MapGet("/appointmentsbydoctor/{id}", GetAppointmentsByDoctor);
            surgeryGroup.MapGet("/appointmentsbypatient/{id}", GetAppointmentsByPatient);
            surgeryGroup.MapPost("/appointments", CreateAppointment);

            surgeryGroup.MapGet("/prescriptions", GetPrescriptions);
            surgeryGroup.MapGet("/prescriptions/{id}", GetPrescription);
            surgeryGroup.MapPost("/prescriptions", CreatePrescription);
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetPatients(IRepository repository)
        { 
            return TypedResults.Ok(await repository.GetPatients());
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetPatient(IRepository repository, int id)
        {
            return TypedResults.Ok(await repository.GetPatientById(id));
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> CreatePatient(IRepository repository, PatientView model)
        {
            return TypedResults.Ok(await repository.CreatePatient(model));
        }


        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetDoctors(IRepository repository)
        {
            return TypedResults.Ok(await repository.GetDoctors());
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetDoctor(IRepository repository, int id)
        {
            return TypedResults.Ok(await repository.GetDoctorById(id));
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> CreateDoctor(IRepository repository, DoctorView model)
        {
            return TypedResults.Ok(await repository.CreateDoctor(model));
        }


        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetAppointmentsByDoctor(IRepository repository, int id)
        {
            return TypedResults.Ok(await repository.GetAppointmentsByDoctor(id));
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetAppointmentsByPatient(IRepository repository, int id)
        {
            return TypedResults.Ok(await repository.GetAppointmentsByPatient(id));
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetAppointments(IRepository repository)
        {
            return TypedResults.Ok(await repository.GetAppointments());
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> CreateAppointment(IRepository repository, AppointmentView model)
        {
            return TypedResults.Ok(await repository.CreateAppointment(model));
        }


        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetPrescriptions(IRepository repository)
        {
            return TypedResults.Ok(await repository.GetPrescriptions());
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetPrescription(IRepository repository, int id)
        {
            return TypedResults.Ok(await repository.GetPrescriptionById(id));
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> CreatePrescription(IRepository repository, PrescriptionView model)
        {
            return TypedResults.Ok(await repository.CreatePrescription(model));
        }
    }
}
