using Microsoft.AspNetCore.Mvc;
using workshop.wwwapi.Models;
using workshop.wwwapi.Repository;
using workshop.wwwapi.ViewModel;

namespace workshop.wwwapi.Endpoints
{
    public static class AppointmentEndpoint
    {
        //TODO:  add additional endpoints in here according to the requirements in the README.md 
        public static void ConfigureAppointmentEndpoint(this WebApplication app)
        {
            var appointments = app.MapGroup("appointments");

            appointments.MapGet("/GetAll", GetAppointments);
            appointments.MapGet("/GetById{id}", GetAppointment);
            appointments.MapGet("/GetByDoctorId{id}", GetDoctorAppointments);
            appointments.MapGet("/GetByPatientId{id}", GetPatientAppointments);
            appointments.MapPost("/Create", CreateAppointment);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetAppointments(IRepository repository)
        {
            try
            {
                return TypedResults.Ok(await repository.GetAppointments());
            }
            catch (Exception ex)
            {
                return TypedResults.Problem(ex.Message);
            }
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public static async Task<IResult> GetAppointment(IRepository repository, int id)
        {
            try
            {
                return TypedResults.Ok(await repository.GetAppointment(id));
            }
            catch (Exception ex)
            {
                return TypedResults.Problem(ex.Message);
            }
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public static async Task<IResult> GetDoctorAppointments(IRepository repository, int id)
        {
            try
            {
                return TypedResults.Ok(await repository.GetAppointmentsByDoctor(id));
            }
            catch (Exception ex)
            {
                return TypedResults.Problem(ex.Message);
            }
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public static async Task<IResult> GetPatientAppointments(IRepository repository, int id)
        {
            try
            {
                return TypedResults.Ok(await repository.GetAppointmentsByPatient(id));
            }
            catch (Exception ex)
            {
                return TypedResults.Problem(ex.Message);
            }
        }
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public static async Task<IResult> CreateAppointment(IRepository repository, InputAppointmentDTO data)
        {
            try
            {
                //Check if the patient id is valid
                var patient = await repository.GetPatient(data.patientId);
                if(patient == null)
                {
                    return TypedResults.NotFound();
                }

                //Check if the doctor id is valid
                var doctor = await repository.GetDoctor(data.doctorId);
                if(doctor == null)
                {
                    return TypedResults.NotFound();
                }

                //Check if the patient and doctor already have an appointment together
                var appointments = await repository.GetAppointments();
                if(appointments != null)
                {
                    foreach(var app in appointments)
                    {
                        if(app.patientId == data.patientId && app.doctorId == data.doctorId)
                        {
                            return TypedResults.BadRequest();
                        }
                    }
                }

                //Initialize randomizer
                Random dateRandom = new Random();

                //Create a new appointment
                var appointment = new Appointment() 
                { 
                    PatientId = data.patientId, 
                    DoctorId = data.doctorId, 
                    Booking = DateTime.Now.AddDays(dateRandom.Next(1, 366)).AddHours(dateRandom.Next(0, 24)).AddMinutes(dateRandom.Next(0, 60)).AddSeconds(dateRandom.Next(0, 60)).ToUniversalTime()
                };

                //Add the new appointment
                var result = await repository.AddAppointment(appointment);

                //Response
                return TypedResults.Created($"http://localhost:5045/appointments/{result.appointmentId}", result);
            }
            catch (Exception ex)
            {
                return TypedResults.Problem(ex.Message);
            }
        }
    }
}
