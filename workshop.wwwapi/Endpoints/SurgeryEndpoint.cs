using Microsoft.AspNetCore.Mvc;
using System.Numerics;
using workshop.wwwapi.Models;
using workshop.wwwapi.Repository;

namespace workshop.wwwapi.Endpoints
{
    public class AppointmentDTO
    {
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
            surgeryGroup.MapGet("/appointmentsbydoctor/{id}", GetAppointmentsByDoctor);
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
            var patient = new GetPatientDTO(await repository.GetPatient(id));
            if(patient == null)
            {
                return TypedResults.NotFound();
            }
            return TypedResults.Ok(patient);
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
            var patient = new GetPatientDTO(await repository.CreatePatient(payloadData.FullName));
            //Return TypedResults.Created of patient
            return TypedResults.Created($"/patient{payloadData.FullName}", patient);
        }
        
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetDoctors(IRepository repository)
        {
            var doctor = GetDoctorDTO.FromRepository(await repository.GetDoctors());
            if(doctor == null)
            { 
                return TypedResults.NotFound(); 
            }
            return TypedResults.Ok(doctor);
        }
        
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetAppointmentsByDoctor(IRepository repository, int doctorId)
        {
            return TypedResults.Ok(await repository.GetAppointmentsByDoctor(doctorId));
        }
    }
}
