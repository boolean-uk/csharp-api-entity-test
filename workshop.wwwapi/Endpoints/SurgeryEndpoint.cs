using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using System.Numerics;
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
            surgeryGroup.MapPost("/create_a_patient", CreateAPatient);
            surgeryGroup.MapGet("/doctors", GetDoctors);
            surgeryGroup.MapGet("/doctors/{id}", GetDoctorsByID);
            surgeryGroup.MapGet("/appointments", GetAppointments);
            surgeryGroup.MapGet("/appointments/patient_and_doctor/{patientid}/{doctorId}", GetAppointmentsByID);
            surgeryGroup.MapGet("/appointments/doctor/{doctorId}", GetAppointmentsByDoctorID);
            surgeryGroup.MapGet("/appointments/patient/{patientId}", GetAppointmentsByPatientID);
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

            var result = await repository.CreateAPatient(patientPayload.fullName);
            var resultDTO = new patientDTO(result);

            return TypedResults.Created($"/create_a_patient{result}", resultDTO);
        }


        
        public static async Task<IResult> GetDoctors(IRepository repository)
        {
            var result = await repository.GetDoctors();
            List<doctorDTO> resultDTO = new List<doctorDTO>();
            foreach (var doctor in result)
            {
                resultDTO.Add(new doctorDTO(doctor));
            }
            return TypedResults.Ok(resultDTO);



            
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
            var result = await repository.GetAppointments();
            List<appointmentDTO> resultDTO = new List<appointmentDTO>();
            foreach (var appointment in result)
            {
                resultDTO.Add(new appointmentDTO(appointment));
            }
            return TypedResults.Ok(resultDTO);
            
        }


        
        public static async Task<IResult> GetAppointmentsByID(IRepository repository, int doctorID , int patientID)
        {
            if (doctorID <= 0 && patientID <= 0)
            {
                return TypedResults.BadRequest("id must be a positive value");
            }

            var appointment = await repository.GetAppointmentsByID(doctorID, patientID);

            if (appointment == null)
            {
                return TypedResults.NotFound("not a valid id");
            }
            else
            {
                appointmentDTO appointmentDTO = new appointmentDTO(appointment);
                return TypedResults.Ok(appointmentDTO);
            }


            
        }

        public static async Task<IResult> GetAppointmentsByDoctorID(IRepository repository, int doctorId)
        {
            if (doctorId <= 0 )
            {
                return TypedResults.BadRequest("id must be a positive value");
            }

            var appointment = await repository.GetAppointmentsByDoctorID(doctorId );

            if (appointment == null)
            {
                return TypedResults.NotFound("not a valid id");
            }
            else
            {
                List<appointmentDTO> resultDTO = new List<appointmentDTO>();
                foreach (var result  in appointment )
                {
                    resultDTO.Add(new appointmentDTO(result));
                }
                return TypedResults.Ok(resultDTO);

                
            }
        }

        public static async Task<IResult> GetAppointmentsByPatientID(IRepository repository, int patientId)
        {
            if ( patientId <= 0)
            {
                return TypedResults.BadRequest("id must be a positive value");
            }

            var appointment = await repository.GetAppointmentsByPatientID( patientId);

            if (appointment == null)
            {
                return TypedResults.NotFound("not a valid id");
            }
            else
            {
                List<appointmentDTO> resultDTO = new List<appointmentDTO>();
                foreach (var result in appointment)
                {
                    resultDTO.Add(new appointmentDTO(result));
                }
                return TypedResults.Ok(resultDTO);

                
            }
        }

        public static async Task<IResult> CreateAppointment(IRepository repository, appointmentPayload payload)
        {
            if(payload.Date == null || payload.Date == string.Empty)
            {
                return TypedResults.BadRequest("not a valid Date, date needs to be written in the format (yyyy-MM-dd HH:mm:ss)");
            }
            if(payload.doctorId <= 0)
            {
                return TypedResults.BadRequest("doctorId needs to be a positive integer");
            }
            if (payload.patientId <= 0)
            {
                return TypedResults.BadRequest("patientId needs to be a positive integer");
            }

            DateTime dateTime;
            string dateTimeFormat = "yyyy'-'MM'-'dd HH':'mm':'ss";
            if (!DateTime.TryParseExact(payload.Date, dateTimeFormat, null, DateTimeStyles.None, out dateTime))
            {
                return TypedResults.BadRequest("not a valid startsAt, starts at needs to be written in the format (yyyy-MM-dd HH:mm:ss)");
            }

            var result = await repository.CreateAppointment(
                dateTime.ToUniversalTime(), 
                payload.patientId, 
                payload.doctorId
                );
            if(result == null)
            {
                return TypedResults.NotFound("not a valid doctor id or patient id");
            }
            else
            {
                appointmentDTO appointmentDTO = new appointmentDTO(result);
                return TypedResults.Created($"/appointments{result}",appointmentDTO);

            }
        }

    }
}
