using Microsoft.AspNetCore.Mvc;
using workshop.wwwapi.DTO;
using workshop.wwwapi.Repository;
using workshop.wwwapi.Models.Payloads;
using workshop.wwwapi.Models;

namespace workshop.wwwapi.Endpoints
{

    

    public static class SurgeryEndpoint
    {
        //TODO:  add additional endpoints in here according to the requirements in the README.md 
        public static void ConfigurePatientEndpoint(this WebApplication app)
        {
            var surgeryGroup = app.MapGroup("surgery");

            surgeryGroup.MapGet("/patients", GetPatients);
            surgeryGroup.MapGet("/patient/[{id}", GetPatientById);
            surgeryGroup.MapPost("/patients", AddPatient);
            surgeryGroup.MapGet("/doctors", GetDoctors);
            surgeryGroup.MapGet("/doctor/{id}", GetDoctorById);

            surgeryGroup.MapGet("/appointments", GetAllAppointments);
            surgeryGroup.MapGet("/appointmentsbydoctor/{id}", GetAppointmentsByDoctor);
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetPatients(IRepository repository)
        {
            var patients = await repository.GetPatients();
            var patientOnlyDTO = new List<PatientOnlyDTO>();
            foreach (var patient in patients)
            {
                patientOnlyDTO.Add(new PatientOnlyDTO(patient));
            }
            return TypedResults.Ok(patientOnlyDTO);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetPatientById(int id, IRepository repository)
        {
            var patient = await repository.GetPatientById(id);
            if (patient == null)
            {
                return TypedResults.NotFound($"Patient with id {id} could not be found");
            }
            return TypedResults.Ok(new PatientOnlyDTO(patient));
        }

        public static async Task<IResult> AddPatient(PatientPostPayload payload, IRepository repository)
        {
            if (payload.full_name == null || payload.full_name == "") {
                return TypedResults.BadRequest($"A non-empty name is required!");
            }

            Patient? patient = await repository.AddPatient(payload.full_name);
            if (patient == null)
            {
                return TypedResults.Problem("Something occured whilest trying to add patient...");
            }
            return TypedResults.Created($"/surgery/patients", patient);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetDoctors(IRepository repository)
        {
            var doctors = await repository.GetDoctors();
            var doctorOnlyDTO = new List<DoctorsOnlyDTO>();
            foreach (var doctor in doctors)
            {
                doctorOnlyDTO.Add(new DoctorsOnlyDTO(doctor));
            }
            return TypedResults.Ok(doctorOnlyDTO);
        }

        public static async Task<IResult> GetDoctorById(int id, IRepository repository)
        {
            var doctor = await repository.GetDoctorById(id);
            if (doctor == null)
            {
                return TypedResults.NotFound($"Doctor with id {id} could not be found");
            }
            return TypedResults.Ok(new DoctorsOnlyDTO(doctor));
        }

        public static async Task<IResult> GetAllAppointments(IRepository repository)
        {
            var appointments = await repository.GetAllAppointments();
            var appointmentsPatientDoctorDTO = new List<AppointmentsPatientDoctorDTO>();
            foreach (var appointment in appointments)
            {
                appointmentsPatientDoctorDTO.Add(new AppointmentsPatientDoctorDTO(appointment));
            }

            return TypedResults.Ok(appointmentsPatientDoctorDTO);
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetAppointmentsByDoctor(IRepository repository, int id)
        {
            return TypedResults.Ok(await repository.GetAppointmentsByDoctor(id));
        }
    }
}
