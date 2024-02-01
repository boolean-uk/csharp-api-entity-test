using Microsoft.AspNetCore.Mvc;
using workshop.wwwapi.Models;
using workshop.wwwapi.Repository;
using workshop.wwwapi.DTO;
namespace workshop.wwwapi.Endpoints
{
    public static class SurgeryEndpoint
    {
        public static void ConfigurePatientEndpoint(this WebApplication app)
        {
            var surgeryGroup = app.MapGroup("surgery");

            surgeryGroup.MapGet("/patients", GetPatients);
            surgeryGroup.MapGet("/patients/{id}", GetPatientById);
            surgeryGroup.MapPost("/patients", CreatePatient);
            surgeryGroup.MapGet("/doctors", GetDoctors);
            surgeryGroup.MapGet("/doctors/{id}", GetDoctorById);
            surgeryGroup.MapPost("/doctors", CreateDoctor);
            surgeryGroup.MapPost("/appointments", CreateAppointment);
            surgeryGroup.MapGet("/appointments", GetAllAppointments);
            surgeryGroup.MapGet("/appointments/patient/{patientId}", GetAppointmentByPatientId);
            surgeryGroup.MapGet("/appointments/doctor/{doctorId}", GetAppointmentByDoctorId);
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetPatients(IRepository repository)
        { 
            var patients = await repository.GetPatients();
            var PatientDTO = new List<PatientDTO>();
            foreach (Patient patient in patients)
            {
                PatientDTO.Add(new PatientDTO(patient));
            }
            return TypedResults.Ok(PatientDTO);
        }

        public static async Task<IResult> GetPatientById(IRepository repository, int id)
        {
            var patient = await repository.GetPatientById(id, PreloadPolicy.PreloadRelations);
            var patientDTO = new PatientDTO(patient);
            return TypedResults.Ok(patientDTO);
        }

        public static async Task<IResult> CreatePatient(CreatePatientPayload payload ,IRepository repository)
        {
            if (string.IsNullOrEmpty(payload.FullName))
            {
                return TypedResults.BadRequest("Full name is required");
            }
            Patient? patient = await repository.CreatePatient(payload.FullName);
            if (patient == null)
            {
                return TypedResults.BadRequest("Patient could not be created");
            }
            return TypedResults.Ok(new PatientResponseDTO(patient));
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetDoctors(IRepository repository)
        {
            var doctors = await repository.GetDoctors();
            var DoctorDTO = new List<DoctorDTO>();
            foreach (Doctor doctor in doctors)
            {
                DoctorDTO.Add(new DoctorDTO(doctor));
            }
            return TypedResults.Ok(DoctorDTO);
        }

        public static async Task<IResult> GetDoctorById(IRepository repository, int id)
        {
            var doctor = await repository.GetDoctorById(id, PreloadPolicy.PreloadRelations);
            var doctorDTO = new DoctorDTO(doctor);
            return TypedResults.Ok(doctorDTO);
        }

        public static async Task<IResult> CreateDoctor(CreateDoctorPayload payload, IRepository repository)
        {
            if (string.IsNullOrEmpty(payload.FullName))
            {
                return TypedResults.BadRequest("Full name is required");
            }
            Doctor? doctor = await repository.CreateDoctor(payload.FullName);
            if (doctor == null)
            {
                return TypedResults.BadRequest("Doctor could not be created");
            }
            return TypedResults.Ok(new DoctorResponseDTO(doctor));
        }

        public static async Task<IResult> CreateAppointment(CreateAppointmentPayload payload, IRepository repository)
        {
            if (payload.Booking == null)
            {
                return TypedResults.BadRequest("Booking is required");
            }
            if (payload.DoctorId == null)
            {
                return TypedResults.BadRequest("DoctorId is required");
            }
            if (payload.PatientId == null)
            {
                return TypedResults.BadRequest("PatientId is required");
            }
            Doctor? doctor = await repository.GetDoctorById(payload.DoctorId, PreloadPolicy.DoNotPreloadRelations);
            if (doctor == null)
            {
                return TypedResults.BadRequest("Doctor does not exist");
            }
            Patient? patient = await repository.GetPatientById(payload.PatientId, PreloadPolicy.DoNotPreloadRelations);
            if (patient == null)
            {
                return TypedResults.BadRequest("Patient does not exist");
            }
            Appointment? appointment = await repository.CreateAppointment(payload.Booking, doctor, patient);
            if (appointment == null)
            {
                return TypedResults.BadRequest("Appointment could not be created");
            }
            return TypedResults.Ok(new AppointmentDTO(appointment));
        }

        public static async Task<IResult> GetAllAppointments(IRepository repository)
        {
            var appointments = await repository.GetAppointments();
            var AppointmentDTO = new List<AppointmentDTO>();
            foreach (Appointment appointment in appointments)
            {
                AppointmentDTO.Add(new AppointmentDTO(appointment));
            }
            return TypedResults.Ok(AppointmentDTO);
        }

        public static async Task<IResult> GetAppointmentByPatientId(IRepository repository, int patientId)
        {
            var appointment = await repository.GetAppointmentByPatientId(patientId);
            var appointmentDTO = new AppointmentDTO(appointment);
            return TypedResults.Ok(appointmentDTO);
        }

        public static async Task<IResult> GetAppointmentByDoctorId(IRepository repository, int doctorId)
        {
            var appointment = await repository.GetAppointmentByDoctorId(doctorId);
            var appointmentDTO = new AppointmentDTO(appointment);
            return TypedResults.Ok(appointmentDTO);
        }
    }
}