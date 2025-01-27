
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using workshop.wwwapi.Models;
using workshop.wwwapi.Repository;

namespace workshop.wwwapi.Endpoints
{
    public static class AppointmentEndpoint
    {
        public static void ConfigureAppointmentEndpoint(this WebApplication app)
        {
            var appointments = app.MapGroup("/appointments");
            appointments.MapGet("/", GetAppointments);
            appointments.MapPost("/", CreateAppointment);
        }        
        
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        private static async Task<IResult> GetAppointments(
            HttpContext context, 
            IRepository<Appointment> repo, 
            IRepository<Doctor> d_repo, 
            IRepository<Patient> p_repo, 
            int? patient_id, 
            int? doctor_id
            )
        {
            if (patient_id == null && doctor_id == null)      return await _GetAppointments(context, repo);
            else if (patient_id != null && doctor_id == null) return await _GetPatientAppontments(context, p_repo, patient_id.Value);
            else if (patient_id == null && doctor_id != null) return await _GetDoctorAppontments(context, d_repo, doctor_id.Value);
            else 
                return await _GetAppointment(context, repo, patient_id.Value, doctor_id.Value);
        }
        private static async Task<IResult> _GetAppointment(HttpContext context, IRepository<Appointment> repo, int patient_id, int doctor_id)
        {
            try
            {
                var a = await DTO.Response.Appointment.Get.DTO(repo,  doctor_id, patient_id );
                if (a == null) return TypedResults.NotFound($"Appointment with id[{doctor_id},{patient_id}] was not found");
                return TypedResults.Ok(a);
            }
            catch(Exception e )
            {
                return TypedResults.NotFound($"Appointment with id[{doctor_id},{patient_id}] was not found");
            }
        }
        private static async Task<IResult> _GetAppointments(HttpContext context, IRepository<Appointment> repo)
        {
            var a = await DTO.Response.Appointment.Get.DTO(repo);
            if (a.Count() == 0) return TypedResults.NotFound($"No appointments was found");
            return TypedResults.Ok(a);
        }
        private static async Task<IResult> _GetDoctorAppontments(HttpContext context, IRepository<Doctor> repo, int id)
        {
            var a = await DTO.Response.Appointment.GetDoctors.DTO(repo, id);
            if (a == null) return TypedResults.NotFound($"Doctor with id[{id}] was not found");

            return TypedResults.Ok(a);
        }
        private static async Task<IResult> _GetPatientAppontments(HttpContext context, IRepository<Patient> repo, int id)
        {
            var p = await DTO.Response.Appointment.GetPatients.DTO(repo,id);
            if (p == null) return TypedResults.NotFound($"Patient with id[{id}] was not found");

            return TypedResults.Ok(p);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        private static async Task<IResult> CreateAppointment(HttpContext context, IRepository<Appointment> repo,IRepository<Patient> p_repo, IRepository<Doctor> d_repo, DTO.Request.Appointment.Create dto)
        {
            Appointment appointments = new()
            {
                Booking = dto.Booking,
                DoctorId = dto.DoctorId,
                PatientId = dto.PatientId,
                Doctor   = await d_repo.GetEntry(x => x.Where(x => x.Id == dto.DoctorId)),
                Patient  = await p_repo.GetEntry(x => x.Where(x => x.Id == dto.PatientId))
            };

            var a = await repo.CreateEntry(appointments);
            if (a == null) return TypedResults.BadRequest($"Not a valid DTO");
            return TypedResults.Ok(await DTO.Response.Appointment.Get.DTO(repo, appointments.DoctorId, appointments.PatientId)); 
        }
    }
}
