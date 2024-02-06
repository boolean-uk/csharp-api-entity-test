using Microsoft.AspNetCore.Mvc;
using workshop.wwwapi.Models;
using workshop.wwwapi.Repository;
using workshop.wwwapi.Services;

namespace workshop.wwwapi.Endpoints
{
    public static class AppointmentEndpoint
    {
        public static void ConfigureAppointmentEndpoint(this WebApplication app)
        {
            var group = app.MapGroup("/appointments");

            group.MapGet("/", GetAll);
            group.MapGet("/patients/{id}", GetByPatient);
            group.MapGet("/doctors/{id}", GetByDoctor);
            group.MapGet("/doctors/{doctorId}/patients/{patientId}", GetByDoctorAndPatient);
            group.MapGet("/patients/{patientId}/doctors/{doctorId}", GetByDoctorAndPatient);
            group.MapPost("/", Create);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetAll(IAppointmentRepository repository)
        {
            IEnumerable<Appointment> appointments = await repository.Get();

            if (appointments.Count() == 0)
                return TypedResults.NotFound();

            IEnumerable<OutputAppointment> outputAppointments = AppointmentDtoManager.Convert(appointments);
            return TypedResults.Ok(outputAppointments);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetByPatient(IAppointmentRepository repository, int id)
        {
            IEnumerable<Appointment?> appointments = await repository.GetByPatient(id);

            if (appointments.Count() == 0)
                return TypedResults.NotFound();

            IEnumerable<OutputAppointment> outputAppointment = AppointmentDtoManager.Convert(appointments);
            return TypedResults.Ok(outputAppointment);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetByDoctor(IAppointmentRepository repository, int id)
        {
            IEnumerable<Appointment?> appointments = await repository.GetByDoctor(id);

            if (appointments.Count() == 0)
                return TypedResults.NotFound();

            IEnumerable<OutputAppointment> outputAppointment = AppointmentDtoManager.Convert(appointments);
            return TypedResults.Ok(outputAppointment);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetByDoctorAndPatient(IAppointmentRepository repository, int doctorId, int patientId)
        {
            IEnumerable<Appointment?> appointments = await repository.GetByDoctorAndPatient(doctorId, patientId);

            if (appointments.Count() == 0)
                return TypedResults.NotFound();

            IEnumerable<OutputAppointment> outputAppointment = AppointmentDtoManager.Convert(appointments);
            return TypedResults.Ok(outputAppointment);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetByPatientAndDoctor(IAppointmentRepository repository, int doctorId, int patientId)
        {
            IEnumerable<Appointment?> appointments = await repository.GetByDoctorAndPatient(doctorId, patientId);

            if (appointments.Count() == 0)
                return TypedResults.NotFound();

            IEnumerable<OutputAppointment> outputAppointment = AppointmentDtoManager.Convert(appointments);
            return TypedResults.Ok(outputAppointment);
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        public static async Task<IResult> Create(IAppointmentRepository appointmentRepository, IDoctorRepository doctorRepository, IPatientRepository patientRepository, InputAppointment inputAppointment)
        {
            Doctor doctor = await doctorRepository.Get(inputAppointment.DoctorId);
            if (doctor == null)
                return TypedResults.BadRequest("Doctor not found");

            Patient patient = await patientRepository.Get(inputAppointment.PatientId);
            if (patient == null)
                return TypedResults.BadRequest("Patient not found");

            Appointment appointment = new Appointment
            {
                DoctorId = inputAppointment.DoctorId,
                Doctor = doctor,
                PatientId = inputAppointment.PatientId,
                Patient = patient,
                Booking = inputAppointment.Booking,
                Type = inputAppointment.Type
            };

            Appointment? result = await appointmentRepository.Create(appointment);
            if (result == null)
                return TypedResults.BadRequest();

            OutputAppointment outputAppointment = AppointmentDtoManager.Convert(result);
            return TypedResults.Created("url", outputAppointment);
        }
    }
}
