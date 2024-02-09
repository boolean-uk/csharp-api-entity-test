using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using workshop.wwwapi.DTOs;
using workshop.wwwapi.Models;
using workshop.wwwapi.Payloads;
using workshop.wwwapi.Repository;

namespace workshop.wwwapi.Endpoints
{
    public static class SurgeryEndpoint
    {

        //TODO: Add additional endpoints in here according to the requirements in the README.md 
        public static void ConfigurePatientEndpoint(this WebApplication app)
        {
            var surgeryGroup = app.MapGroup("surgery");
            var patientGroup = app.MapGroup("surgery/patients");
            var doctorGroup = app.MapGroup("surgery/doctors");
            var appointmentGroup = app.MapGroup("surgery/appointments");

            patientGroup.MapGet("", GetPatients);
            patientGroup.MapGet("{id}", GetPatientByID);
            patientGroup.MapPost("", CreatePatient);
            doctorGroup.MapGet("", GetDoctors);
            doctorGroup.MapGet("{id}", GetDoctorByID);
            doctorGroup.MapPost("", CreateDoctor);
            appointmentGroup.MapGet("", GetAppointments);
            appointmentGroup.MapGet("{id}", GetAppointmentsByID);
            appointmentGroup.MapGet("/by_doctor/{id}", GetAppointmentsByDoctor);
            appointmentGroup.MapGet("/by_patient/{id}", GetAppointmentsByPatient);
            appointmentGroup.MapPost("", CreateAppointment);
        }

        // --- Patients ---
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetPatients(IRepository<Patient> repository1)
        {
            Payload < IEnumerable < PatientDTO >> payload = new();
            
            // Create DTO
            /*List<PatientDTO> pDTO = new List<PatientDTO>();
            foreach (var patient in await repository.GetAll())
            {
                pDTO.Add( 
                    new PatientDTO()
                    {
                        Name = patient.FullName,
                        //DoctorName = repository.
                    } 
                );

            }
            // Send DTO
            payload.data = pDTO;*/
            return TypedResults.Ok(await repository1.GetAll());
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetPatientByID(IRepository<Patient> repository2, int id)
        {
            return TypedResults.Ok(await repository2.GetByID(id));
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> CreatePatient(IRepository<Patient> repository3, string patientFullName)
        {
            return TypedResults.Ok(await repository3.Insert(new Patient() { FullName = patientFullName } ));
        }

        // --- Doctors ---
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetDoctors(IRepository<Doctor> repository4)
        {
            return TypedResults.Ok(await repository4.GetAll());
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetDoctorByID(IRepository<Doctor> repository5, int id)
        {
            return TypedResults.Ok(await repository5.GetByID(id));
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> CreateDoctor(IRepository<Doctor> repository6, string doctorFullName)
        {
            return TypedResults.Ok(await repository6.Insert(new Doctor() { FullName = doctorFullName } ));
        }

        // --- Appointments ---
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetAppointmentsByID(IRepository<Appointment> repository7, int id)
        {
            return TypedResults.Ok(await repository7.GetByID(id));
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetAppointments(IRepository<Appointment> repository8)
        {
            return TypedResults.Ok(await repository8.GetAll());
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetAppointmentsByDoctor(IRepository<Doctor> repository9, int id)
        {
            DoctorRepository pRepos = (DoctorRepository)repository9;
            return TypedResults.Ok(await pRepos.GetDoctorAppointments(id));
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetAppointmentsByPatient(IRepository<Patient> repository10, int id)
        {
            PatientRepository pRepos = (PatientRepository)repository10;
            return TypedResults.Ok(await pRepos.GetPatientAppointments(id));
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> CreateAppointment(IRepository<Appointment> repository11, Appointment appointment)
        {
            return TypedResults.Ok(await repository11.Insert(appointment));
        }
    }
}