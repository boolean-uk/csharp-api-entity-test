using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using workshop.wwwapi.Models;
using workshop.wwwapi.Repository;

namespace workshop.wwwapi.Endpoints
{
    public static class SurgeryEndpoint
    {
        //TODO:  add additional endpoints in here according to the requirements in the README.md 
        public static void ConfigureEndpoint(this WebApplication app)
        {
            var surgeryGroup = app.MapGroup("surgery");

            surgeryGroup.MapGet("/patients", GetPatients);
            surgeryGroup.MapGet("/patients/{id}", GetPatientById);
            surgeryGroup.MapPost("/patients", CreatePatient);

            surgeryGroup.MapGet("/doctors", GetDoctors);
            surgeryGroup.MapGet("/doctors/{id}", GetDoctorById);
            surgeryGroup.MapPost("/doctors", CreateDoctor);

            surgeryGroup.MapGet("/appointments", GetAppointments);
            surgeryGroup.MapGet("/appointments/{id}", GetAppointmentById);
            surgeryGroup.MapGet("/appointmentsbydoctor/{id}", GetAppointmentsByDoctor);
            surgeryGroup.MapGet("/appointmentsbypatient/{id}", GetAppointmentsByPatient);
            surgeryGroup.MapPost("/appointments", CreateAppointment);
        }

        // Patients
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetPatients(IRepository<Patient> patientRepo, IRepository<Appointment> appointmentRepo, IMapper mapper)
        {
            var patients = await patientRepo.GetWithIncludes(p => p.Appointments);

            var result = patients.Select(p => new PatientDTO
            {
                Id = p.Id,
                FullName = p.FullName,
                Appointments = p.Appointments.Select(a => new AppointmentPatientDTO
                {
                    Id = a.Id,
                    Booking = a.Booking,
                    DoctorName = a.Doctor.FullName
                }).ToList()
            }).ToList();
            return TypedResults.Ok(result);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> GetPatientById(IRepository<Patient> patientRepo, IRepository<Appointment> appointmentRepo, IMapper mapper, int id)
        {
            var patients = await patientRepo.GetWithIncludes(p => p.Appointments);
            var patient = await patients.FirstOrDefaultAsync(p => p.Id == id); 

            if (patient == null) return TypedResults.NotFound($"No patient found for id {id}");

            var result = new PatientDTO
            {
                Id = patient.Id,
                FullName = patient.FullName,
                Appointments = patient.Appointments.Select(a => new AppointmentPatientDTO
                {
                    Id = a.Id,
                    Booking = a.Booking,
                    DoctorName = a.Doctor.FullName
                }).ToList()
            };
            return TypedResults.Ok(result);
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public static async Task<IResult> CreatePatient(IRepository<Patient> patientRepo, PatientPost model)
        {
            if (string.IsNullOrWhiteSpace(model.FullName)) return Results.BadRequest("Patient's full name is required.");

            var patient = new Patient()
            {
                FullName = model.FullName
            };

            patient = await patientRepo.Insert(patient);

            var result = new PatientDTO
            {
                Id = patient.Id,
                FullName = patient.FullName,
            };
            return Results.Created($"/patients/{patient.Id}", result);
        }



        // Doctors
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetDoctors(IRepository<Doctor> doctorRepo, IRepository<Appointment> appointmentRepo, IMapper mapper)
        {
            var doctors = await doctorRepo.GetWithIncludes(d => d.Appointments);

            var result = doctors.Select(d => new DoctorDTO
            {
                Id = d.Id,
                FullName = d.FullName,
                Appointments = d.Appointments.Select(a => new AppointmentDoctorDTO
                {
                    Id = a.Id,
                    Booking = a.Booking,
                    PatientName = a.Patient.FullName
                }).ToList()
            }).ToList();
            return TypedResults.Ok(result);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> GetDoctorById(IRepository<Doctor> doctorRepo, IRepository<Appointment> appointmentRepo, IMapper mapper, int id)
        {
            var doctors = await doctorRepo.GetWithIncludes(d => d.Appointments);
            var doctor = await doctors.FirstOrDefaultAsync(d => d.Id == id);

            if (doctor == null) return TypedResults.NotFound($"No doctor found for id {id}");

            var result = new DoctorDTO
            {
                Id = doctor.Id,
                FullName = doctor.FullName,
                Appointments = doctor.Appointments.Select(a => new AppointmentDoctorDTO
                {
                    Id = a.Id,
                    Booking = a.Booking,
                    PatientName = a.Patient.FullName
                }).ToList()
            };
            return TypedResults.Ok(result);
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public static async Task<IResult> CreateDoctor(IRepository<Doctor> doctorRepo, DoctorPost model)
        {
            if (string.IsNullOrWhiteSpace(model.FullName)) return Results.BadRequest("Doctor's full name is required.");

            var doctor = new Doctor()
            {
                FullName = model.FullName
            };

            doctor = await doctorRepo.Insert(doctor);

            var result = new PatientDTO
            {
                Id = doctor.Id,
                FullName = doctor.FullName,
            };
            return Results.Created($"/doctors/{doctor.Id}", result);
        }



        // Appointments
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetAppointments(IRepository<Appointment> appointmentRepo, IMapper mapper)
        {
            var appointments = await appointmentRepo.GetWithIncludes(a => a.Doctor, a => a.Patient);

            var result = appointments.Select(a => new AppointmentDTO
            {
                Id = a.Id,
                Booking = a.Booking,
                DoctorName = a.Doctor.FullName,
                PatientName = a.Patient.FullName
            }).ToList();
            return TypedResults.Ok(result);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> GetAppointmentById(IRepository<Appointment> appointmentRepo, IMapper mapper, int id)
        {
            var appointments = await appointmentRepo.GetWithIncludes(a => a.Patient, a => a.Doctor);
            var appointment = await appointments.FirstOrDefaultAsync(a => a.Id == id);

            if (appointment == null) return TypedResults.NotFound($"No doctor found for id {id}");

            var result = new AppointmentDTO
            {
                Id = appointment.Id,
                Booking = appointment.Booking,
                DoctorName= appointment.Doctor.FullName,
                PatientName= appointment.Patient.FullName
            };
            return TypedResults.Ok(result);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> GetAppointmentsByDoctor(IRepository<Appointment> appointmentRepo, IMapper mapper, int id)
        {
            var appointments = await appointmentRepo.GetWithIncludes(a => a.Doctor, a => a.Patient);
            
            var result = appointments.Where(a => a.DoctorId == id).Select(a => new AppointmentDTO
            {
                Id = a.Id,
                Booking = a.Booking,
                DoctorName = a.Doctor.FullName,
                PatientName = a.Patient.FullName
            }).ToList();
            if (!result.Any()) return TypedResults.NotFound($"No appointments found for doctor id {id}");
            return TypedResults.Ok(result);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> GetAppointmentsByPatient(IRepository<Appointment> appointmentRepo, IMapper mapper, int id)
        {
            var appointments = await appointmentRepo.GetWithIncludes(a => a.Doctor, a => a.Patient);

            var result = appointments.Where(a => a.PatientId == id).Select(a => new AppointmentDTO
            {
                Id = a.Id,
                Booking = a.Booking,
                DoctorName = a.Doctor.FullName,
                PatientName = a.Patient.FullName
            }).ToList();
            if (!result.Any()) return TypedResults.NotFound($"No appointments found for patient id {id}");
            return TypedResults.Ok(result);
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public static async Task<IResult> CreateAppointment(IRepository<Appointment> appointmentRepo, IRepository<Patient> patientRepo, IRepository<Doctor> doctorRepo, AppointmentPost model)
        {
            if (model.Booking == null ||
                model.PatientId == null ||
                model.DoctorId == null) return Results.BadRequest("Request is missing elements");

            var doctor = await doctorRepo.GetById(model.DoctorId);
            if (doctor == null) return Results.BadRequest("Doctor not found.");

            var patient = await patientRepo.GetById(model.PatientId);
            if (patient == null) return Results.BadRequest("Patient not found.");

            var appointment = new Appointment()
            {
                Booking = model.Booking,
                DoctorId = model.DoctorId,
                PatientId = model.PatientId,
            };

            appointment = await appointmentRepo.Insert(appointment);

            var result = new AppointmentDTO
            {
                Id = appointment.Id,
                Booking = appointment.Booking,
                DoctorName = doctor.FullName,
                PatientName = patient.FullName,
            };
            return Results.Created($"/appointments/{appointment.Id}", result);
        }
    }
}
