using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System.Runtime.CompilerServices;
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
            surgeryGroup.MapGet("/patients/{id}", GetPatient);
            surgeryGroup.MapPost("/patients", CreatePatient);
            surgeryGroup.MapGet("/doctors", GetDoctors);
            surgeryGroup.MapGet("/doctors/{id}", GetDoctor);
            surgeryGroup.MapPost("/doctors", CreateDoctor);
            surgeryGroup.MapGet("/appointments", GetAppointments);
            surgeryGroup.MapGet("/appointments/{id}", GetAppointment);
            surgeryGroup.MapPost("/appointments", CreateAppointment);
            surgeryGroup.MapGet("/appointmentsbypatient/{id}", GetAppointmentsByPatient);
            surgeryGroup.MapGet("/appointmentsbydoctor/{id}", GetAppointmentsByDoctor);
        }

        private static async Task<IResult> CreateAppointment(IRepository repository, AppointmentPost appointment) 
        {
            var entity = await repository.CreateAppointment(appointment);
            if (entity is null) return TypedResults.BadRequest();
            return TypedResults.Created();
        }

        private static async Task<IResult> GetAppointmentsByPatient(IRepository repository, int id)
        {
            var response = await repository.GetAppointmentsByPatient(id);
            var result = new List<AppointmentGet>();
            foreach (var appointment in response)
            {
                result.Add(new AppointmentGet() 
                {
                    PatientId = appointment.PatientId,
                    PatientName = appointment.Patient.FullName,
                    DoctorId = appointment.DoctorId,
                    DoctorName = appointment.Doctor.FullName,
                    AppointmentDate = appointment.AppointmentDate,
                });
            }

            return TypedResults.Ok(result);
        }

        private static async Task<IResult> GetAppointment(IRepository repository, int id)
        {
            var entity = await repository.GetAppointment(id);
            if (entity is null) return TypedResults.NotFound();
            var result = new AppointmentGet()
            {
                DoctorId = entity.DoctorId,
                DoctorName = entity.Doctor.FullName,
                PatientId = entity.PatientId,
                PatientName = entity.Patient.FullName,
                AppointmentDate = entity.AppointmentDate,
            };
            return TypedResults.Ok(result);
        }

        private static async Task<IResult> GetAppointments(IRepository repository)
        {
            var response = await repository.GetAppointments();
            List<Object> result = new List<Object>();
            foreach (var entity in response)
            {
                result.Add(new AppointmentGet()
                {
                    DoctorId = entity.DoctorId,
                    DoctorName = entity.Doctor.FullName,
                    PatientId = entity.PatientId,
                    PatientName = entity.Patient.FullName,
                    AppointmentDate = entity.AppointmentDate
                });
            }
            return TypedResults.Ok(result);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetPatients(IRepository repository)
        {
            var response = await repository.GetPatients();
            List<Object> result = new List<Object>();
            foreach (var entity in response)
            {
                var patient = new PatientGet() { FullName = entity.FullName };
                foreach (var appointment in entity.Appointments)
                {
                    patient.Appointments.Add(new PatientAppointmentGet()
                    {
                        DoctorId = appointment.DoctorId,
                        DoctorName = appointment.Doctor.FullName,
                        AppointmentDate = appointment.AppointmentDate
                    });
                }
                result.Add(patient);
            }
            return TypedResults.Ok(result);
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> GetPatient(IRepository repository, int id)
        {
            {
                var entity = await repository.GetPatient(id);
                if (entity is null) return TypedResults.NotFound();


                var patient = new PatientGet() { FullName = entity.FullName };
                foreach (var appointment in entity.Appointments)
                {
                    patient.Appointments.Add(new PatientAppointmentGet()
                    {
                        DoctorId = appointment.Doctor.Id,
                        DoctorName = appointment.Doctor.FullName,
                        AppointmentDate = appointment.AppointmentDate
                    });
                }
                return TypedResults.Ok(patient);
            }
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public static async Task<IResult> CreatePatient(IRepository repository, PatientPost patient) 
        { 
            if (patient.FullName == "") return TypedResults.BadRequest();
            var entity = await repository.CreatePatient(patient);
            return TypedResults.Created();
            
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetDoctors(IRepository repository)
        {
            var response = await repository.GetDoctors();
            List<Object> result = new List<Object>();
            foreach (var entity in response)
            {
                var doctor = new DoctorGet() { FullName = entity.FullName };
                foreach (var appointment in entity.Appointments)
                {
                    doctor.Appointments.Add(new DoctorAppointmentGet() { 
                        PatientId = appointment.PatientId, 
                        PatientName = appointment.Patient.FullName, 
                        AppointmentDate = appointment.AppointmentDate 
                    });
                }
                result.Add(doctor);
            }
            return TypedResults.Ok(result);
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> GetDoctor(IRepository repository, int id)
        {
            var entity = await repository.GetDoctor(id);
            if (entity is null) return TypedResults.NotFound();


            var doctor = new DoctorGet() { FullName = entity.FullName };
            foreach (var appointment in entity.Appointments)
            {
                doctor.Appointments.Add(new DoctorAppointmentGet()
                {
                    PatientId = appointment.PatientId,
                    PatientName = appointment.Patient.FullName,
                    AppointmentDate = appointment.AppointmentDate
                });
            }
            return TypedResults.Ok(doctor);
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public static async Task<IResult> CreateDoctor(IRepository repository, DoctorPost doctor)
        {
            if (doctor.FullName == "") return TypedResults.BadRequest();
            var entity = await repository.CreateDoctor(doctor);
            return TypedResults.Created();
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetAppointmentsByDoctor(IRepository repository, int id)
        {
            var response = await repository.GetAppointmentsByDoctor(id);
            var result = new List<AppointmentGet>();
            foreach (var appointment in response)
            {
                result.Add(new AppointmentGet()
                {
                    PatientId = appointment.PatientId,
                    PatientName = appointment.Patient.FullName,
                    DoctorId = appointment.DoctorId,
                    DoctorName = appointment.Doctor.FullName,
                    AppointmentDate = appointment.AppointmentDate,
                });
            }

            return TypedResults.Ok(result);
        }
    }
}
