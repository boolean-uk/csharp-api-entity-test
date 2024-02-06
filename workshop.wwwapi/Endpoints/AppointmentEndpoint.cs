using Microsoft.EntityFrameworkCore.Query.Internal;
using workshop.wwwapi.Models.DataTransfer.Appointment;
using workshop.wwwapi.Models.Domain;
using workshop.wwwapi.Repository;

namespace workshop.wwwapi.Endpoints
{
    public static class AppointmentEndpoint
    {
        public static void ConfigureAppointmentEndpoint(this WebApplication app)
        {
            var group = app.MapGroup("appointments");
            group.MapGet("/", GetAll);
            group.MapGet("/{id}", Get);
            group.MapPost("/", Create);
        }

        private static async Task<IResult> GetAll(IRepository<Appointment> repository)
        {
            var appointments = await repository.GetAll();
            List<AppointmentWithDoctorAndPatientDTO> results = new List<AppointmentWithDoctorAndPatientDTO>();
            foreach (var appointment in appointments)
            {
                results.Add(new AppointmentWithDoctorAndPatientDTO(appointment));
            }
            return TypedResults.Ok(results);
        }

        private static async Task<IResult> Get(IRepository<Appointment> repository, int id)
        {
            var result = await repository.Get(id);
            return TypedResults.Ok(new AppointmentWithDoctorAndPatientDTO(result));
        }

        private static async Task<IResult> Create(IRepository<Appointment> repository, AppointmentInsertDTO appointmentInput)
        {
            DateTime appointmentTime = new DateTime(appointmentInput.year, appointmentInput.month, appointmentInput.day, appointmentInput.hour, appointmentInput.minute, 0);
            appointmentTime = DateTime.SpecifyKind(appointmentTime, DateTimeKind.Utc);
            Appointment appointment = new Appointment() { AppointmentTime = appointmentTime, DoctorID = appointmentInput.DoctorID, PatientID = appointmentInput.PatientID };
            var result = await repository.Insert(appointment);
            return TypedResults.Created(result.ID.ToString(), new AppointmentWithDoctorAndPatientDTO(result));
        }
    }
}
