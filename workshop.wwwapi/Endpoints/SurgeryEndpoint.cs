using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
            //surgeryGroup.MapGet("/patients/{id}", GetPatient);
            surgeryGroup.MapPost("/patients", AddPatient);
            surgeryGroup.MapGet("/doctors", GetDoctors);
            //surgeryGroup.MapGet("/doctors/{id}", GetDoctor);
            surgeryGroup.MapPost("/doctors", AddDoctor);
            surgeryGroup.MapGet("/appointments/doctor/{id}", GetAppointmentsByDoctor);
            surgeryGroup.MapGet("/appointments/patient/{id}", GetAppointmentsByPatient);

            surgeryGroup.MapPost("/appointments", AddAppointment);
        }


        #region Patient
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

        public static async Task<IResult> AddPatient(IRepository<Patient> repository, string name, IMapper mapper)
        {

            Models.Patient patient = new Models.Patient()
            {
                FullName = name
            };
            //var patientDTO = mapper.Map<Patient>(patient);
            await repository.Add(patient);
            return TypedResults.Ok(patient);
        }


        #endregion

        #region Doctor
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
        public static async Task<IResult> AddDoctor(IRepository<Doctor> repository, string name, IMapper mapper)
        {
            Models.Doctor doctor = new Models.Doctor()
            {
                FullName = name
            };
            await repository.Add(doctor);
            return TypedResults.Ok(doctor);
        }
        #endregion


        #region Appointment
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetAppointmentsByDoctor(IRepository<Doctor> repository, IMapper mapper, int id)
        {
            //var doctor = await repository.GetByIdWithIncludes(id, a => a.Appointments);

            Doctor doctor = await repository.GetQuery().Include(p => p.Appointments)
                .ThenInclude(a => a.Patient)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (doctor == null)
            {
                return TypedResults.NotFound();
            }

            var response = mapper.Map<DoctorDTO>(doctor);
            return TypedResults.Ok(response);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetAppointmentsByPatient(IRepository<Patient> repository, IMapper mapper, int id)
        {
            //var patient = await repository.GetByIdWithIncludes(id, a => a.Appointments);

            Patient patient = await repository.GetQuery().Include(p => p.Appointments)
                .ThenInclude(a => a.Doctor)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (patient == null)
            {
                return TypedResults.NotFound();
            }
            var response = mapper.Map<PatientDTO>(patient);
            return TypedResults.Ok(response);
        }

        public static async Task<IResult> AddAppointment(IRepository<Appointment> repository, DateTime date, int doctorId, int patientId, IMapper mapper)
        {
            Models.Appointment appointment = new Models.Appointment()
            {
                Booking = date,
                DoctorId = doctorId,
                PatientId = patientId
            };
            await repository.Add(appointment);
            return TypedResults.Ok(appointment);
        }

        #endregion
    }
}
