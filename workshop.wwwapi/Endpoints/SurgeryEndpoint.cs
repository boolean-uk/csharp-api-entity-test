using Microsoft.AspNetCore.Mvc;
using workshop.wwwapi.Models;
using workshop.wwwapi.Models.PureModels;
using workshop.wwwapi.Models.TransferModels;
using workshop.wwwapi.Repository;

namespace workshop.wwwapi.Endpoints
{
    public static class SurgeryEndpoint
    {
        //TODO:  add additional endpoints in here according to the requirements in the README.md 
        public static void ConfigurePatientEndpoint(this WebApplication app)
        {
            var surgeryGroup = app.MapGroup("surgery");
            var patientSurgury = app.MapGroup("surgery/patients");

            patientSurgury.MapGet("/", GetPatients);
            patientSurgury.MapPost("/", CreatePatient);
            patientSurgury.MapGet("/{id}", GetSpecificPatient);

            surgeryGroup.MapGet("/doctors", GetDoctors);
            surgeryGroup.MapGet("/appointmentsbydoctor/{id}", GetAppointmentsByDoctor);
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetPatients(IRepository repository)
        {
            var patients = await repository.GetPatients();


            IEnumerable<PatientDTO> patientsOut = patients.Select(p => new PatientDTO(p.Id, p.FullName));
            Payload<IEnumerable<PatientDTO>> payload = new Payload<IEnumerable<PatientDTO>>(patientsOut);

            return TypedResults.Ok(payload);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        private static async Task<IResult> GetSpecificPatient(IRepository repository, int id) 
        {
            var patient = await repository.GetPatientById(id);
            if (patient == null) 
            {
                return TypedResults.NotFound("No patient with the provided Id could be found");
            }

            PatientDTO patientOut = new PatientDTO(patient.Id, patient.FullName);
            Payload<PatientDTO> payload = new Payload<PatientDTO>(patientOut);

            return TypedResults.Ok(payload);
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        private static async Task<IResult> CreatePatient(IRepository repository, PatientInputDTO patientPost) 
        {
            Patient postedPatient = await repository.PostPatient(new Patient() { FullName = patientPost.fullName});

            Payload<Patient> payload = new Payload<Patient>(postedPatient);
            return TypedResults.Created($"/{postedPatient.Id}", payload);

        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetDoctors(IRepository repository)
        {
            var doctors = await repository.GetDoctors();


            IEnumerable<DoctorDTO> patientsOut = doctors.Select(d => new DoctorDTO(d.Id, d.FullName));
            Payload<IEnumerable<DoctorDTO>> payload = new Payload<IEnumerable<DoctorDTO>>(patientsOut);

            return TypedResults.Ok(payload);
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetAppointmentsByDoctor(IRepository repository, int id)
        {
            return TypedResults.Ok(await repository.GetAppointmentsByDoctor(id));
        }
    }
}
