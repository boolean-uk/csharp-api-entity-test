using Microsoft.AspNetCore.Mvc;
using workshop.wwwapi.DTOs;
using workshop.wwwapi.Models;
using workshop.wwwapi.Repository;

namespace workshop.wwwapi.Endpoints
{
    public static class HospitalEndpoint
    {
        //TODO:  add additional endpoints in here according to the requirements in the README.md 
        public static void ConfigureSurgeryEndpoint(this WebApplication app)
        {
            var patientGroup = app.MapGroup("patient");
            var doctorGroup = app.MapGroup("doctor");
            var appointmentGroup = app.MapGroup("appointment");


            patientGroup.MapGet("/patients", GetPatients);
            patientGroup.MapGet("/{id}", GetPatientById);
            patientGroup.MapPost("/patients", CreatePatient);



            patientGroup.MapGet("/doctors", GetDoctors);



            patientGroup.MapGet("/appointmentsbydoctor/{id}", GetAppointmentsByDoctor);

        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetPatients(IRepository patientRepo)
        {
            return TypedResults.Ok(await patientRepo.GetPatients());

        }


        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> GetPatientById(IRepository patientRepo, int id)
        {
            var patient = await patientRepo.GetPatientById(id);
            var appointments = patient.Appointments.Select(a => new AppointmentDTO(a.DoctorId.FullName, a.Booking)).ToList();

            if (patient == null)
            {
                return TypedResults.NotFound($"Patient with ID {id} not found.");
            }


                return Ok(patientDto);
        }
           
        }

        [ProducesResponseType(StatusCodes.Status200OK)]

        public static async Task<IResult> CreatePatient(int id)
        {
            throw new NotImplementedException();

        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetDoctors(IRepository doctorRepo)
        {
            return TypedResults.Ok(await doctoRepo.GetPatients());
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetAppointmentsByDoctor(IRepository doctorRepo, int id)
        {
            return TypedResults.Ok(await repository.GetAppointmentsByDoctor(id));
        }
    }
}

