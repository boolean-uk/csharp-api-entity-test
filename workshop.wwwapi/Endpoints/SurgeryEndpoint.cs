using Microsoft.AspNetCore.Mvc;
using workshop.wwwapi.Models;
using workshop.wwwapi.Repository;
using workshop.wwwapi.DTO;
namespace workshop.wwwapi.Endpoints
{
    public static class SurgeryEndpoint
    {
        //TODO:  add additional endpoints in here according to the requirements in the README.md 
        public static void ConfigurePatientEndpoint(this WebApplication app)
        {
            var surgeryGroup = app.MapGroup("surgery");

            surgeryGroup.MapGet("/patients", GetPatients);
            surgeryGroup.MapGet("/patientById/{id}", GetPatientById);
            surgeryGroup.MapGet("/doctors", GetDoctors);
            surgeryGroup.MapGet("/doctorsById/{id}", GetDoctorsById);
            surgeryGroup.MapGet("/appointmentsbydoctor/{id}", GetAppointmentsByDoctor);
            surgeryGroup.MapGet("/appointmentsbypatient/{id}", GetAppointmentsByPatient);
            surgeryGroup.MapGet("/appointmentsbycompositeid/{doctorid} {patientid} {booking}", GetAppointmentsByCompositeId);
            surgeryGroup.MapPost("/createPatient", CreatePatient);
            surgeryGroup.MapPost("/createDoctor", CreateDoctor);
            surgeryGroup.MapPost("/createAppointment", CreateAppointment);

        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> CreatePatient(IRepository repository, string FullName)
        {
            Patient? patient = await repository.CreatePatient(FullName);
            if(patient == null){
                return TypedResults.NotFound();
            }
            return TypedResults.Ok(PatientResponseDTO.FromRepository(patient));
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> CreateDoctor(IRepository repository, string FullName)
        {
            Doctor? doctor = await repository.CreateDoctor(FullName);
            if(doctor == null){
                return TypedResults.NotFound();
            }
            return TypedResults.Ok(DoctorResponseDTO.FromRepository(doctor));
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> CreateAppointment(IRepository repository, int doctorid, int patientid, DateTime booking)
        {
            Appointment? appointment = await repository.CreateAppointment(doctorid, patientid, booking);
            if(appointment == null){
                return TypedResults.NotFound();
            }
            return TypedResults.Ok(AppointmentResponseDTO.FromRepository(appointment));
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetPatients(IRepository repository)
        {
            return TypedResults.Ok(PatientResponseDTO.FromRepository(await repository.GetPatients()));
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetPatientById(IRepository repository, int id)
        {
            Patient patient = await repository.GetPatientById(id);
            if (patient == null)
            {
                return TypedResults.NotFound();
            }
            return TypedResults.Ok(PatientResponseDTO.FromRepository(patient));
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetDoctorsById(IRepository repository, int id)
        {
            Doctor doctor = await repository.GetDoctorById(id);
            if (doctor == null)
            {
                return TypedResults.NotFound();
            }
            return TypedResults.Ok(DoctorResponseDTO.FromRepository(doctor));
        }
        
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetDoctors(IRepository repository)
        {
            return TypedResults.Ok(DoctorResponseDTO.FromRepository(await repository.GetDoctors()));
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetAppointmentsByDoctor(IRepository repository, int id)
        {
            IEnumerable<Appointment> appointment = await repository.GetAppointmentsByDoctor(id);
            if (appointment == null)
            {
                return TypedResults.NotFound();
            }
            return TypedResults.Ok(AppointmentResponseDTO.FromRepository(appointment));
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetAppointmentsByPatient(IRepository repository, int id)
        {
            IEnumerable<Appointment> appointment = await repository.GetAppointmentsByPatient(id);
            if (appointment == null)
            {
                return TypedResults.NotFound();
            }
            return TypedResults.Ok(AppointmentResponseDTO.FromRepository(appointment));
        }
        public static async Task<IResult> GetAppointmentsByCompositeId(IRepository repository, int doctorid, int patientid, DateTime booking)
        {
            if (doctorid.GetType() != typeof(int) || patientid.GetType() != typeof(int) || booking.GetType() != typeof(DateTime))
            {
                return TypedResults.BadRequest("doctorid must be int, patientid must be int, booking must be datetime");
            }
            Appointment? appointment = await repository.GetAppointmentsByCompositeId(doctorid, patientid, booking);
            if (appointment == null)
            {
                return TypedResults.NotFound();
            }
            return TypedResults.Ok(AppointmentResponseDTO.FromRepository(appointment));
        }

    }
}
