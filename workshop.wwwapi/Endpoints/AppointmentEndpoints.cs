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
            var appointments = app.MapGroup("/appointments");

            appointments.MapGet("", GetAppointments);
            appointments.MapGet("/patient/{id}", GetAppointmentsByPatient);
            appointments.MapGet("/doctor/{id}", GetAppointmentsByDoctor);
            appointments.MapGet("{doctorId}/{patientId}", GetAppointmentById);
            appointments.MapPost("", CreateAppointment);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetAppointments(IAppointmentRepository appointmentRepository)
        {
            try
            {
                var result = await appointmentRepository.GetAllAppointments();

                List<AppointmentDTO> alist = new List<AppointmentDTO>();

                foreach (var a in result)
                {
                    AppointmentDTO appointmentDTO = new AppointmentDTO();
                    DoctorDTO doctorDTO = new DoctorDTO();
                    PatientDTO patientDTO = new PatientDTO();
                   
                    doctorDTO.FullName = a.Doctor.FullName;
                    patientDTO.FullName = a.Patient.FullName;

                    appointmentDTO.appointmentDate = a.ApointementDate;
                    appointmentDTO.doctor = doctorDTO;
                    appointmentDTO.patient = patientDTO;

                    alist.Add(appointmentDTO);
                }
                return TypedResults.Ok(alist);
            }
            catch (Exception ex)
            {
                return TypedResults.Problem(ex.Message);
            }
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> GetAppointmentsByPatient(IAppointmentRepository appointmentRepository, int id)
        {
            try
            {
                var result = await appointmentRepository.GetAppointmentByPatient(id);

                List<AppointmentDTO> pAppointments = new List<AppointmentDTO>();

                foreach (var a in result)
                {
                    AppointmentDTO appointmentDTO = new AppointmentDTO();
                    DoctorDTO doctorDTO = new DoctorDTO();
                    PatientDTO patientDTO = new PatientDTO();

                    doctorDTO.FullName = a.Doctor.FullName;
                    patientDTO.FullName = a.Patient.FullName;

                    appointmentDTO.appointmentDate = a.ApointementDate;
                    appointmentDTO.doctor = doctorDTO;
                    appointmentDTO.patient = patientDTO;

                    pAppointments.Add(appointmentDTO);
                }
                return TypedResults.Ok(pAppointments);
            }
            catch (Exception ex)
            {
                return TypedResults.NotFound("Doctor not found!");
            }
        }


        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> GetAppointmentsByDoctor(IAppointmentRepository appointmentRepository, int id)
        {
            try
            {
                var result = await appointmentRepository.GetAppointmentByDoctor(id);

                List<AppointmentDTO> dAppointments = new List<AppointmentDTO>();

                foreach (var a in result) 
                {
                    AppointmentDTO appointmentDTO = new AppointmentDTO();
                    DoctorDTO doctorDTO = new DoctorDTO();
                    PatientDTO patientDTO = new PatientDTO();

                    doctorDTO.FullName = a.Doctor.FullName;
                    patientDTO.FullName = a.Patient.FullName;

                    appointmentDTO.appointmentDate = a.ApointementDate;
                    appointmentDTO.doctor = doctorDTO;
                    appointmentDTO.patient = patientDTO;

                    dAppointments.Add(appointmentDTO);
                }
                return TypedResults.Ok(dAppointments);
            }
            catch (Exception ex)
            {
                return TypedResults.NotFound("Doctor not found!");
            }
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> GetAppointmentById(IAppointmentRepository appointmentRepository, int doctorId, int patientId)
        {
            try
            {
                var target = await appointmentRepository.GetAppointmentById(doctorId, patientId);

                AppointmentDTO appointmentDTO = new AppointmentDTO
                {
                    appointmentDate = target.ApointementDate,
                    doctor = new DoctorDTO() { FullName = target.Doctor.FullName },
                    patient = new PatientDTO() { FullName = target.Patient.FullName }
                };

                return TypedResults.Ok(appointmentDTO);
            }
            catch (Exception)
            {

                return TypedResults.NotFound("No appointment found!");
            }
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public static async Task<IResult> CreateAppointment(IAppointmentRepository appointmentRepository, AppointmentCreateDTO appointment)
        {
            try
            {
                Appointment newAppointment = new Appointment() { 
                    ApointementDate = appointment.AppointmentDate, 
                    DoctorId = appointment.doctorId, 
                    PatientId = appointment.patientId 
                };

                var result = await appointmentRepository.CreateAppointment(newAppointment);

                var createdAppointment = await appointmentRepository.GetAppointmentById(result.DoctorId, result.PatientId);

                AppointmentDTO appointmentDTO = new AppointmentDTO { 
                    appointmentDate = createdAppointment.ApointementDate, 
                    doctor = new DoctorDTO() { FullName = createdAppointment.Doctor.FullName }, 
                    patient = new PatientDTO { FullName = createdAppointment.Patient.FullName } 
                };

                return TypedResults.Ok(appointmentDTO);
            }
            catch (Exception ex)
            {
                return TypedResults.BadRequest(ex.Message);
            }

        }
    }
}
