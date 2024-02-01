using Microsoft.AspNetCore.Mvc;
using workshop.wwwapi.Data.DTO;
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
            surgeryGroup.MapGet("/doctors", GetDoctors);
            surgeryGroup.MapGet("/doctors/{id}", GetDoctorById);
            surgeryGroup.MapGet("/patients/{id}", GetPatientById);
            surgeryGroup.MapGet("/doctors/appointments/{id}", GetAppointmentsByDoctor);
            surgeryGroup.MapGet("/patients/appointments/{id}", GetAppointmentsByPatient);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        private static async Task<IResult> GetDoctorById(IRepository repository, int id)
        {
            if (id == 0 || id < 0)
                return Results.BadRequest("Invalid value");

            IEnumerable<Doctor> doctors = await repository.GetDoctorById(id);
            if (doctors == null)
            {
                return Results.NotFound("Doctor not found with that ID");
            }
            return TypedResults.Ok(DoctorDTO.FromRepository(doctors));
        }


        [ProducesResponseType(StatusCodes.Status200OK)]
        private static async Task<IResult> GetPatientById(IRepository repository, int id)
        {
            if (id == 0 || id < 0)
                return Results.BadRequest("Invalid value");

            IEnumerable<Patient> patient = await repository.GetPatientById(id);
            if (patient == null)
            {
                return Results.NotFound("Doctor not found with that ID");
            }
            return TypedResults.Ok(PatientDTO.FromRepository(patient));
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetPatients(IRepository repository)
        {
            return TypedResults.Ok(PatientResponseDTO.FromRepository(await repository.GetPatients()));
        }


        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetDoctors(IRepository repository)
        {
            return TypedResults.Ok(DoctorResponseDTO.FromRepository(await repository.GetDoctors()));
        }



        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetAppointmentsByDoctor(IRepository repository, int id)
        {
            if (id == 0 || id < 0)
                return Results.BadRequest("Invalid value");

            IEnumerable<Appointment> appointment = await repository.GetAppointmentsByDoctor(id);
            if (appointment == null)
            {
                return Results.NotFound("Appointments not found with that ID");
            }
            return TypedResults.Ok(DoctorAppointmentDTO.FromRepository(appointment));
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetAppointmentsByPatient(IRepository repository, int id)
        {
            if (id == 0 || id < 0)
                return Results.BadRequest("Invalid value");

            IEnumerable<Appointment> appointment = await repository.GetAppointmentsByPatient(id);
            if (appointment == null)
            {
                return Results.NotFound("Appointments Not found with that ID");
            }
            return TypedResults.Ok(PatientAppointmentDTO.FromRepository(appointment));
        }
    }
}
