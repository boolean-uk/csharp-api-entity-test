using Microsoft.AspNetCore.Mvc;
using workshop.wwwapi.Repository;
using workshop.wwwapi.DTO;
using workshop.wwwapi.Models;

namespace workshop.wwwapi.Endpoints
{
    public static class SurgeryEndpoint
    {
        public static void ConfigureSurgeryEndpoint(this WebApplication app)
        {
            var surgeryGroup = app.MapGroup("surgery");

            // Patient endpoints
            surgeryGroup.MapGet("/patients", GetPatients);
            surgeryGroup.MapGet("/patient/{id}", GetPatient);

            // Doctor endpoints
            surgeryGroup.MapGet("/doctors", GetDoctors);
            surgeryGroup.MapGet("/doctor/{id}", GetDoctorById);
            surgeryGroup.MapPost("/doctor", CreateDoctor);

            // Appointment endpoints
            surgeryGroup.MapGet("/appointments", GetAppointments);
            surgeryGroup.MapGet("/appointment/{id}", GetAppointmentById);
            surgeryGroup.MapGet("/appointmentsbydoctor/{id}", GetAppointmentsByDoctor);
            surgeryGroup.MapGet("/appointmentsbypatient/{id}", GetAppointmentsByPatient);
            surgeryGroup.MapPost("/appointment", CreateAppointment);
        }

        // Patient endpoints
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        private static async Task<IResult> GetPatient(IRepository repository, int id)
        {
            var patient = await repository.GetPatientById(id);
            if (patient == null)
            {
                return TypedResults.NotFound($"Patient with ID {id} was not found.");
            }

            var patientDto = new PatientDTO
            {
                Id = patient.Id,
                FullName = patient.FullName,
                Appointments= patient.Appointments.Select(a => new AppointmentDTO
                {
                    DoctorId = a.DoctorId,
                    DoctorName = a.Doctor.FullName,
                    Booking = a.appointmentDate,
                }).ToList()
            };

            return TypedResults.Ok(patientDto);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        private static async Task<IResult> GetPatients(IRepository repository)
        {
            var patients = await repository.GetPatients();
            var patientDtos = patients.Select(p => new PatientDTO
            {
                Id = p.Id,
                FullName = p.FullName,
                Appointments = p.Appointments.Select(a => new AppointmentDTO
                {
                    DoctorId = a.DoctorId,
                    DoctorName = a.Doctor.FullName,
                    Booking = a.appointmentDate,
                }).ToList()
            }).ToList();

            return TypedResults.Ok(patientDtos);
        }

        // Doctor endpoints
        [ProducesResponseType(StatusCodes.Status200OK)]
        private static async Task<IResult> GetDoctors(IRepository repository)
        {
            var doctors = await repository.GetDoctors();
            var doctorDtos = doctors.Select(d => new DoctorDTO
            {
                Id = d.Id,
                Name = d.FullName,
                Appointments = d.Appointments.Select(a => new AppointmentDTO
                {
                    PatientId = a.PatientId,
                    PatientName = a.Patient.FullName,
                    Booking = a.appointmentDate,
                }).ToList()
            }).ToList();

            return TypedResults.Ok(doctorDtos);
        }

        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        private static async Task<IResult> GetDoctorById(IRepository repository, int id)
        {
            var doctor = await repository.GetDoctorById(id);
            if (doctor == null)
            {
                return TypedResults.NotFound($"Doctor with ID {id} was not found.");
            }

            var doctorDto = new DoctorDTO
            {
                Id = doctor.Id,
                Name = doctor.FullName,
                Appointments = doctor.Appointments.Select(a => new AppointmentDTO
                {
                    PatientId = a.PatientId,
                    PatientName = a.Patient.FullName,
                    Booking = a.appointmentDate
                }).ToList()
            };

            return TypedResults.Ok(doctorDto);
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        private static async Task<IResult> CreateDoctor(IRepository repository, DoctorDTO doctorDto)
        {
            var doctor = new Doctor
            {
                FullName = doctorDto.Name
            };

            var createdDoctor = await repository.CreateDoctor(doctor);
            doctorDto.Id = createdDoctor.Id;

            return TypedResults.Created($"/doctor/{doctorDto.Id}", doctorDto);
        }

        // Appointment endpoints
        [ProducesResponseType(StatusCodes.Status200OK)]
        private static async Task<IResult> GetAppointments(IRepository repository)
        {
            var appointments = await repository.GetAppointments();
            var appointmentDtos = appointments.Select(a => new AppointmentDTO
            {
                PatientId = a.PatientId,
                PatientName = a.Patient.FullName,
                DoctorId = a.DoctorId,
                DoctorName = a.Doctor.FullName,
                Booking = a.appointmentDate
            }).ToList();

            return TypedResults.Ok(appointmentDtos);
        }

        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        private static async Task<IResult> GetAppointmentById(IRepository repository, int id)
        {
            var appointment = await repository.GetAppointmentById(id);
            if (appointment == null)
            {
                return TypedResults.NotFound($"Appointment with ID {id} was not found.");
            }

            var appointmentDto = new AppointmentDTO
            {
                PatientId = appointment.PatientId,
                PatientName = appointment.Patient.FullName,
                DoctorId = appointment.DoctorId,
                DoctorName = appointment.Doctor.FullName,
                Booking = appointment.appointmentDate
            };

            return TypedResults.Ok(appointmentDto);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        private static async Task<IResult> GetAppointmentsByDoctor(IRepository repository, int id)
        {
            var appointments = await repository.GetAppointmentsByDoctor(id);
            var appointmentDtos = appointments.Select(a => new AppointmentDTO
            {
                PatientId = a.PatientId,
                PatientName = a.Patient.FullName,
                DoctorId = a.DoctorId,
                DoctorName = a.Doctor.FullName,
                Booking = a.appointmentDate
            }).ToList();

            return TypedResults.Ok(appointmentDtos);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        private static async Task<IResult> GetAppointmentsByPatient(IRepository repository, int id)
        {
            var appointments = await repository.GetAppointmentsByPatient(id);
            var appointmentDtos = appointments.Select(a => new AppointmentDTO
            {
                PatientId = a.PatientId,
                PatientName = a.Patient.FullName,
                DoctorId = a.DoctorId,
                DoctorName = a.Doctor.FullName,
                Booking = a.appointmentDate
            }).ToList();

            return TypedResults.Ok(appointmentDtos);
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        private static async Task<IResult> CreateAppointment(IRepository repository, AppointmentDTO appointmentDto)
        {
            var appointment = new Appointment
            {
                PatientId = appointmentDto.PatientId,
                DoctorId = appointmentDto.DoctorId,
                appointmentDate = appointmentDto.Booking
            };

            var createdAppointment = await repository.CreateAppointment(appointment);
            appointmentDto.Id = createdAppointment.Id;

            return TypedResults.Created($"/appointment/{appointmentDto.Id}", appointmentDto);
        }
    }
}

