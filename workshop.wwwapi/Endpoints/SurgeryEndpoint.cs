using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;
using workshop.wwwapi.DTOs;
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
            surgeryGroup.MapGet("/patient{id}", GetPatientById);
            surgeryGroup.MapPost("/patients", CreatePatient);
            surgeryGroup.MapGet("/doctors", GetDoctors);
            surgeryGroup.MapGet("/doctor{id}", GetDoctorById);
            surgeryGroup.MapPost("/doctor", CreateDoctor);
            surgeryGroup.MapGet("/appointmentsbydoctor/{id}", GetAppointmentsByDoctor);
            surgeryGroup.MapGet("/appointments", GetAllAppointments);
            surgeryGroup.MapPost("appointment", CreateAppointment);
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetPatients(IRepository repository)
        { 
            return TypedResults.Ok(await repository.GetPatients());
        }

        public static async Task<IResult> GetPatientById(IRepository repository, int patientId)
        {
            var response = await repository.GetPatientById(patientId);
            return response is null ? TypedResults.NotFound() : TypedResults.Ok(repository.ConvertPatient(response).Result);
        }

        public static async Task<IResult> CreatePatient(IRepository repository, PatientDTO name)
        {
            var response = await repository.CreatePatient(new PatientDTO { Fullname = name.Fullname });
            return TypedResults.Ok(new PatientDTO { Fullname = response.FullName });
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetDoctors(IRepository repository)
        {
            return TypedResults.Ok(await repository.GetDoctors());
        }

        public static async Task<IResult> GetDoctorById(IRepository repository, int doctorId)
        {
            var response = await repository.GetDoctorById(doctorId);
            return response is null ? TypedResults.NotFound() : TypedResults.Ok(repository.ConvertDoctor(response).Result);
        }

        public static async Task<IResult> CreateDoctor(IRepository repository, DoctorDTO name)
        {
            var response = await repository.CreateDoctor(new DoctorDTO { Name = name.Name });
            return TypedResults.Ok(new DoctorDTO { Name = response.FullName });
        }


        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetAppointmentsByDoctor(IRepository repository, int id)
        {
            var response = await repository.GetAppointmentsByDoctor(id);
            return TypedResults.Ok(response.Select(a => new AppointmentDTO
            {
                DoctorName = repository.GetDoctorById(id).Result.FullName,
                PatientName = repository.GetPatientById(a.PatientId).Result.FullName
            }));
        }

        public static async Task<IResult> GetAllAppointments(IRepository repository)
        {
            var results = await repository.GetAppointments();
            return TypedResults.Ok(results.Select(a => new AppointmentDTO { DoctorName = repository.GetDoctorById(a.DoctorId).Result.FullName, 
                                                                            PatientName = repository.GetPatientById(a.PatientId).Result.FullName }));                   
        }

        public static async Task<IResult> CreateAppointment(IRepository repository, AppointmentPost aPost)
        {
            var response = await repository.CreateAppointment(aPost.doctorId, aPost.patientId);
            return TypedResults.Ok(new AppointmentDTO
            {
                DoctorName = repository.GetDoctorById(aPost.doctorId).Result.FullName,
                PatientName = repository.GetPatientById(aPost.patientId).Result.FullName
            });
        }
    }
}
