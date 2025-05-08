using Microsoft.AspNetCore.Mvc;
using workshop.wwwapi.DTO;
using workshop.wwwapi.Models;
using workshop.wwwapi.Repository;

namespace workshop.wwwapi.Endpoints
{
    public static class AppointmentEndpoint
    {
        public static void ConfigureAppointmentEndpoint(this WebApplication app)
        {
            app.MapGet("/appointments", GetAppointments);
            app.MapGet("/appointments/{id}", GetAppointmentById);
            app.MapGet("/appointmentsbydoctor/{id}", GetAppointmentsByDoctor);
            app.MapGet("/appointmentsbypatient/{id}", GetAppointmentsByPatient);
            app.MapPost("/appointments", CreateAppointment);

        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetAppointments(IRepository repository)
        {
            AppointmentResponse appointmentResponse = new AppointmentResponse();

            var appointments = await repository.GetAppointments();

            foreach (Appointment appointment in appointments)
            {
                AppointmentDTO appointmentDTO = new AppointmentDTO() { PatientId = appointment.PatientId, DoctorId = appointment.DoctorId, Booking = appointment.Booking};
                appointmentResponse.appointments.Add(appointmentDTO);
            }

            return appointments != null ? TypedResults.Ok(appointmentResponse) : TypedResults.NotFound();

        }


        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetAppointmentById(IRepository repository, int patientId, int doctorId)
        {
            var appointments = await repository.GetAppointmentById(patientId, doctorId);
            AppointmentDTO appointmentDTO = new AppointmentDTO() { PatientId = appointments.PatientId, DoctorId = appointments.DoctorId, Booking = appointments.Booking };

            return appointments != null ? TypedResults.Ok(appointmentDTO) : TypedResults.NotFound();
        }



        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetAppointmentsByDoctor(IRepository repository, int id)
        {

            AppointmentResponse appointmentResponse = new AppointmentResponse();

            var appointments = await repository.GetAppointmentsByDoctor(id);

            foreach (Appointment appointment in appointments)
            {
                AppointmentDTO appointmentDTO = new AppointmentDTO() { PatientId = appointment.PatientId, DoctorId = appointment.DoctorId, Booking = appointment.Booking };
                appointmentResponse.appointments.Add(appointmentDTO);
            }

            return appointments != null ? TypedResults.Ok(appointmentResponse) : TypedResults.NotFound();
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetAppointmentsByPatient(IRepository repository, int id)
        {

            AppointmentResponse appointmentResponse = new AppointmentResponse();

            var appointments = await repository.GetAppointmentsByDoctor(id);

            foreach (Appointment appointment in appointments)
            {
                AppointmentDTO appointmentDTO = new AppointmentDTO() { PatientId = appointment.PatientId, DoctorId = appointment.DoctorId, Booking = appointment.Booking };
                appointmentResponse.appointments.Add(appointmentDTO);
            }

            return appointments != null ? TypedResults.Ok(appointmentResponse) : TypedResults.NotFound();
        }


        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> CreateAppointment(IRepository repository, Appointment appointment)
        {
            try
            {
                var addAppointment = await repository.CreateAppointment(new Appointment() { PatientId = appointment.PatientId, DoctorId = appointment.DoctorId, Booking = appointment.Booking });
                AppointmentDTO doctorDTO = new AppointmentDTO() { PatientId = addAppointment.PatientId, DoctorId = addAppointment.DoctorId, Booking = addAppointment.Booking };
                return TypedResults.Ok(addAppointment);
            }
            catch (Exception ex)
            {
                return TypedResults.NotFound();
            }
        }

    }
}
