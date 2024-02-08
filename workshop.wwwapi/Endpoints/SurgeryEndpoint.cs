using Microsoft.AspNetCore.Mvc;
using workshop.wwwapi.Repository;
using workshop.wwwapi.StatusPayloads;
using System.Net;
using workshop.wwwapi.DTO.Server;
using workshop.wwwapi.DTO.Client;
using Swashbuckle.AspNetCore.SwaggerUI;
using workshop.wwwapi.Models;


namespace workshop.wwwapi.Endpoints
{
    public static class SurgeryEndpoint
    {
        //TODO:  add additional endpoints in here according to the requirements in the README.md 
        public static void ConfigurePatientEndpoint(this WebApplication app)
        {
            var surgeryGroup = app.MapGroup("surgery");

            surgeryGroup.MapGet("/patients", GetPatients);
            surgeryGroup.MapGet("/patient/{id}", GetAPatient);
            surgeryGroup.MapPost("/createpatient", CreatePatient);

            surgeryGroup.MapGet("/doctors", GetDoctors);
            surgeryGroup.MapGet("/doctor/{id}", GetADoctor);
            surgeryGroup.MapPost("/createdoctor", CreateDoctor);
            surgeryGroup.MapGet("/appointmentsbydoctor/{id}", GetAppointmentsByDoctor);

            surgeryGroup.MapGet("/appointments", GetAppointments);
            surgeryGroup.MapGet("/appointment/{doctorId}/{patientId}", GetAnAppointment);
            surgeryGroup.MapGet("/appointmentbydoctorid{id}", GetAppointmentByDoctorId);
            surgeryGroup.MapGet("/appointmentbypatientid{id}", GetAppointmentByPatientId);

            // perscription
            surgeryGroup.MapGet("/perscription", GetPerscriptions);
            surgeryGroup.MapPost("/createperscription", CreatePerscription);

            // test endpoints
            surgeryGroup.MapGet("/test", Test);
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetPatients(IRepository repository)
        { 
            return TypedResults.Ok(await repository.GetPatients());
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]       
        [ProducesResponseType(StatusCodes.Status400BadRequest)]       
        public static async Task<IResult> GetAPatient(IRepository repository, int id)
        {
            var patient = await repository.GetAPatient(id);
            
            if (patient.StatusCode == HttpStatusCode.NotFound)
            {
                return TypedResults.NotFound(patient.data);
            }
            if (patient.StatusCode == HttpStatusCode.OK) 
            {
                return TypedResults.Ok(patient.data);
            }
            return TypedResults.BadRequest("Error at server");
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> CreatePatient(IRepository repository, patient_client_dto patientInfo) 
        {
            if (patientInfo.FullName == string.Empty)
            {
                return TypedResults.BadRequest("property: FullName, cannot be empty");
            }
            Patient_server_dto patient = await repository.CreatePatient(patientInfo);
            return TypedResults.Ok(patient);
        }
        public static async Task<IResult> GetDoctors(IRepository repository)
        {
            return TypedResults.Ok(await repository.GetDoctors());
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetAppointmentsByDoctor(IRepository repository, int id)
        {
            return TypedResults.Ok(await repository.GetAppointmentsByDoctor(id));
        }

        public static async Task<IResult> Test (IRepository repository) 
        {
            return TypedResults.Ok(repository.test());
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public static async Task<IResult> GetADoctor(IRepository repository, int id)
        {
            Payload<doctorAndPatient> doctor = await repository.GetADoctor(id);

            if (doctor.StatusCode == HttpStatusCode.NotFound)
            {
                return TypedResults.NotFound(doctor.data);
            }
            if (doctor.StatusCode == HttpStatusCode.OK)
            {
                return TypedResults.Ok(doctor.data);
            }
            return TypedResults.BadRequest("Error at server");
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public static async Task<IResult> CreateDoctor(IRepository repository, createDoctor_dto doctorInfo)
        {
            if (doctorInfo.FullName == string.Empty)
            {
                return TypedResults.BadRequest("property: FullName, cannot be empty");
            }
            createDoctor_dto doctor = await repository.CreateDoctor(doctorInfo);
            return TypedResults.Ok(doctor);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetAppointments(IRepository repository)
        {
            return TypedResults.Ok(await repository.GetAppointments());
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public static async Task<IResult> GetAnAppointment(IRepository repository, int patientId, int doctorId)
        {            
            var appointment = await repository.GetAnAppointment(doctorId, patientId);

            if (appointment.StatusCode == HttpStatusCode.NotFound)
            {
                return TypedResults.NotFound(appointment.data);
            }
            if (appointment.StatusCode == HttpStatusCode.OK)
            {
                return TypedResults.Ok(appointment.data);
            }
            return TypedResults.BadRequest("Error at server");
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public static async Task<IResult> GetAppointmentByDoctorId(IRepository repository, int id)
        {
            var appointment = await repository.GetApointmentByDoctorId(id);

            if (appointment.StatusCode == HttpStatusCode.NotFound)
            {
                return TypedResults.NotFound(appointment.data);
            }
            if (appointment.StatusCode == HttpStatusCode.OK)
            {
                return TypedResults.Ok(appointment.data);
            }
            return TypedResults.BadRequest("Error at server");
        }


        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public static async Task<IResult> GetAppointmentByPatientId(IRepository repository, int id)
        {
            var appointment = await repository.GetApointmentByPatientId(id);

            if (appointment.StatusCode == HttpStatusCode.NotFound)
            {
                return TypedResults.NotFound(appointment.data);
            }
            if (appointment.StatusCode == HttpStatusCode.OK)
            {
                return TypedResults.Ok(appointment.data);
            }
            return TypedResults.BadRequest("Error at server");
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetPerscriptions(IRepository repository)
        {
            return TypedResults.Ok(await repository.GetPerscriptions());
        }

        public static async Task<IResult> CreatePerscription(IRepository repository, perscription_create_dto perscriptionDetails)
        {
            var perscription = await repository.CreatePerscription(perscriptionDetails);

            if (perscription.StatusCode == HttpStatusCode.NotFound)
            {
                return TypedResults.NotFound(perscription.data);
            }
            if (perscription.StatusCode == HttpStatusCode.OK)
            {
                return TypedResults.Ok(perscription.data);
            }
            return TypedResults.BadRequest("Error at server");
        }
    }
}
