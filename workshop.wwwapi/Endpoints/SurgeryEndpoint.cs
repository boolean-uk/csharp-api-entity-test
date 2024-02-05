using Microsoft.AspNetCore.Mvc;
using workshop.wwwapi.DTO;
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
            surgeryGroup.MapGet("/patients/{id}", GetPatient);
            surgeryGroup.MapPost("/CreateAPatient", CreateAPatient);
            surgeryGroup.MapGet("/doctors", GetDoctors);
            surgeryGroup.MapGet("/doctors/{id}", GetDoctorsByID);
            surgeryGroup.MapGet("/appointments", GetAppointments);
            surgeryGroup.MapGet("/appointments/{id}", GetAppointmentsByID);
            surgeryGroup.MapGet("/appointments/{doctorId}", GetAppointmentsByDoctorID);
            surgeryGroup.MapGet("/appointments/{patientId}", GetAppointmentsByPatientID);
            surgeryGroup.MapPost("/appointments", CreateAppointment);
        }
        
        public static async Task<IResult> GetPatients(IRepository repository)
        {
            var result = await repository.GetPatients();
            List<patientDTO> resultDTO = new List<patientDTO>();
            foreach (var patient in result)
            {
                resultDTO.Add(new patientDTO(patient));
            }
            return TypedResults.Ok(resultDTO);
        }
        
        public static async Task<IResult> GetPatient(IRepository repository, int id)
        {
            if (id <= 0)
            {
                return TypedResults.BadRequest("id needs to be a positive number above 0");
            }
            var result = await repository.GetPatient(id);

            if (result == null)
            {
                return TypedResults.NotFound("id was not valid");
            }
            else
            {
                patientDTO resultDTO = new patientDTO(result);
                return TypedResults.Ok(resultDTO);
            }
        }

        
        public static async Task<IResult> CreateAPatient(IRepository repository, PatientPostPayload patientPayload)
        {
            if (patientPayload == null)
            {
                return TypedResults.BadRequest("Not valid payload");
            }
            if (patientPayload.fullName == null || patientPayload.fullName == string.Empty)
            {
                return TypedResults.NotFound("not a valid name");
            }

            var result = await repository.CreateAPatient(patientPayload);
            var resultDTO = new patientDTO(result);

            return TypedResults.Ok(resultDTO);
        }


        
        public static async Task<IResult> GetDoctors(IRepository repository)
        {
            return TypedResults.Ok(await repository.GetPatients());
        }
        public static async Task<IResult> GetDoctorsByID(IRepository repository, int id)
        {
            if(id<= 0)
            {
                return TypedResults.BadRequest("id must be a positive value");
            }

            var doctor = await repository.GetDoctorsByID(id);

            if(doctor == null)
            {
                return TypedResults.NotFound("not a valid id");
            }
            else
            {
                doctorDTO doctorDTO = new doctorDTO(doctor);
                return TypedResults.Ok(doctorDTO);
            }
        }

        public static async Task<IResult> GetAppointments(IRepository repository)
        {
            return TypedResults.Ok(await repository.GetAppointments());
        }


        
        public static async Task<IResult> GetAppointmentsByID(IRepository repository, int id)
        {
            return TypedResults.Ok(await repository.GetAppointmentsByID(id));
        }

        public static async Task<IResult> GetAppointmentsByDoctorID(IRepository repository, int doctorId)
        {
            return TypedResults.Ok(await repository.GetAppointmentsByDoctor(doctorId));
        }

        public static async Task<IResult> GetAppointmentsByPatientID(IRepository repository, int patientId)
        {
            return TypedResults.Ok(await repository.GetAppointmentsByPatientID(patientId));
        }

        public static async Task<IResult> CreateAppointment(IRepository repository, appointmentPayload payload)
        {
            if(payload.Date != null)
            {
                return TypedResults.BadRequest("not a valid date");
            }
            if(payload.doctorId <= 0)
            {
                return TypedResults.BadRequest("doctorId needs to be a positive integer");
            }
            if (payload.patientId <= 0)
            {
                return TypedResults.BadRequest("patientId needs to be a positive integer");
            }

            var result = await repository.CreateAppointment(
                payload.Date, 
                payload.patientId, 
                payload.doctorId
                );
            if(result == null)
            {
                return TypedResults.NotFound("not a valid doctor id or patient id");
            }
            else
            {
                return TypedResults.Ok(result);
            }
        }

    }
}
