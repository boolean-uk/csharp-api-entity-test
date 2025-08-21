using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using workshop.wwwapi.DTOs;
using workshop.wwwapi.Factories;
using workshop.wwwapi.Repository;

namespace workshop.wwwapi.Endpoints
{
    public static class SurgeryEndpoint
    {
        //TODO:  add additional endpoints in here according to the requirements in the README.md 
        public static void ConfigurePatientEndpoint(this WebApplication app)
        {
            var surgeryGroup = app.MapGroup("surgery");
            string contentType = "application/json";

            surgeryGroup.MapGet("/patients", GetPatients);
            surgeryGroup.MapGet("/doctors", GetDoctors);
            surgeryGroup.MapGet("/appointmentsbydoctor/{id}", GetAppointmentsByDoctor);
            surgeryGroup.MapGet("/appointmentsbypatient/{id}", GetAppointmentsByDoctor);
            surgeryGroup.MapPost("/createappointment", CreateAppointment).Accepts<AppointmentPostDto>(contentType);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetPatients(IRepository repository)
        {
            var patients = await repository.GetPatients();
            var dtos = new List<PatientDto>();
            foreach (var patient in patients)
            {
                dtos.Add(PatientFactory.Dto(patient));
            }
            return TypedResults.Ok(dtos);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetDoctors(IRepository repository)
        {
            var doctors = await repository.GetPatients();
            var dtos = new List<PatientDto>();
            foreach (var doctor in doctors)
            {
                dtos.Add(PatientFactory.Dto(doctor));
            }
            return TypedResults.Ok(dtos);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> GetAppointmentsByDoctor(IRepository repository, int id)
        {
            var appointments = await repository.GetAppointmentsByDoctor(id);
            if (appointments is null)
            {
                return TypedResults.NotFound();
            }

            var dtos = new List<AppointmentForDoctorDto>();
            foreach (var appointment in appointments)
            {
                dtos.Add(AppointmentFactory.DtoForDoctor(appointment));
            }
            return TypedResults.Ok(dtos);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> GetAppointmentsByPatient(IRepository repository, int id)
        {
            var appointments = await repository.GetAppointmentsByPatient(id);
            if (appointments is null)
            {
                return TypedResults.NotFound();
            }

            var dtos = new List<AppointmentForPatientDto>();
            foreach (var appointment in appointments)
            {
                dtos.Add(AppointmentFactory.DtoForPatient(appointment));
            }
            return TypedResults.Ok(dtos);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public static async Task<IResult> CreateAppointment(IRepository repository, HttpRequest request)
        {
            AppointmentPostDto inDto = await ValidateFromRequest<AppointmentPostDto>(request);
            if (inDto is null)
                return TypedResults.BadRequest();

            var appointment = await repository.CreateAppointment(AppointmentFactory.AppointmentFromPost(inDto));
            if (appointment is null)
            {
                return TypedResults.BadRequest();
            }

            var outDto = AppointmentFactory.DtoFromAppointment(appointment);
            return TypedResults.Ok(outDto);
        }

        private async static Task<T> ValidateFromRequest<T>(HttpRequest request)
        {
            T? entity;
            try
            {
                entity = await request.ReadFromJsonAsync<T>();
            }
            catch (JsonException ex)
            {
                return default;
            }

            return entity;
        }
    }
}
