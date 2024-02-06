using Microsoft.AspNetCore.Mvc;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata.Conventions;
using workshop.wwwapi.Models;
using workshop.wwwapi.Models.DTObjects;
using workshop.wwwapi.Repository;

namespace workshop.wwwapi.Endpoints
{
    public static class SurgeryEndpoint
    {
        public static void ConfigurePatientEndpoint(this WebApplication app)
        {
            var surgeryGroup = app.MapGroup("surgery");
            surgeryGroup.MapGet("surgery/appointments/{id}/doctor", GetAppointmentsByDoctor);
            surgeryGroup.MapGet("surgery/appointments/{id}/patient", GetAppointmentsByPatient);
            surgeryGroup.MapGet("surgery/appointments/", GetAppointments);
            surgeryGroup.MapPost("surgery/appointments/", CreateAppointment);
            surgeryGroup.MapGet("surgery/appointments/{id}", GetAppointment);


           // var patientGroup = app.MapGroup("patients");
            surgeryGroup.MapGet("surgery/patients/", GetPatients);
            surgeryGroup.MapGet("surgery/patients/{id}", GetAPatient);
            surgeryGroup.MapPost("surgery/patients/", CreatePatient);

            //var doctorGroup = app.MapGroup("doctors");
            surgeryGroup.MapGet("surgery/doctors/", GetDoctors);
            surgeryGroup.MapGet("surgery/doctors/{id}", GetDoctorById);
            surgeryGroup.MapPost("surgery/doctors/", CreateDoctor);
        }

        //GET Patient
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetPatients(IRepository repository)
        {  var dto = new DTO();
            IEnumerable<Patient> patients = await repository.GetPatients();
            foreach (Patient patient in patients)
            {
                dto.CreateTransferPatient(patient);
            }
            
            return TypedResults.Ok(dto.Patients);
        }

         [ProducesResponseType(StatusCodes.Status200OK)]
         public static async Task<IResult> GetAPatient(IRepository repository, int id)
         {
             DTO result = new DTO();
             var patient = await repository.GetPatientById(id);
             result.CreateTransferPatient(patient);
             return TypedResults.Ok(result.Patient);
         }
         //CREATE Patient
          [ProducesResponseType(StatusCodes.Status201Created)]
          public static async Task<IResult> CreatePatient(IRepository repository, PostPerson model) 
          {
              DTO result = new DTO();
              var patient = await repository.CreatePatient(model);
              result.CreateTransferPatient(patient);
              return TypedResults.Created($"/{result.Patient.Id}", result.Patient);
          }
          //GET Doctor
          [ProducesResponseType(StatusCodes.Status200OK)]
          public static async Task<IResult> GetDoctors(IRepository repository)
          {
              DTO result = new DTO();
              var doctors = await repository.GetDoctors();
              foreach (var doctor in doctors)
              {
                  result.CreateTransferDoctor(doctor);
              }
              return TypedResults.Ok(result.Doctors);
          }
         
          [ProducesResponseType(StatusCodes.Status200OK)]
          public static async Task<IResult> GetDoctorById(IRepository repository, int id)
          {
              DTO result = new DTO();
              var doctor = await repository.GetDoctorById(id);
              result.CreateTransferDoctor(doctor);
              return TypedResults.Ok(result.Doctor);
          }

          [ProducesResponseType (StatusCodes.Status201Created)]
          public static async Task<IResult> CreateDoctor(IRepository repository, PostPerson model)
          {
              DTO result = new DTO();
              var doctor = await repository.CreateDoctor(model);
              result.CreateTransferDoctor(doctor);
              return TypedResults.Created($"/{result.Doctor.Id}", result.Doctor);
          }


          //GET Appointment
          [ProducesResponseType(StatusCodes.Status200OK)]
          public static async Task<IResult> GetAppointments(IRepository repository)
          {
              DTO result = new DTO();
              var appointments = await repository.GetAppointments();
            foreach( var appointment in appointments)
            {
                result.CreateTransferAppointment(appointment);
            }
            
              return TypedResults.Ok(result.Appointments);
          }
         
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetAppointment(IRepository repository,int appointmentId)
        {
            DTO result = new DTO();
            Appointment appointment = await repository.GetAppointmentById(appointmentId);
            result.CreateTransferAppointment(appointment);
            return TypedResults.Ok(result.Appointment);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetAppointmentsByDoctor(IRepository repository, int id)
        {
            DTO result = new DTO();
            var appointments = await repository.GetAppointments(id, "doctor");
            foreach (Appointment a in appointments) 
            {
                result.CreateTransferAppointment(a);
             }
            return TypedResults.Ok(result.Appointments);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetAppointmentsByPatient(IRepository repository, int id)
        {
            DTO result = new DTO();
            var appointments = await repository.GetAppointments(id, "patient");
            foreach (Appointment appointment in appointments)
            {
                result.CreateTransferAppointment(appointment);
            }
            return TypedResults.Ok(result.Appointments);
        }
        
        
        [ProducesResponseType(StatusCodes.Status201Created)]
        public static async Task<IResult> CreateAppointment(IRepository repository, PostAppointment model)
        {
            DTO result = new DTO();
            var appointment = await repository.AddAppointment(model);
            result.CreateTransferAppointment(appointment);
            return TypedResults.Created($"/{result.Appointment.Id}",result.Appointment);
        }
    }
}
