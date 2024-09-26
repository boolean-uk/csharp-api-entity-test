using Microsoft.AspNetCore.Mvc;
using workshop.wwwapi.DTOs;
using workshop.wwwapi.Models;
using workshop.wwwapi.Repository;
using static workshop.wwwapi.DTOs.Payloads;

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
            surgeryGroup.MapGet("/appointmentsbydoctor/{id}", GetAppointmentsByDoctor);
            surgeryGroup.MapGet("/appointmentsbypatient/{id}", GetAppointmentsByPatient);
            surgeryGroup.MapPost("/patients", CreatePatient);
            surgeryGroup.MapGet("/patients/{id}", GetPatient);
            surgeryGroup.MapPost("/appointments", AddAppointment);
            surgeryGroup.MapGet("/doctors/{id}", GetDoctor);
            surgeryGroup.MapPost("/doctors", CreateDoctor);
            surgeryGroup.MapGet("/appointsments/{id}", GetAppointment);
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetPatients(IRepository repository)
        {
            var patients = await repository.GetPatients();
            var patientsDTO = new List<PatientResponseDTO>();
            foreach(var patient in patients)
            {
                patientsDTO.Add(new PatientResponseDTO(patient));
            }
            return TypedResults.Ok(patientsDTO);
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetDoctors(IRepository repository)
        {
            var doctors = await repository.GetDoctors();
            var doctorsDTO = new List<DoctorResponseDTO>();
            foreach(var doctor in doctors)
            {
                doctorsDTO.Add(new DoctorResponseDTO(doctor));
            }
            return TypedResults.Ok(doctorsDTO);
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetAppointmentsByDoctor(IRepository repository, int id)
        {
            var appointments = await repository.GetAppointmentsByDoctor(id);
            var appointmentsDTO = new List<AppointmentDTO>();
            foreach(var appointment in appointments)
            {
                appointmentsDTO.Add(new AppointmentDTO(appointment));
            }
            return TypedResults.Ok(appointmentsDTO);
        }
        public static async Task<IResult> GetAppointmentsByPatient(IRepository repository, int id)
        {
            var appointments = await repository.GetAppointmentsByPatient(id);
            var appointmentsDTO = new List<AppointmentDTO>();
            foreach (var appointment in appointments)
            {
                appointmentsDTO.Add(new AppointmentDTO(appointment));
            }
            return TypedResults.Ok(appointmentsDTO);
        }
        public static async Task<IResult> GetPatient(IRepository repository, int patientId)
        {
            var patient = await repository.GetPatient(patientId);
            if (patient == null) { return TypedResults.NotFound(); }
            return TypedResults.Ok(new PatientResponseDTO(patient));
        }
        public static async Task<IResult> GetAppointment(IRepository repository, int appointmentId)
        {
            var appointment = await repository.GetAppointment(appointmentId);
            if (appointment == null) { return TypedResults.NotFound(); }
            return TypedResults.Ok(new AppointmentDTO(appointment));
        }
        public static async Task<IResult> CreatePatient(IRepository repository, CreatePatientPayload payload)
        {
            return TypedResults.Ok(await repository.CreatePatient(payload.fullName));
        }
        public static async Task<IResult> GetDoctor(IRepository repository, int doctorId)
        {
            var doctor = await repository.GetDoctor(doctorId);
            if(doctor == null) { return TypedResults.NotFound(); }
            return TypedResults.Ok(new DoctorResponseDTO(doctor));
        }
        public static async Task<IResult> CreateDoctor(IRepository repository, CreateDoctorPayload payload)
        {
            return TypedResults.Ok(await repository.CreateDoctor(payload.fullName));
        }
        public static async Task<IResult> AddAppointment(IRepository repository, AddAppointmentPayload payload)
        {

            Patient? patient = await repository.GetPatient(payload.patientId);
            if(patient == null) { return TypedResults.NotFound(); }

            Doctor? doctor = await repository.GetDoctor(payload.doctorId);
            if (doctor == null) { return TypedResults.NotFound(); }
            var status = await repository.AddAppointment(patient, doctor, payload.appointmentDate.ToUniversalTime());
            if (status == null)
            {
                return TypedResults.NotFound();
            }
            return TypedResults.Ok(new AppointmentDTO(status));
        }
    }
}
