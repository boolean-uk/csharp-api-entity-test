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
            appointment.MapGet("/doctor/{id}", getAppointmentByDoctor);
            appointment.MapGet("/patient/{id}", getAppointmentByPatient);
            appointment.MapPost("", createAppointment);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        private static async Task<IResult> getAppointments(IAppointmentRepo appointmentRepo)
        {
            try
            {
                var appointments = await appointmentRepo.GetAppointments();
                List<AppointmentDTO> DTOs = new List<AppointmentDTO>();
                foreach (var ap in appointments)
                {

                    AppointmentDTO appointmentDTO = new AppointmentDTO();

                    DoctorDTO doctorDTO = new DoctorDTO();
                    PatientDTO patientDTO = new PatientDTO();
                    
                    
                    doctorDTO.Name = ap.Doctor.FullName;
                    patientDTO.Name = ap.Patient.FullName;

                    appointmentDTO.Booking = ap.Booking;
                    appointmentDTO.Doctor = doctorDTO;
                    appointmentDTO.Patient = patientDTO;
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
                DoctorDTO doctorDTO = new DoctorDTO();
                PatientDTO patientDTO = new PatientDTO();


                doctorDTO.Name = appointment.Doctor.FullName;
                patientDTO.Name = appointment.Patient.FullName;
                appointmentDTO.Doctor = doctorDTO;
                appointmentDTO.Patient = patientDTO;
                /*
                appointmentDTO.PatientName = appointment.Patient.FullName;
                appointmentDTO.DoctorName = appointment.Doctor.FullName;
                */
                return TypedResults.Ok(appointmentDTO);
            }
            catch (Exception ex)
            {
                return TypedResults.NotFound(ex.Message);
            }
        }

        [ProducesResponseType(StatusCodes.Status200OK)]

        private static async Task<IResult> createAppointment(IAppointmentRepo appointmentRepo, AppointmentCreateDTO appointment)
        {
            try
            {
                var result = await appointmentRepo.CreateAppointment(new Appointment() { Booking = appointment.Booking, DoctorId = appointment.doctorID, PatientId = appointment.patientID });

                var createdAppointment = await appointmentRepo.GetAppointment(result.DoctorId, result.PatientId);

                AppointmentDTO DTO = new AppointmentDTO() { Booking = createdAppointment.Booking, Doctor = new DoctorDTO() { Name = createdAppointment.Doctor.FullName }, Patient = new PatientDTO() { Name = createdAppointment.Patient.FullName } };
                
                
                return TypedResults.Ok(DTO);
            }
            catch (Exception ex)
            {
                return TypedResults.Problem(ex.Message);
            }
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        private static async Task<IResult> getAppointmentByDoctor(IAppointmentRepo appointmentRepo, int id)
        {
            try
            {
                var appointments = await appointmentRepo.GetAppointmentByDoctor(id);
                List<AppointmentDTO> DTOs = new List<AppointmentDTO>();

                foreach (var ap in appointments)
                {

                    AppointmentDTO appointmentDTO = new AppointmentDTO();

                    DoctorDTO doctorDTO = new DoctorDTO();
                    PatientDTO patientDTO = new PatientDTO();


                    doctorDTO.Name = ap.Doctor.FullName;
                    patientDTO.Name = ap.Patient.FullName;

                    appointmentDTO.Booking = ap.Booking;
                    appointmentDTO.Doctor = doctorDTO;
                    appointmentDTO.Patient = patientDTO;
                    DTOs.Add(appointmentDTO);
                }

                return TypedResults.Ok(DTOs);
            }
            catch (Exception ex)
            {
                return TypedResults.NotFound(ex.Message);
            }
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        private static async Task<IResult> getAppointmentByPatient(IAppointmentRepo appointmentRepo, int id)
        {
            try
            {
                var appointments = await appointmentRepo.GetAppointmentByPatient(id);
                
                List<AppointmentDTO> DTOs = new List<AppointmentDTO>();

                foreach (var ap in appointments)
                {

                    AppointmentDTO appointmentDTO = new AppointmentDTO();

                    DoctorDTO doctorDTO = new DoctorDTO();
                    PatientDTO patientDTO = new PatientDTO(); 


                    doctorDTO.Name = ap.Doctor.FullName;
                    patientDTO.Name = ap.Patient.FullName;

                    appointmentDTO.Booking = ap.Booking;
                    appointmentDTO.Doctor = doctorDTO;
                    appointmentDTO.Patient = patientDTO;
                    DTOs.Add(appointmentDTO);
                }
                return TypedResults.Ok(DTOs);
            }
            catch (Exception ex)
            {
                return TypedResults.NotFound(ex.Message);
            }
        }
    }
}
