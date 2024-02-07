using Microsoft.AspNetCore.Mvc;
using workshop.wwwapi.DTO;
using workshop.wwwapi.Models;
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
            surgeryGroup.MapPost("patients", CreatePatient);
            surgeryGroup.MapGet("/doctors", GetDoctors);
            surgeryGroup.MapGet("/doctors/{id}", GetDoctor);
            surgeryGroup.MapPost("doctors", CreateDoctor);
            surgeryGroup.MapGet("/appointments", GetAppointments);
            surgeryGroup.MapGet("/appointmentsbydoctor/{id}", GetAppointmentsByDoctor);
            surgeryGroup.MapGet("/appointmentsbypatient/{id}", GetAppointmentsByPatient);
            surgeryGroup.MapGet("/appointments/{patientId}/{doctorId}", GetAppointment);
            surgeryGroup.MapPost("appointments", CreateAppointment);
        }

        //              Patients
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetPatients(IRepository repository)
        {
            var patients = await repository.GetPatients();
            return TypedResults.Ok(Service.Service.toPatientDto(patients.ToList()));
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> GetPatient(IRepository repository, int id)
        {
            var patient = await repository.GetPatient(id);

            if (patient == null) return TypedResults.NotFound();

            return TypedResults.Ok(Service.Service.toPatientDto(patient));
        }
        [ProducesResponseType(StatusCodes.Status201Created)]
        public static async Task<IResult> CreatePatient(IRepository repository, PatientDto patientDto)
        {
            Patient patient = Service.Service.toPatient(patientDto);
            var result = await repository.CreatePatient(patient);

            return TypedResults.Created($"/surgery/patients/{result.Id}", Service.Service.toPatientDto(result));
        }


        //                  Doctor
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetDoctors(IRepository repository)
        {
            var doctors = await repository.GetDoctors();

            return TypedResults.Ok(Service.Service.toDoctorDto(doctors.ToList()));
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> GetDoctor(IRepository repository, int id)
        {
            var doctor = await repository.GetDoctor(id);

            if (doctor == null) return TypedResults.NotFound();

            return TypedResults.Ok(Service.Service.toDoctorDto(doctor));
        }
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public static async Task<IResult> CreateDoctor(IRepository repository, DoctorDto doctorDto)
        {
            Doctor doctor = Service.Service.toDoctor(doctorDto);
            var result = await repository.CreateDoctor(doctor);

            return TypedResults.Created($"surgery/doctors/{result.Id}", Service.Service.toDoctorDto(result));
        }


        //                  Appointments
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetAppointments(IRepository repository)
        {
            IEnumerable<Appointment> appointments = await repository.GetAppointments();
            return TypedResults.Ok(Service.Service.toAppointmentDto(appointments.ToList()));
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> GetAppointment(IRepository repository, int patientId, int doctorId)
        {
            Appointment appointment = await repository.GetAppointment(patientId, doctorId);
            if (appointment == null) return TypedResults.NotFound();


            return TypedResults.Ok(Service.Service.toAppointmentDto(appointment));
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> GetAppointmentsByDoctor(IRepository repository, int id)
        {
            IEnumerable<Appointment> appointments = await repository.GetAppointmentsByDoctor(id);
            if ( appointments == null ) return TypedResults.NotFound();
            return TypedResults.Ok(Service.Service.toAppointmentDto(appointments.ToList()));
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> GetAppointmentsByPatient(IRepository repository, int id)
        {
            IEnumerable<Appointment> appointments = await repository.GetAppointmentsByPatient(id);
            if (appointments == null) return TypedResults.NotFound();
            return TypedResults.Ok(Service.Service.toAppointmentDto(appointments.ToList()));
        }
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public static async Task<IResult> CreateAppointment(IRepository repository, AppointmentPost appointmentDto)
        {
            Appointment appointment = Service.Service.toAppointment(appointmentDto);

            if ( 
                repository.GetPatient(appointment.PatientId) == null | 
                repository.GetDoctor(appointment.DoctorId) == null
                ) return TypedResults.NotFound();
            if (repository.GetAppointment(appointment.PatientId, appointment.DoctorId) != null)
                return TypedResults.BadRequest("Appointment already exists");

            var result = await repository.CreateAppointment(appointment);

            return TypedResults.Created($"/surgery/appointments/{appointment.PatientId}/{appointment.DoctorId}", 
                Service.Service.toAppointmentDto(result));
        }
    }
}
