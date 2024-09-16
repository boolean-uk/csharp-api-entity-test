using Microsoft.AspNetCore.Mvc;
using workshop.wwwapi.Models.PureModels;
using workshop.wwwapi.Models.TransferInputModels;
using workshop.wwwapi.Models.TransferModels.Appointments;
using workshop.wwwapi.Models;
using workshop.wwwapi.Repository;

namespace workshop.wwwapi.Endpoints
{
    public static class AppointmentEndpoint
    {
        public static void ConfigureAppointmentEndpoint(this WebApplication app)
        {
            var appointments = app.MapGroup("/appointments");


            // Appointments
            appointments.MapGet("/", GetAllAppointments);
            appointments.MapGet("/{docId}-{patId}", GetAppointmentsById);
            appointments.MapGet("/doctors/{id}", GetAppointmentsForDoctor);
            appointments.MapGet("/patients/{id}", GetAppointmentsForPatients);
            appointments.MapGet("/{id}", GetSpecificAppointmentById);
            appointments.MapPost("/", PostAppointment);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetAllAppointments(IRepository repository)
        {
            IEnumerable<Appointment> appointments = await repository.GetAppointments();

            IEnumerable<AppointmentDTO> appOut = appointments.Select(a => new AppointmentDTO(a.Booking, a.PatientId, a.DoctorId, a.AppointmentType, a.Doctor, a.Patient)).ToList();
            Payload<IEnumerable<AppointmentDTO>> payload = new Payload<IEnumerable<AppointmentDTO>>(appOut);
            return TypedResults.Ok(payload);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> GetAppointmentsForDoctor(IRepository repository, int id)
        {
            IEnumerable<Appointment> appointments = await repository.GetAppointmentsForDoctors(id);
            if (appointments == null || appointments.Count() == 0)
            {
                return TypedResults.NotFound($"No appointments for doctor with id {id}.");
            }

            IEnumerable<AppointmentDTO> appointmentsOut = appointments.Select(a => new AppointmentDTO(a.Booking, a.PatientId, a.DoctorId, a.AppointmentType, a.Doctor, a.Patient));
            Payload<IEnumerable<AppointmentDTO>> payload = new Payload<IEnumerable<AppointmentDTO>>(appointmentsOut);
            return TypedResults.Ok(payload);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> GetAppointmentsForPatients(IRepository repository, int id)
        {
            IEnumerable<Appointment> appointments = await repository.GetAppointmentsForPatients(id);
            if (appointments == null || appointments.Count() == 0)
            {
                return TypedResults.NotFound($"No appointments for patient with id {id}.");
            }

            IEnumerable<AppointmentDTO> appointmentsOut = appointments.Select(a => new AppointmentDTO(a.Booking, a.PatientId, a.DoctorId, a.AppointmentType, a.Doctor, a.Patient));
            Payload<IEnumerable<AppointmentDTO>> payload = new Payload<IEnumerable<AppointmentDTO>>(appointmentsOut);
            return TypedResults.Ok(payload);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> GetAppointmentsById(IRepository repository, int docId, int patId)
        {
            IEnumerable<Appointment> appointments = await repository.GetAppointmentsByIds(docId, patId);
            if (appointments == null || appointments.Count() == 0)
            {
                return TypedResults.NotFound($"No appointments for doctor-patient combination with id {docId} and {patId}.");
            }

            IEnumerable<AppointmentDTO> appointmentsOut = appointments.Select(a => new AppointmentDTO(a.Booking, a.PatientId, a.DoctorId, a.AppointmentType, a.Doctor, a.Patient));
            Payload<IEnumerable<AppointmentDTO>> payload = new Payload<IEnumerable<AppointmentDTO>>(appointmentsOut);
            return TypedResults.Ok(payload);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        private static async Task<IResult> GetSpecificAppointmentById(IRepository repository, int id) 
        {
            Appointment? appointment = await repository.GetAppointmentByAppointmentId(id);
            if (appointment == null) 
            {
                return TypedResults.NotFound($"No appointment of the provided id {id} could be found.");
            }
            AppointmentDTO appointmentOut = new AppointmentDTO(appointment.Booking, appointment.PatientId, appointment.DoctorId, appointment.AppointmentType, appointment.Doctor, appointment.Patient);
            Payload<AppointmentDTO> payload = new Payload<AppointmentDTO>(appointmentOut);
            return TypedResults.Ok(payload);
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> PostAppointment(IRepository repository, AppointmentInputDTO appPost)
        {
            bool invalidDoctorId = await repository.GetSpecificDoctor(appPost.doctorId) == null;
            bool invalidPatientId = await repository.GetPatientById(appPost.patientId) == null;
            if (invalidDoctorId)
            {
                return TypedResults.NotFound($"No doctor with the provided id {appPost.doctorId} found.");
            }
            if (invalidPatientId)
            {
                return TypedResults.NotFound($"No patient with the provided id {appPost.patientId} found.");
            }

            Appointment app = await repository.PostAppointment(new Appointment() { Booking = appPost.Booking, DoctorId = appPost.doctorId, PatientId = appPost.patientId });

            AppointmentDTO appOut = new AppointmentDTO(app.Booking, app.PatientId, app.DoctorId, app.AppointmentType, app.Doctor, app.Patient);
            Payload<AppointmentDTO> payload = new Payload<AppointmentDTO>(appOut);
            return TypedResults.Created($"/{appOut.doctorId}-{appOut.patientId}", payload);
        }

    }
}
