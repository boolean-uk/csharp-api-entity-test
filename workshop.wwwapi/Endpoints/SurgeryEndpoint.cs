using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using workshop.wwwapi.Models;
using workshop.wwwapi.Repository;
using workshop.wwwapi.DTO.Responses;
using Microsoft.EntityFrameworkCore;
using workshop.wwwapi.DTO.Requests;

namespace workshop.wwwapi.Endpoints
{
    public static class SurgeryEndpoint
    {
        //TODO:  add additional endpoints in here according to the requirements in the README.md 
        public static void ConfigurePatientEndpoint(this WebApplication app)
        {
            var surgeryGroup = app.MapGroup("surgery");

            surgeryGroup.MapGet("/patients", GetPatients);
            surgeryGroup.MapGet("/patients{id}", GetPatientById);
            surgeryGroup.MapGet("/doctors", GetDoctors);
            surgeryGroup.MapGet("/doctors{id}", GetDoctorById);
            surgeryGroup.MapGet("/appointmentsbydoctor/{doctor_id}/{patien_id}", GetAppointmentsByDoctor);

            surgeryGroup.MapPost("patients/", AddPatient);
            surgeryGroup.MapPost("doctors/", AddDoctor);

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
                query.Include(d => d.Appointments)
                     .ThenInclude(a => a.Patient)
            );

            var response = mapper.Map<List<DoctorDTO>>(doctors);
            return TypedResults.Ok(response);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetPatientById(IRepository<Patient> repository, int id, IMapper mapper)
        {
            var patient = await repository.GetQueryable()
                                           .Include(p => p.Appointments)
                                           .ThenInclude(a => a.Doctor)
                                           .FirstOrDefaultAsync(p => p.Id == id);

            if (patient == null)
            {
                return TypedResults.NotFound();
            }

            var response = mapper.Map<PatientDTO>(patient);
            return TypedResults.Ok(response);
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetDoctorById(IRepository<Doctor> repository, int id, IMapper mapper)
        {
            var doctor = await repository.GetQueryable()
                                           .Include(d => d.Appointments)
                                           .ThenInclude(a => a.Patient)
                                           .FirstOrDefaultAsync(d => d.Id == id);

            if (doctor == null)
            {
                return TypedResults.NotFound();
            }

            var response = mapper.Map<DoctorDTO>(doctor);
            return TypedResults.Ok(response);
        }
        [ProducesResponseType(StatusCodes.Status201Created)]
        public static async Task<IResult> AddPatient(IRepository<Patient> repository, PostPerson model)
        {
            Patient patient = new Patient()
            {
                FullName = model.FullName,
            };
            await repository.Insert(patient);

            return TypedResults.Created($"https://localhost:7010/patients/{patient.Id}", new PatientDTO { FullName = patient.FullName });
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        public static async Task<IResult> AddDoctor(IRepository<Doctor> repository, PostPerson model)
        {
            Doctor doctor = new Doctor()
            {
                FullName = model.FullName,
            };
            await repository.Insert(doctor);

            return TypedResults.Created($"https://localhost:7010/patients/{doctor.Id}", new PatientDTO { FullName = doctor.FullName });
        }


        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> GetAppointmentsByDoctor(IRepository<Appointment> repository, int doctor_id, int patient_id)
        {
            var appointment = await repository.GetByCompositKey(doctor_id, patient_id);

            if (appointment == null)
            {
                return TypedResults.NotFound();
            }
            var appointmentDTOs = new AppointmentDTO
            {
                Booking = appointment.Booking,
                PatientId = patient_id,
                DoctorId = appointment.DoctorId
            };

            return TypedResults.Ok(appointmentDTOs);
        }


    }
}
