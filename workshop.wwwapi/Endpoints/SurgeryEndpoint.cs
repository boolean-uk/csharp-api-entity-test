using Microsoft.AspNetCore.Mvc;
using workshop.wwwapi.Data.DTO;
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
            surgeryGroup.MapGet("/doctors", GetDoctors);
            surgeryGroup.MapGet("/doctors/appointments/{id}", GetAppointmentsByDoctor);
            surgeryGroup.MapGet("/patients/appointments/{id}", GetAppointmentsByPatient);
            surgeryGroup.MapGet("/appointments/{patientId}/{doctorId}", GetAppointmentsByComposite);
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetPatients(IRepository repository)
        { 
            return TypedResults.Ok(PatientDTOResponse.FromRepository(await repository.GetPatients()));
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetDoctors(IRepository repository)
        {
            return TypedResults.Ok(DoctorDTOResponse.FromRepository(await repository.GetDoctors()));
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetAppointmentsByDoctor(IRepository repository, int id)
        {
            if(id == 0 || id < 0)
                return Results.BadRequest("Requires a positive ID");
            
            IEnumerable<Appointment> appointment = await repository.GetAppointmentsById(id);
            if(appointment == null) {
                return Results.NotFound("No Appointments Found with that ID");
            }
            return TypedResults.Ok(DoctorAppointmentDTO.FromRepository(appointment));
        }
        public static async Task<IResult> GetAppointmentsByPatient(IRepository repository, int id)
        {
            if(id == 0 || id < 0)
                return Results.BadRequest("Requires a positive ID");
            
            IEnumerable<Appointment> appointment = await repository.GetAppointmentsById(id);
            if(appointment == null) {
                return Results.NotFound("No Appointments Found with that ID");
            }
            return TypedResults.Ok(PatientAppointmentDTO.FromRepository(appointment));
        }
        public static async Task<IResult> GetAppointmentsByComposite(IRepository repository, int patientId, int doctorId)
        {
            if(patientId == 0 || patientId < 0)
                return Results.BadRequest("patientID needs to be a positive ID");
            if(doctorId == 0 || doctorId < 0)
                return Results.BadRequest("doctorID needs to be a positive ID");
            
            IEnumerable<Appointment> appointment = await repository.GetAppointmentsByComposite(patientId, doctorId);
            if(appointment == null) {
                return Results.NotFound("No Appointments Found with that ID");
            }
            return TypedResults.Ok(PatientAppointmentDTO.FromRepository(appointment));
        }
    }
}
