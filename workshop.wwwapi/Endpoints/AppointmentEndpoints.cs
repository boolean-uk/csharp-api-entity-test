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
            // appointments.MapGet("/patient/{id}", GetAppointmentsByPatient);
            appointments.MapGet("/doctor/{id}", GetAppointmentsByDoctor);

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

                    doctorDTO.Name = a.Doctor.FullName;
                    patientDTO.Name = a.Patient.FullName;

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

                    doctorDTO.Name = a.Doctor.FullName;
                    patientDTO.Name = a.Patient.FullName;

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
      
    }
}
