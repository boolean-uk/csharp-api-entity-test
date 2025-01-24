using System;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using workshop.wwwapi.DTO;
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
            surgeryGroup.MapGet("/appointmentsbydoctor/{id}", GetAppointmentsByDoctor);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetPatients(IRepository<Patient> patientRepository, IMapper mapper)
        {
            var people = await patientRepository.GetWithIncludes(p => p.FullName, p => p.Appointments);

            var response = mapper.Map<List<PatientDTO>>(people);

            return TypedResults.Ok(response);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetDoctors(IRepository<Doctor> doctorRepository, IMapper mapper)
        {
            var people = await doctorRepository.GetWithIncludes(p => p.FullName, p => p.Appointments);

            var response = mapper.Map<List<PatientDTO>>(people);

            return TypedResults.Ok(response);
        }


        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetAppointments(IRepository<Appointment> doctorRepository, IMapper mapper)
        {
            var people = await doctorRepository.GetWithIncludes(p => p.Booking, p => p.Patient, p => p.Doctor);

            var response = mapper.Map<List<PatientDTO>>(people);

            return TypedResults.Ok(response);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetAppointmentsByDoctor(IRepository<Doctor> doctorRepository, IMapper mapper, int id)
        {
            var doctor = await doctorRepository.GetByIdWithIncludes(id, d => d.Appointments);

            if (doctor == null)
            {
                return TypedResults.NotFound($"Doctor with ID {id} not found.");
            }

            var response = mapper.Map<DoctorDTO>(doctor);
            return TypedResults.Ok(response);
        }

    }
}
