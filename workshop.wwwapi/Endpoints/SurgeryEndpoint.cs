using Microsoft.AspNetCore.Mvc;
using System.Numerics;
using workshop.wwwapi.Endpoints;
using workshop.wwwapi.Models;
using workshop.wwwapi.Repository;

namespace workshop.wwwapi.Endpoints
{
    public class AppointmentDTO
    {
        public int Id { get; set; }
        public DateTime Booking { get; set; }
        public int DoctorId { get; set; }
        public int PatientId { get; set; }
        public AppointmentDTO(Appointment appointment)
        {
            Booking = appointment.Booking;
            PatientId = appointment.PatientId;
            DoctorId = appointment.DoctorId;
        }
    }
    public class GetAppointmentDTO
    {
        public int Id { get; set; }
        public DateTime Booking { get; set; }
        public int DoctorId { get; set; }
        public int PatientId { get; set; }
        public GetAppointmentDTO(Appointment appointment)
        {
            //Id = appointment.Id;
            Booking = appointment.Booking;
            PatientId = appointment.PatientId;
            DoctorId = appointment.DoctorId;
        }
        public static List<GetAppointmentDTO> FromRepository(IEnumerable<Appointment> appointments)
        {
            var results = new List<GetAppointmentDTO>();
            foreach (var appointment in appointments)
            {
                results.Add(new GetAppointmentDTO(appointment));
            }
            return results;
        }
    }
    public class GetPatientDTO
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public List<AppointmentDTO> Appointments { get; set; } = new List<AppointmentDTO>();
        public GetPatientDTO(Patient patient)
        {
            Id = patient.Id;
            FullName = patient.FullName;
            Appointments = new List<AppointmentDTO>();
            foreach(var appointment in patient.Appointments)
            {
                Appointments.Add(new AppointmentDTO(appointment));
            }
        }
        public static List<GetPatientDTO> FromRepository(IEnumerable<Patient> patients)
        {
            var results = new List<GetPatientDTO>();
            foreach (var patient in patients)
            {
                results.Add(new GetPatientDTO(patient));
            }
            return results;
        }
    }
    public class GetDoctorDTO
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public List<AppointmentDTO> Appointments { get; set; } = new List<AppointmentDTO>();
        public GetDoctorDTO(Doctor doctor)
        {
            Id = doctor.Id;
            FullName = doctor.FullName;
            Appointments = new List<AppointmentDTO>();
            foreach (var appointment in doctor.Appointments)
            {
                Appointments.Add(new AppointmentDTO(appointment));
            }
        }
        public static List<GetDoctorDTO> FromRepository(IEnumerable<Doctor> doctors)
        {
            var results = new List<GetDoctorDTO>();
            foreach (var doctor in doctors)
            {
                results.Add(new GetDoctorDTO(doctor));
            }
            return results;
        }
    }
    public class GetAppointmentByIdDTO
    {
        public DateTime Booking { get; set; }
        public int DoctorId { get; set; }
        public int PatientId { get; set; }
        public GetAppointmentByIdDTO(Appointment appointment)
        {
            Booking = appointment.Booking;
            DoctorId = appointment.DoctorId;
            PatientId = appointment.PatientId;
        }
        public static List<GetAppointmentByIdDTO> FromRepository(IEnumerable<Appointment> appointments)
        {
            var results = new List<GetAppointmentByIdDTO>();
            foreach (var appointment in appointments)
            {
                results.Add(new GetAppointmentByIdDTO(appointment));
            }
            return results;
        }
    }
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
            surgeryGroup.MapGet("/appointmentsbydoctor/{id}", GetAppointmentsByDoctor);
            surgeryGroup.MapGet("/appointmentsbypatient/{id}", GetAppointmentsByPatient);
            surgeryGroup.MapPost("/appointments/", CreateAppointment);
        }
        
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetPatients(IRepository repository)
        {
            var patient = GetPatientDTO.FromRepository(await repository.GetPatients());
            return TypedResults.Ok(patient);
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetPatient(IRepository repository, int id)
        {
            var patient = await repository.GetPatient(id);
            if(patient == null)
            {
                return TypedResults.NotFound($"No patient with id: {id} found");
            }
            var result = new GetPatientDTO(patient);
            return TypedResults.Ok(result);
        }
        [ProducesResponseType(StatusCodes.Status201Created)]
        public static async Task<IResult> CreatePatient(IRepository repository, CreatePatientPayload payloadData)
        {
            //Check that payloadData has values
            if(payloadData.FullName == null)
            {
                return TypedResults.BadRequest("Patient must have a name");
            }
            //Create new patient with values
            var patient = await repository.CreatePatient(payloadData.FullName);
            var result = new GetPatientDTO(patient);
            //Return TypedResults.Created of patient
            return TypedResults.Created($"/patient{patient.Id}", result);
        }
        
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetDoctors(IRepository repository)
        {
            var doctor = await repository.GetDoctors();
            if (doctor == null)
            { 
                return TypedResults.NotFound("No doctors found"); 
            }
            var result = GetDoctorDTO.FromRepository(doctor);
            return TypedResults.Ok(result);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetDoctor(IRepository repository, int id)
        {
            var doctor = await repository.GetDoctor(id);
            if(doctor == null)
            {
                return TypedResults.NotFound($"No doctor with id: {id} found");
            }
            var result = new GetDoctorDTO(doctor);
            return TypedResults.Ok(result);
        }
        [ProducesResponseType(StatusCodes.Status201Created)]
        public static async Task<IResult> CreateDoctor(IRepository repository, CreateDoctorPayload payload)
        {
            //Check payload data has values
            if(payload.FullName == null)
            {
                return TypedResults.BadRequest("Doctor must have a name");
            }
            //Create a new doctor and run post function with payload data
            var doctor = await repository.CreateDoctor(payload.FullName);
            var result = new GetDoctorDTO(doctor);
            //Return TypedResults.Created of doctor
            return TypedResults.Created($"/patient{doctor.Id}", result);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetAppointmentsByDoctor(IRepository repository, int doctorId)
        {
            var doctor = await repository.GetDoctor(doctorId);
            if(doctor == null)
            {
                return TypedResults.BadRequest("No doctor with that Id");
            }
            var result = new GetDoctorDTO(doctor);
            var appointment = GetAppointmentByIdDTO.FromRepository(await repository.GetAppointmentsByDoctor(doctorId));
            return TypedResults.Ok(appointment);
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetAppointmentsByPatient(IRepository repository, int patientId)
        {
            var patient = await repository.GetPatient(patientId);
            if (patient == null)
            {
                return TypedResults.BadRequest("No patient with that Id");
            }
            var result = new GetPatientDTO(patient);
            var appointment = GetAppointmentByIdDTO.FromRepository(await repository.GetAppointmentsByPatient(patientId));
            return TypedResults.Ok(appointment);
        }
        [ProducesResponseType(StatusCodes.Status201Created)]
        public static async Task<IResult> CreateAppointment(IRepository repository, CreateAppointmentPayload payload)
        {
            //Check payload data has values
            if (payload.PatientId == 0 || payload.DoctorId == 0)
            {
                return TypedResults.BadRequest("All fields must be filled");
            }
            //Create a new doctor and run post function with payload data
            var appointment = await repository.CreateAppointment(payload.DoctorId, payload.PatientId);
            var result = new GetAppointmentDTO(appointment);
            //Return TypedResults.Created of doctor
            return TypedResults.Created($"/patient{appointment}", result);
        }
    }
}
