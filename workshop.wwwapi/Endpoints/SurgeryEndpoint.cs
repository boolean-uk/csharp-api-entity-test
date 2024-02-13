using Microsoft.AspNetCore.Mvc;
using System.Numerics;
using workshop.wwwapi.Models;
using workshop.wwwapi.Repository;
using workshop.wwwapi.Service;

namespace workshop.wwwapi.Endpoints
{
    public static class SurgeryEndpoint
    {
        //TODO:  add additional endpoints in here according to the requirements in the README.md 
        public static void ConfigurePatientEndpoint(this WebApplication app)
        {
            var surgeryGroup = app.MapGroup("surgery");

            surgeryGroup.MapGet("/patients", GetPatients);
            surgeryGroup.MapGet("/patient/{id}", GetPatient);
            surgeryGroup.MapPost("/patient/", CreatePatient);
            surgeryGroup.MapGet("/doctors", GetDoctors);
            surgeryGroup.MapGet("/doctor/{id}", GetDoctor);
            surgeryGroup.MapPost("/doctor/", CreateDoctor);
            surgeryGroup.MapGet("/appointments", GetAppointments);
            surgeryGroup.MapGet("/appointment/{id}", GetAppointment);
            surgeryGroup.MapGet("/appointmentsbydoctor/{id}", GetAppointmentsByDoctor);
            surgeryGroup.MapGet("/appointmentsbypatient/{id}", GetAppointmentsByPatient);
            surgeryGroup.MapPost("/appointment/", CreateAppointment);
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetPatients(IRepository repository, IService service)
        {
            var Appointments = await repository.GetEntities<Appointment>();
            var data = await repository.GetEntities<Patient>();
            foreach (var entity in data)
            {
                entity.Appointments = Appointments.Where(x => x.PatientId == entity.Id).ToList();
            }
            var output = await service.EntitiesToDto<Patient, PatientDto>(data);
            return TypedResults.Ok(output);
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> GetPatient(IRepository repository, IService service, int id)
        {
            var Appointments = await repository.GetEntities<Appointment>();
            var data = await repository.GetEntity<Patient>(id);
            if (data == null)
            {
                return TypedResults.NotFound("Patient not found");
            }
            data.Appointments = Appointments.Where(x => x.PatientId == data.Id).ToList();
            var output = await service.EntityToDto<Patient, PatientDto>(data);
            return TypedResults.Ok(output);
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public static async Task<IResult> CreatePatient(IRepository repository, IService service, PatientPatch patient)
        {
            string name = patient.Name;
            if (repository.GetEntities<Patient>().Result.Any(x => x.FullName == name))
            {
                return TypedResults.BadRequest("Patient already exists.");
            }
            Patient entity = new Patient()
            {
                FullName = patient.Name
            };
            var data = await repository.CreateEntity(entity);
            var output = await service.EntityToDto<Patient, PatientDto>(data);
            return TypedResults.Created($"/{data.Id}", output);
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetDoctors(IRepository repository, IService service)
        {
            var Appointments = await repository.GetEntities<Appointment>(); 
            var data = await repository.GetEntities<Doctor>();
            foreach (var entity in data)
            {
                entity.Appointments = Appointments.Where(x => x.DoctorId == entity.Id).ToList();
            }
            var output = await service.EntitiesToDto<Doctor, DoctorDto>(data);
            return TypedResults.Ok(output);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> GetDoctor(IRepository repository, IService service, int id)
        {
            var Appointments = await repository.GetEntities<Appointment>();
            var data = await repository.GetEntity<Doctor>(id);
            if (data == null)
            {
                return TypedResults.NotFound("Doctor not found");
            }
            data.Appointments = Appointments.Where(x => x.PatientId == data.Id).ToList();
            var output = await service.EntityToDto<Doctor, DoctorDto>(data);
            return TypedResults.Ok(output);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public static async Task<IResult> CreateDoctor(IRepository repository, IService service, DoctorPatch doctor)
        {
            string name = doctor.Name;
            if (repository.GetEntities<Doctor>().Result.Any(x => x.FullName == name))
            {
                return TypedResults.BadRequest("Doctor already exists.");
            }
            Doctor entity = new Doctor()
            {
                FullName = doctor.Name,
            };
            var data = await repository.CreateEntity(entity);
            var output = await service.EntityToDto<Doctor, DoctorDto>(data);
            return TypedResults.Created($"/{data.Id}", output);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetAppointments(IRepository repository, IService service)
        {
            var data = await repository.GetEntities<Appointment>();
            var output = await service.EntitiesToDto<Appointment, AppointmentDto>(data);
            return TypedResults.Ok(output);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> GetAppointment(IRepository repository, IService service, int id)
        {
            var data = await repository.GetEntity<Appointment>(id);
            if (data == null)
            {
                return TypedResults.NotFound("Appointment not found");
            }
            var output = await service.EntityToDto<Appointment, AppointmentDto>(data);
            return TypedResults.Ok(output);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> GetAppointmentsByDoctor(IRepository repository, IService service, int id)
        {
            Doctor doctor = await repository.GetEntity<Doctor>(id);
            if (doctor == null)
            {
                return TypedResults.NotFound("This doctor does not exist.");
            }
            else if (doctor.Appointments == null)
            {
                return TypedResults.NotFound("There are no appointments for this doctor");
            }
            var data = await repository.GetAppointmentsByDoctor(id);
            var output = await service.EntitiesToDto<Appointment, AppointmentDto>(data);
            return TypedResults.Ok(output);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> GetAppointmentsByPatient(IRepository repository, IService service, int id)
        {
            var data = await repository.GetAppointmentsByPatient(id);
            if (data == null)
            {
                return TypedResults.NotFound("There are no appointments for this patient");
            }
            var output = await service.EntitiesToDto<Appointment, AppointmentDto>(data);
            return TypedResults.Ok(output);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public static async Task<IResult> CreateAppointment(IRepository repository, IService service, AppointmentPost appointment)
        {
            var appointments = await repository.GetEntities<Appointment>();
            var patient = await repository.GetEntity<Patient>(appointment.PatientId);
            var doctor = await repository.GetEntity<Doctor>(appointment.DoctorId);
            if (doctor == null)
            {
                return TypedResults.BadRequest("Doctor does not exist");
            }
            else if (patient == null)
            {
                return TypedResults.BadRequest("Patient does not exist");
            }
            else if (appointments.Any(x => x.AppointmentDate == appointment.AppointmentDate && x.PatientId == appointment.PatientId && x.DoctorId == appointment.DoctorId))
            {
                return TypedResults.BadRequest("Appointment already exists");
            }
            else if (appointments.Any(x => x.AppointmentDate == appointment.AppointmentDate && x.PatientId == appointment.PatientId))
            {
                return TypedResults.BadRequest("Patient already has an appointment at this time");
            }
            else if (appointments.Any(x => x.AppointmentDate == appointment.AppointmentDate && x.DoctorId == appointment.DoctorId))
            {
                return TypedResults.BadRequest("Doctor already has an appointment at this time");
            }
            
            Appointment entity = new Appointment()
            {
                AppointmentDate = appointment.AppointmentDate,
                AppointmentType = appointment.AppointmentType,
                PatientId = appointment.PatientId,
                DoctorId = appointment.DoctorId
            };
            var data = await repository.CreateEntity(entity);
            patient.Appointments.Add(data);
            doctor.Appointments.Add(data);
            var output = await service.EntityToDto<Appointment, AppointmentDto>(data);
            return TypedResults.Created($"/{data.Id}", output);
        }
    }
}