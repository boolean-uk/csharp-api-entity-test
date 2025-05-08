using Microsoft.AspNetCore.Mvc;
using workshop.wwwapi.DTOs;
using workshop.wwwapi.Payload;
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
            surgeryGroup.MapGet("/doctors", GetDoctors);
            surgeryGroup.MapGet("/appointmentsbydoctor/{id}", GetAppointmentsByDoctor);
            surgeryGroup.MapGet("/appointmentsbypatient/{id}", GetAppointmentByPatient);
            surgeryGroup.MapGet("/appointments", GetAppointments);
            surgeryGroup.MapPost("/appointment", CreateAppointment);
            surgeryGroup.MapGet("/appointment/{id})", GetAppointment);
            surgeryGroup.MapGet("/patients/{id}", GetPatient);
            surgeryGroup.MapPost("/patients", CreatePatient);
            surgeryGroup.MapGet("/doctors/{id}", GetDoctor);
            surgeryGroup.MapPost("/doctors", CreateDoctor);
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetPatients(IRepository repository)
        { 
            return TypedResults.Ok(await repository.GetPatients());
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetDoctors(IRepository repository)
        {
            return TypedResults.Ok(await repository.GetDoctors());
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetAppointmentsByDoctor(IRepository repository, int id)
        {
            Payload<IEnumerable<AppointmentGetDoctor>> payload = await repository.GetAppointmentsByDoctor(id);

            if (!payload.GoodResponse)
            {
                return TypedResults.NotFound(payload.Message);
            }

            return TypedResults.Ok(payload);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> GetPatient(IRepository repository, int id)
        {
            Payload<PatientGetDTO> payload = await repository.GetPatient(id);

            if (!payload.GoodResponse)
            {
                return TypedResults.NotFound(payload.Message);
            }

            return TypedResults.Ok(payload);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public static async Task<IResult> CreatePatient(IRepository repository, CreatePatientDTO patient)
        {
            Payload<PatientGetDTO> payload = await repository.CreatePatient(patient);

            if (!payload.GoodResponse)
            {
                return TypedResults.Conflict(payload.Message);
            }

            return TypedResults.Ok(payload);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> GetDoctor(IRepository repository, int id)
        {
            Payload<DoctorGetDTO> payload = await repository.GetDoctor(id);

            if (!payload.GoodResponse)
            {
                return TypedResults.NotFound(payload.Message);
            }

            return TypedResults.Ok(payload);
        }


        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public static async Task<IResult> CreateDoctor(IRepository repository, CreateDoctorDTO doctor)
        {
            Payload<DoctorGetDTO> payload = await repository.CreateDoctor(doctor);

            if (!payload.GoodResponse)
            {
                return TypedResults.Conflict(payload.Message);
            }

            return TypedResults.Ok(payload);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetAppointmentByPatient(IRepository repository, int patientId)
        {
            Payload<DoctorGetDTO> payload = await repository.GetDoctor(patientId);

            if (!payload.GoodResponse)
            {
                return TypedResults.NotFound(payload.Message);
            }

            return TypedResults.Ok(payload);
        }

        public static async Task<IResult> GetAppointment(IRepository repository, int id)
        {
            Payload<AppointmentGetDTO> payload = await repository.GetAppointment(id);

            if (!payload.GoodResponse)
            {
                return TypedResults.NotFound(payload.Message);
            }

            return TypedResults.Ok(payload);
        }


        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> CreateAppointment(IRepository repository, CreateAppointmentDTO appointment)
        {
            Payload<AppointmentGetDTO> payload = await repository.CreateAppointment(appointment);

            if (!payload.GoodResponse)
            {
                return TypedResults.Conflict(payload.Message);
            }

            return TypedResults.Ok(payload);
        }

        public static async Task<IResult> GetAppointments(IRepository repository)
        {
            Payload<IEnumerable<AppointmentGetDTO>> payload = await repository.GetAppointments();

            return TypedResults.Ok(payload);
        }




        
    }
}
