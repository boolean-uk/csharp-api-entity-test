using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using workshop.wwwapi.DTOs;
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
            surgeryGroup.MapGet("/patients/{id}", GetPasientById);
            surgeryGroup.MapPost("/patients", CreatePatient);
            surgeryGroup.MapGet("/doctors/{id}", GetDoctorById);
            surgeryGroup.MapPost("/doctors", CreateDoctor);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetPatients(IRepository<Patient> repository, IMapper mapper)
        {
            var patients = await repository.GetWithNestedIncludes(query =>
                query.Include(p => p.Appointments)
                     .ThenInclude(a => a.Doctor)
            );

            var response = mapper.Map<List<PatientDTO>>(patients);

            return TypedResults.Ok(response);
        }


        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetDoctors(IRepository<Doctor> repository, IMapper mapper)
        {
            var doctors = await repository.GetWithNestedIncludes(query =>
                query.Include(p => p.Appointments)
                     .ThenInclude(a => a.Patient)
            );

            var response = mapper.Map<List<DoctorDTO>>(doctors);

            return TypedResults.Ok(response);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetAppointmentsByDoctor(IRepository<Appointment> repository, int id, IMapper mapper)
        {
            var appointments = await repository.GetWithIncludes(a => a.Doctor);
            var filteredAppointments = appointments.Where(a => a.Doctor.Id == id).ToList();
            var response = mapper.Map<List<AppointmentDoctorDTO>>(filteredAppointments);
            return TypedResults.Ok(response);
        }


        public static async Task<IResult> GetPasientById(IRepository<Patient> repository, int id, IMapper mapper)
        {
            Patient patient = await repository.GetQueryable()
                .Include(p => p.Appointments)
                .ThenInclude(a => a.Doctor)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (patient == null)
            {
                return TypedResults.NotFound($"Patient with ID {id} not found.");
            }


            var response = mapper.Map<PatientDTO>(patient);
            return TypedResults.Ok(response);
        }


        [ProducesResponseType(StatusCodes.Status201Created)]
        public static async Task<IResult> CreatePatient(IRepository<Patient> repository, string name)
        {
            Patient patient = new Patient(name);
            await repository.Insert(patient);
            return TypedResults.Created(
                $"https://localhost:7010/patients/{patient.Id}", 
                new PatientDTO { FullName = patient.FullName });
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetDoctorById(IRepository<Doctor> repository, int id, IMapper mapper)
        {
            Doctor patient = await repository.GetQueryable()
                .Include(p => p.Appointments)
                .ThenInclude(a => a.Patient)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (patient == null)
            {
                return TypedResults.NotFound($"Doctor with ID {id} not found.");
            }


            var response = mapper.Map<DoctorDTO>(patient);
            return TypedResults.Ok(response);
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        public static async Task<IResult> CreateDoctor(IRepository<Doctor> repository, string name, IMapper mapper)
        {
            Doctor doc = new Doctor(name);
            var inserted = await repository.Insert(doc);
            return TypedResults.Created(
                $"https://localhost:7010/doctors/{inserted.Id}",
                new PatientDTO { FullName = inserted.FullName });
        }


    }
}
