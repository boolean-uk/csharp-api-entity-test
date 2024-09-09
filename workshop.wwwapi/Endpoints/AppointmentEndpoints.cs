using Microsoft.AspNetCore.Mvc;
using workshop.wwwapi.DTOs;
using workshop.wwwapi.Models;
using workshop.wwwapi.Repository;

namespace workshop.wwwapi.Endpoints
{
    public static class AppointmentEndpoints
    {
        public static void ConfigureAppointmentEndpoints(this WebApplication app)
        {
            var appointment = app.MapGroup("/appointments");
            appointment.MapGet("", getAppointments);
            appointment.MapGet("/{doctorId}/{patientId}", getAppointment);
            appointment.MapGet("/{doctorId}", getAppointmentByDoctor);
            appointment.MapGet("/{patientId}", getAppointmentByPatient);
            appointment.MapPost("", createAppointment);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        private static async Task<IResult> getAppointments(IAppointmentRepo appointmentRepo)
        {
            try
            {
                var appointments = await appointmentRepo.GetAppointments();
                List<AppointmentDTO> DTOs = new List<AppointmentDTO>();
                foreach (var p in appointments)
                {

                    AppointmentDTO appointmentDTO = new AppointmentDTO();

                    DoctorDTO doctorDTO = new DoctorDTO();
                    PatientDTO patientDTO = new PatientDTO();

                    appointmentDTO.Booking = p.Booking;
                    appointmentDTO.Patient = p.Patient;
                    appointmentDTO.Doctor = p.Doctor;

                    DTOs.Add(appointmentDTO);
                }
                return TypedResults.Ok(DTOs);
            }
            catch (Exception ex)
            {
                return TypedResults.Problem(ex.Message);
            }
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        private static async Task<IResult> getAppointment(IAppointmentRepo appointmentRepo, int doctorId, int patientId)
        {
            try
            {
                var appointment = await appointmentRepo.GetAppointment(doctorId, patientId);
                AppointmentDTO appointmentDTO = new AppointmentDTO();
                appointmentDTO.Booking = appointment.Booking;
                appointmentDTO.PatientName = appointment.Patient.FullName;
                appointmentDTO.DoctorName = appointment.Doctor.FullName;
                return TypedResults.Ok(appointmentDTO);
            }
            catch (Exception ex)
            {
                return TypedResults.NotFound(ex.Message);
            }
        }

        [ProducesResponseType(StatusCodes.Status200OK)]

        private static async Task<IResult> createAppointment(IAppointmentRepo appointmentRepo, AppointmentDTO appointment)
        {
            try
            {
                AppointmentDTO DTO = new AppointmentDTO();
                var result = await appointmentRepo.CreateAppointment(new Appointment() { Booking = appointment.Booking });

                DTO.DoctorName = result.Doctor.FullName;
                DTO.PatientName = result.Patient.FullName;

                return TypedResults.Ok(DTO);
            }
            catch (Exception ex)
            {
                return TypedResults.Problem(ex.Message);
            }
        }

        [ProducesResponseType(StatusCodes.Status200OK)]

        private static async Task<IResult> getAppointmentByDoctor(IAppointmentRepo appointmentRepo, int doctorId)
        {
            try
            {
                var appointments = await appointmentRepo.GetAppointmentByDoctor(doctorId);
                List<AppointmentDTO> DTOs = new List<AppointmentDTO>();

                foreach (var appointment in appointments)
                {
                    AppointmentDTO appointmentDTO = new AppointmentDTO();
                    appointmentDTO.Booking = appointment.Booking;
                    appointmentDTO.PatientName = appointment.Patient.FullName;
                    appointmentDTO.DoctorName = appointment.Doctor.FullName;
                    DTOs.Add(appointmentDTO);
                }
                
                return TypedResults.Ok(appointmentDTO);
            }
            catch (Exception ex)
            {
                return TypedResults.NotFound(ex.Message);
            }
        }

        [ProducesResponseType(StatusCodes.Status200OK)]

        private static async Task<IResult> getAppointmentByPatient(IAppointmentRepo appointmentRepo, int patientId)
        {
            try
            {
                var appointment = await appointmentRepo.GetAppointmentByPatient(patientId);
                AppointmentDTO appointmentDTO = new AppointmentDTO();
                appointmentDTO.Booking = appointment.Booking;
                appointmentDTO.PatientName = appointment.Patient.FullName;
                appointmentDTO.DoctorName = appointment.Doctor.FullName;
                return TypedResults.Ok(appointmentDTO);
            }
            catch (Exception ex)
            {
                return TypedResults.NotFound(ex.Message);
            }
        }
    }
}
