using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using workshop.wwwapi.DTOs.Appointment;
using workshop.wwwapi.DTOs.Doctor;
using workshop.wwwapi.DTOs.Patient;
using workshop.wwwapi.DTOs.Person;
using workshop.wwwapi.Models;
using workshop.wwwapi.Repository;

namespace workshop.wwwapi.Endpoints
{
    public static class SurgeryEndpoint
    {
        //TODO:  add additional endpoints in here according to the requirements in the README.md 
        public static void ConfigureSurgeryEndpoint(this WebApplication app)
        {
            var surgeryGroup = app.MapGroup("surgery");

            surgeryGroup.MapGet("/patients", GetPatients);
            surgeryGroup.MapGet("/patients/{id}", GetPatientById);
            surgeryGroup.MapPost("/patients/{id}", AddPatient);

            surgeryGroup.MapGet("/doctors", GetDoctors);
            surgeryGroup.MapGet("/doctors/{id}", GetDoctorById);
            surgeryGroup.MapPost("/doctors/{id}", AddDoctor);

            surgeryGroup.MapGet("/appointments", GetAppointments);
            surgeryGroup.MapGet("/appointments/{id}", GetAppointmentById);
            surgeryGroup.MapPost("/appointments/{id}", AddAppointment);

            // These do the same as GetPatientById and GetDoctorById, but it's format is based on appointments
            surgeryGroup.MapGet("/appointmentsbydoctor/{id}", GetAppointmentsByDoctor);
            surgeryGroup.MapGet("/appointmentsbypatient/{id}", GetAppointmentsByPatient);
        }


        // Patient endpoints
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetPatients(IRepository<Patient> repository)
        {
            var patients = await repository.GetWithCustomIncludes(query => query.Include(p => p.Appointments).ThenInclude(a => a.Doctor));

            var response = patients.Select(patient => new PatientDTO
            {
                Id = patient.Id,
                FullName = patient.FullName,
                Appointments = patient.Appointments.Select(appointment => new AppointmentsForPatientDTO
                {
                    Id = appointment.Id,
                    AppointmentDate = appointment.AppointmentDate,
                    Doctor = new NestedPersonForAppointmentDTO
                    {
                        Id = appointment.DoctorId,
                        FullName = appointment.Doctor.FullName
                    }
                }).ToList()
            }).ToList();

            return TypedResults.Ok(response);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> GetPatientById(IRepository<Patient> repository, int id)
        {
            var patient = await repository.GetSingleWithCustomIncludes(id, query => query.Include(p => p.Appointments).ThenInclude(a => a.Doctor));

            if (patient == null) { return TypedResults.NotFound(new { message = "Patient not found."}); }

            var response = new PatientDTO
            {
                Id = patient.Id,
                FullName = patient.FullName,
                Appointments = patient.Appointments.Select(appointment => new AppointmentsForPatientDTO
                {
                    Id = appointment.Id,
                    AppointmentDate = appointment.AppointmentDate,
                    Doctor = new NestedPersonForAppointmentDTO
                    {
                        Id = appointment.DoctorId,
                        FullName = appointment.Doctor.FullName
                    }
                }).ToList()
            };

            return TypedResults.Ok(response);
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> AddPatient(IRepository<Patient> repository, PersonPost model)
        {
            if (model.FullName == null) { return TypedResults.NotFound(new { message = "No name provided." }); }

            Patient entity = new Patient();
            entity.FullName = model.FullName;

            await repository.Insert(entity);

            return TypedResults.Created($"https://localhost:7239/patients/{entity.Id}", entity);
        }


        // Doctor endpoints
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetDoctors(IRepository<Doctor> repository)
        {
            var doctors = await repository.GetWithCustomIncludes(query => query.Include(p => p.Appointments).ThenInclude(a => a.Patient));

            var response = doctors.Select(doctor => new DoctorDTO
            {
                Id = doctor.Id,
                FullName = doctor.FullName,
                Appointments = doctor.Appointments.Select(appointment => new AppointmentsForDoctorDTO
                {
                    Id = appointment.Id,
                    AppointmentDate = appointment.AppointmentDate,
                    Patient = new NestedPersonForAppointmentDTO
                    {
                        Id = appointment.PatientId,
                        FullName = appointment.Patient.FullName
                    }
                }).ToList()
            }).ToList();

            return TypedResults.Ok(response);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> GetDoctorById(IRepository<Doctor> repository, int id)
        {
            var doctor = await repository.GetSingleWithCustomIncludes(id, query => query.Include(p => p.Appointments).ThenInclude(a => a.Patient));

            if (doctor == null) { return TypedResults.NotFound(new { message = "Doctor not found." }); }

            var response = new DoctorDTO
            {
                Id = doctor.Id,
                FullName = doctor.FullName,
                Appointments = doctor.Appointments.Select(appointment => new AppointmentsForDoctorDTO
                {
                    Id = appointment.Id,
                    AppointmentDate = appointment.AppointmentDate,
                    Patient = new NestedPersonForAppointmentDTO
                    {
                        Id = appointment.PatientId,
                        FullName = appointment.Patient.FullName
                    }
                }).ToList()
            };

            return TypedResults.Ok(response);
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> AddDoctor(IRepository<Doctor> repository, PersonPost model)
        {
            if (model.FullName == null) { return TypedResults.NotFound(new { message = "No name provided." }); }

            Doctor entity = new Doctor();
            entity.FullName = model.FullName;

            await repository.Insert(entity);

            return TypedResults.Created($"https://localhost:7239/doctors/{entity.Id}", entity);
        }


        // Appointment endpoints
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetAppointments(IRepository<Appointment> repository)
        {
            var appointments = await repository.GetWithIncludes(query => query.Doctor, query => query.Patient);

            var response = appointments.Select(appointment => new AppointmentDTO
            {
                Id = appointment.Id,
                AppointmentDate = appointment.AppointmentDate,
                Doctor = new NestedPersonForAppointmentDTO
                {
                    Id = appointment.DoctorId,
                    FullName = appointment.Doctor.FullName
                },
                Patient = new NestedPersonForAppointmentDTO
                {
                    Id = appointment.PatientId,
                    FullName = appointment.Patient.FullName
                }
            }).ToList();

            return TypedResults.Ok(response);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> GetAppointmentById(IRepository<Appointment> repository, int id)
        {
            var appointment = await repository.GetByIdWithIncludes(id, query => query.Doctor, query => query.Patient);

            if (appointment == null) { return TypedResults.NotFound(new { message = "Appointment not found." }); }

            var response = new AppointmentDTO
            {
                Id = appointment.Id,
                AppointmentDate = appointment.AppointmentDate,
                Doctor = new NestedPersonForAppointmentDTO
                {
                    Id = appointment.DoctorId,
                    FullName = appointment.Doctor.FullName
                },
                Patient = new NestedPersonForAppointmentDTO
                {
                    Id = appointment.PatientId,
                    FullName = appointment.Patient.FullName
                }
            };

            return TypedResults.Ok(response);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> GetAppointmentsByDoctor(IRepository<Appointment> repository, int id)
        {
            var appointments = await repository.GetWithIncludes(query => query.Doctor, query => query.Patient);

            var appointmentsByDoctor = appointments.Where(a => a.DoctorId == id).ToList();
            if (appointmentsByDoctor.Count == 0) { return TypedResults.NotFound(new { message = "No appointments found." }); }

            var response = appointmentsByDoctor.Select(appointment => new AppointmentDTO
            {
                Id = appointment.Id,
                AppointmentDate = appointment.AppointmentDate,
                Doctor = new NestedPersonForAppointmentDTO
                {
                    Id = appointment.DoctorId,
                    FullName = appointment.Doctor.FullName
                },
                Patient = new NestedPersonForAppointmentDTO
                {
                    Id = appointment.PatientId,
                    FullName = appointment.Patient.FullName
                }
            }).ToList();

            return TypedResults.Ok(response);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> GetAppointmentsByPatient(IRepository<Appointment> repository, int id)
        {
            var appointments = await repository.GetWithIncludes(query => query.Doctor, query => query.Patient);

            var appointmentsByPatient = appointments.Where(a => a.PatientId == id).ToList();
            if (appointmentsByPatient.Count == 0) { return TypedResults.NotFound(new { message = "No appointments found." }); }

            var response = appointmentsByPatient.Select(appointment => new AppointmentDTO
            {
                Id = appointment.Id,
                AppointmentDate = appointment.AppointmentDate,
                Patient = new NestedPersonForAppointmentDTO
                {
                    Id = appointment.PatientId,
                    FullName = appointment.Patient.FullName
                },
                Doctor = new NestedPersonForAppointmentDTO
                {
                    Id = appointment.DoctorId,
                    FullName = appointment.Doctor.FullName
                },
            }).ToList();

            return TypedResults.Ok(response);
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> AddAppointment(IRepository<Appointment> repository, AppointmentPost model)
        {
            // Check if the model is valid
            if (model.AppointmentDate == DateTime.SpecifyKind(new DateTime(0001, 01, 01, 0, 0, 0), DateTimeKind.Utc)) { return TypedResults.NotFound(new { message = "No appointment date provided." }); }
            if (model.DoctorId == 0) { return TypedResults.NotFound(new { message = "No doctor id provided." }); }
            if (model.PatientId == 0) { return TypedResults.NotFound(new { message = "No patient id provided." }); }

            // Check if the doctor and patient exist
            var appointments = await repository.GetWithIncludes(query => query.Doctor, query => query.Patient);
            var doctorExists = appointments.Any(a => a.DoctorId == model.DoctorId);
            if (!doctorExists) { return TypedResults.NotFound(new { message = "Doctor not found." }); }
            var patientExists = appointments.Any(a => a.PatientId == model.PatientId);
            if (!patientExists) { return TypedResults.NotFound(new { message = "Patient not found." }); }

            // Create the appointment entity
            Appointment entity = new Appointment();
            entity.AppointmentDate = model.AppointmentDate;
            entity.DoctorId = model.DoctorId;
            entity.PatientId = model.PatientId;

            await repository.Insert(entity);

            var appointment = await repository.GetByIdWithIncludes(entity.Id, query => query.Doctor, query => query.Patient);

            var response = new AppointmentDTO
            {
                Id = appointment.Id,
                AppointmentDate = appointment.AppointmentDate,
                Doctor = new NestedPersonForAppointmentDTO
                {
                    Id = appointment.DoctorId,
                    FullName = appointment.Doctor.FullName
                },
                Patient = new NestedPersonForAppointmentDTO
                {
                    Id = appointment.PatientId,
                    FullName = appointment.Patient.FullName
                }
            };

            return TypedResults.Created($"https://localhost:7239/appointments/{entity.Id}", response);
        }
    }
}
