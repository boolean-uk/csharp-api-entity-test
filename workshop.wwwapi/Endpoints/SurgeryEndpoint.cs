using Microsoft.AspNetCore.Mvc;
using workshop.wwwapi.Repository;
using workshop.wwwapi.Models;
using workshop.wwwapi.DTOs;

namespace workshop.wwwapi.Endpoints
{
    public static class SurgeryEndpoint
    {
        //TODO:  add additional endpoints in here according to the requirements in the README.md 
        public static void ConfigurePatientEndpoint(this WebApplication app)
        {
            var surgeryGroup = app.MapGroup("surgery");

            surgeryGroup.MapGet("/patients", GetPatients);
            surgeryGroup.MapGet("/patients/{patientId}", GetPatient);
            surgeryGroup.MapPost("/patients", CreatePatient);

            surgeryGroup.MapGet("/doctors", GetDoctors);
            surgeryGroup.MapGet("/doctors/{doctorId}", GetDoctor);
            surgeryGroup.MapPost("/doctors", CreateDoctor);

            surgeryGroup.MapGet("/appointments", GetAppointments);
            surgeryGroup.MapGet("/appointments/patients/{patientId}/doctors/{doctorId}", GetAppointment);
            surgeryGroup.MapGet("/appointmentsbypatient/{patientId}", GetAppointmentsByPatient);
            surgeryGroup.MapGet("/appointmentsbydoctor/{doctorId}", GetAppointmentsByDoctor);
            surgeryGroup.MapPost("/appointments", CreateAppointment);
        }



        /// PATIENTS
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetPatients(IRepository repository)
        { 

            var patients = await repository.GetPatients();

            var patientDTO = new List<PatientResponseDTO>();

            foreach (Patient patient in patients)
            {
                patientDTO.Add(new PatientResponseDTO(patient));
            }

            return TypedResults.Ok(patientDTO);
        }


        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public static async Task<IResult> GetPatient(int patientId, IRepository repository)
        {

            Patient? patient = await repository.GetPatient(patientId, PreloadPolicy.PreloadRelations);

            if (patient == null)
            {
                return Results.NotFound("Patient not found");
            }

            var patientDTO = new PatientResponseDTO(patient);

            return TypedResults.Ok(patientDTO);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public static async Task<IResult> CreatePatient(CreatePatientPayload payload, IRepository repository)
        {
         
            if (payload.FullName == null || payload.FullName == "")
            {
                return Results.BadRequest("A non-empty Name is required");
            }
        
            Patient? patient = await repository.CreatePatient(payload.FullName);
            if (patient == null)
            {
                return Results.BadRequest("Failed to create student.");
            }

            return TypedResults.Ok(new PatientDTO(patient));
        }




        /// DOCTORS
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetDoctors(IRepository repository)
        {
            var doctors = await repository.GetDoctors();

            var doctorDTO = new List<DoctorResponseDTO>();

            foreach (Doctor d in doctors)
            {
                doctorDTO.Add(new DoctorResponseDTO(d));
            }

            return TypedResults.Ok(doctorDTO);
        }


        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public static async Task<IResult> GetDoctor(int doctorId, IRepository repository)
        {

            Doctor? d = await repository.GetDoctor(doctorId, PreloadPolicy.PreloadRelations);

            if (d == null)
            {
                return Results.NotFound("Patient not found");
            }

            var doctorDTO = new DoctorResponseDTO(d);

            return TypedResults.Ok(doctorDTO);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public static async Task<IResult> CreateDoctor(CreateDoctorPayload payload, IRepository repository)
        {

            if (payload.FullName == null || payload.FullName == "")
            {
                return Results.BadRequest("A non-empty Name is required");
            }

            Doctor? d = await repository.CreateDoctor(payload.FullName);
            if (d == null)
            {
                return Results.BadRequest("Failed to create doctor.");
            }

            return TypedResults.Ok(new DoctorDTO(d));
        }




        /// APPOITMENTS 
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetAppointments(IRepository repository)
        {
            var appointments = await repository.GetAppointments();

            var appointmentDTO = new List<AppointmentDTO>();

            foreach (Appointment a in appointments)
            {
                appointmentDTO.Add(new AppointmentDTO(a));
            }

            return TypedResults.Ok(appointmentDTO);
        }


        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetAppointmentsByDoctor(IRepository repository, int doctorId)
        {
            var appointments = await repository.GetAppointmentsByDoctor(doctorId);

            var appointmentDTO = new List<DoctorAppointmentListingDTO>();

            foreach (Appointment a in appointments)
            {
                appointmentDTO.Add(new DoctorAppointmentListingDTO(a));
            }

            return TypedResults.Ok(appointmentDTO);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetAppointmentsByPatient(IRepository repository, int patientId)
        {
            var appointments = await repository.GetAppointmentsByPatient(patientId);

            var appointmentDTO = new List<PatientAppointmentListingDTO>();

            foreach (Appointment a in appointments)
            {
                appointmentDTO.Add(new PatientAppointmentListingDTO(a));
            }

            return TypedResults.Ok(appointmentDTO);
        }


        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetAppointment(IRepository repository, int doctorId, int patientId)
        {
            Appointment? a = await repository.GetAppointment(doctorId, patientId, PreloadPolicy.PreloadRelations);

            if (a == null)
            {
                return Results.NotFound("Appointment not found");
            }

            var appointmentDTO = new AppointmentDTO(a);

            return TypedResults.Ok(appointmentDTO);
        }


        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public static async Task<IResult> CreateAppointment(CreateAppointmentPayload payload, IRepository repository)
        {

            if (payload.doctorId.GetType() != typeof(int) || payload.patientId.GetType() != typeof(int))
            {
                return Results.BadRequest("The id needs to be a number");
            }

            Appointment? a = await repository.CreateAppointment(payload.doctorId, payload.patientId);
            if (a == null)
            {
                return Results.BadRequest("Failed to create appointment.");
            }

            return TypedResults.Ok(new AppointmentDTO(a));
        }
    }
}
