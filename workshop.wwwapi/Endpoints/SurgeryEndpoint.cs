using Microsoft.AspNetCore.Mvc;
using workshop.wwwapi.Models;
using workshop.wwwapi.Models.DTO;
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
            surgeryGroup.MapPost("/patients/{name}", AddPatient);

            surgeryGroup.MapGet("/doctors", GetDoctors);
            surgeryGroup.MapGet("/doctors/{id}", GetDoctor);
            surgeryGroup.MapPost("/doctors/{name}", AddDoctor);

            surgeryGroup.MapGet("/appointments", GetAppointments);
            surgeryGroup.MapGet("/appointmentsbydoctor/{id}", GetAppointmentsByDoctor);
            surgeryGroup.MapGet("/appointmentsbypatient/{id}", GetAppointmentsByPatient);
            surgeryGroup.MapPost("/addappointment", AddAppointment);
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetPatients(IRepository repository)
        {
            IEnumerable<Patient> patients = await repository.GetPatients();
            List<PatientDTO> response = new List<PatientDTO>();

            foreach(Patient p in patients)
            {
                response.Add(DTOgenerator.GeneratePatientDTO(p));
            }

            return TypedResults.Ok(response);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> GetPatient(IRepository repository, int id)
        {
            Patient p = await repository.GetPatient(id);
            return p != null ? TypedResults.Ok(DTOgenerator.GeneratePatientDTO(p)) : TypedResults.NotFound("Patient not found");
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        public static async Task<IResult> AddPatient(IRepository repository, string name)
        {
            Patient p = await repository.AddPatient(name);
            return TypedResults.Ok(DTOgenerator.GeneratePatientDTO(p));
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetDoctors(IRepository repository)
        {
            IEnumerable<Doctor> doctors = await repository.GetDoctors();
            List<DoctorDTO> response = new List<DoctorDTO>();

            foreach (Doctor d in doctors)
            {
                response.Add(DTOgenerator.GenerateDoctorDTO(d));
            }

            return TypedResults.Ok(response);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> GetDoctor(IRepository repository, int id)
        {

            Doctor d = await repository.GetDoctor(id);
            return d != null ? TypedResults.Ok(DTOgenerator.GenerateDoctorDTO(d)) : TypedResults.NotFound("Doctor not found");
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        public static async Task<IResult> AddDoctor(IRepository repository, string name)
        {
            Doctor d = await repository.AddDoctor(name);
            return TypedResults.Ok(DTOgenerator.GenerateDoctorDTO(d));
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> GetAppointments(IRepository repository)
        {
            IEnumerable<Appointment> appointments = await repository.GetAppointments();
            List<AppointmentDTO> response = new List<AppointmentDTO>();
            foreach(Appointment a in appointments)
            {
                response.Add(DTOgenerator.GenerateAppointmentDTO(a));
            }
            return appointments.Count() != 0 ? TypedResults.Ok(response) : TypedResults.NotFound();
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> GetAppointmentsByDoctor(IRepository repository, int id)
        {
            IEnumerable<Appointment> appointments = await repository.GetAppointmentsByDoctor(id);
            List<AppointmentDTO> response = new List<AppointmentDTO>();
            foreach (Appointment a in appointments)
            {
                response.Add(DTOgenerator.GenerateAppointmentDTO(a));
            }
            return response.Count() != 0 ? TypedResults.Ok(response) : TypedResults.NotFound();
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> GetAppointmentsByPatient(IRepository repository, int id)
        {
            IEnumerable<Appointment> appointments = await repository.GetAppointmentsByPatient(id);
            List<AppointmentDTO> response = new List<AppointmentDTO>();
            foreach(Appointment a in appointments)
            {
                response.Add(DTOgenerator.GenerateAppointmentDTO(a));
            }
            return response.Count() != 0 ? TypedResults.Ok(response) : TypedResults.NotFound();
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        public static async Task<IResult> AddAppointment(IRepository repository, Appointment a)
        {
            Appointment appointment = await repository.AddAppointment(a);
            return TypedResults.Created("/", DTOgenerator.GenerateAppointmentDTO(appointment));
        }
    }
}
