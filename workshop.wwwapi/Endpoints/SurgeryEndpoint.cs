using Microsoft.AspNetCore.Mvc;
using workshop.wwwapi.DTOs;
using workshop.wwwapi.Models;
using workshop.wwwapi.Models.DTOs;
using workshop.wwwapi.Repository;

namespace workshop.wwwapi.Endpoints
{
    public static class SurgeryEndpoint
    {
        public static void ConfigurePatientEndpoint(this WebApplication app)
        {
            var surgeryGroup = app.MapGroup("surgery");

            surgeryGroup.MapGet("/patients", GetPatients);
            surgeryGroup.MapGet("/patients/{id}", GetPatientById);
            surgeryGroup.MapPost("/patients", CreatePatient);
            surgeryGroup.MapGet("/doctors", GetDoctors);
            surgeryGroup.MapGet("/doctors/{id}", GetDoctorById);
            surgeryGroup.MapPost("/doctors", CreateDoctor);
            surgeryGroup.MapGet("/appointments", GetAppointments);
            surgeryGroup.MapGet("/appointments/doctor/{id}", GetAppointmentsByDoctor);
            surgeryGroup.MapGet("/appointments/patient/{id}", GetAppointmentsByPatient);
        }

        // ------------------------ Patients ------------------------------
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetPatients(IRepository repository)
        {
            var patients = await repository.GetPatients();
            return TypedResults.Ok(patients);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> GetPatientById(IRepository repository, int id)
        {
            var patient = await repository.GetPatientbyId(id);
            if (patient == null)
            {
                return TypedResults.NotFound();
            }
            return TypedResults.Ok(patient);
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        public static async Task<IResult> CreatePatient(IRepository repository, CreatePatientDTO createPatientDTO)
        {
            var patient = new Patient{ FullName = createPatientDTO.FullName};
            var createdPatient = await repository.CreatePatient(patient);
            var patientDTO = new PatientDTO
            {
                Id = createdPatient.Id,
                FullName = createdPatient.FullName
            };
            return TypedResults.Ok(patientDTO);
        }

        // ---------------------- Doctors -----------------------
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetDoctors(IRepository repository)
        {
            var doctors = await repository.GetDoctors();
            return TypedResults.Ok(doctors);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> GetDoctorById(IRepository repository, int id)
        {
            var doctor = await repository.GetDoctorById(id);
            if (doctor == null)
            {
                return TypedResults.NotFound();
            }
            return TypedResults.Ok(doctor);
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        public static async Task<IResult> CreateDoctor(IRepository repository, CreateDoctorDTO createDoctorDTO)
        {
            var doctor = new Doctor{ FullName = createDoctorDTO.FullName };
            var createdDoctor = await repository.CreateDoctor(doctor);
            var doctorDTO = new DoctorDTO
            {
                Id = createdDoctor.Id,
                FullName = createdDoctor.FullName
            };
            return TypedResults.Ok(doctorDTO);
        }

        //------------------------ Appointments --------------------------
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetAppointments(IRepository repository)
        {
            var appointments = await repository.GetAppointments();
            var appointmentDTOs = appointments.Select(a => new AppointmentDTO
            {
                Booking = a.Booking,
                DoctorId = a.DoctorId,
                DoctorFullName = a.Doctor.FullName,
                PatientId = a.PatientId,
                PatientFullName = a.Patient.FullName
            }).ToList();
            return TypedResults.Ok(appointmentDTOs);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetAppointmentsByDoctor(IRepository repository, int id)
        {
            var appointments = await repository.GetAppointmentsByDoctor(id);
            return TypedResults.Ok(appointments);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetAppointmentsByPatient(IRepository repository, int id)
        {
            var appointments = await repository.GetAppointmentsByPatient(id);
            return TypedResults.Ok(appointments);
        }
    }
}
