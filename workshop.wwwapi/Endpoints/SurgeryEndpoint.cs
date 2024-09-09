using Microsoft.AspNetCore.Mvc;
using System.Numerics;
using workshop.wwwapi.DTO;
using workshop.wwwapi.Extensions;
using workshop.wwwapi.Models;
using workshop.wwwapi.Repository;
using workshop.wwwapi.ViewModels;

namespace workshop.wwwapi.Endpoints
{
    public static class SurgeryEndpoint
    {
        //TODO:  add additional endpoints in here according to the requirements in the README.md 
        public static void ConfigurePatientEndpoint(this WebApplication app)
        {
            var surgeryGroup = app.MapGroup("surgery");

            surgeryGroup.MapGet("/patients", GetPatients);
            surgeryGroup.MapGet("/patients/{id}", GetAPatient);
            surgeryGroup.MapPost("/patients/{patient}", CreatePatient);
            surgeryGroup.MapGet("/doctors", GetDoctors);
            surgeryGroup.MapGet("/doctors/{id}", GetADoctor);
            surgeryGroup.MapPost("/doctors/{doctor}", CreateDoctor);
            surgeryGroup.MapGet("/appointments/", GetAppointments);
            surgeryGroup.MapGet("/appointments/patient{patientid}/doctor{doctorid}", GetAppointment);
            surgeryGroup.MapPost("/appointements/{appointment}", CreateAppointment);
            surgeryGroup.MapGet("/appointments/patient{id}", GetAppointmentsByPatient);
            surgeryGroup.MapGet("/appointments/doctor{id}", GetAppointmentsByDoctor);
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetPatients(IRepository repository)
        {
            var patients = await repository.GetPatients();
            List<PatientDTO> result = new List<PatientDTO>();
            foreach (var patient in patients) 
            {
                var patientDTO = patient.ToDTO();
                patientDTO.Appointments = await ToPatientAppointments(repository, patient);
                result.Add(patientDTO);
            }
            return TypedResults.Ok(result);
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetAPatient(IRepository repository, int id)
        {
            var patient = await repository.GetAPatient(id);
            var patientDTO = patient.ToDTO();
            patientDTO.Appointments = await ToPatientAppointments(repository, patient);

            return TypedResults.Ok(patientDTO);
        }
        [ProducesResponseType(StatusCodes.Status201Created)]
        public static async Task<IResult> CreatePatient(IRepository repository, PatientPostModel patientPost)
        {
            Patient patient = new() { FullName = patientPost.FullName};
            patient = await repository.CreatePatient(patient);
            return TypedResults.Created($"https://localhost:7235/surgery/patients/{patient.Id}");
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetDoctors(IRepository repository)
        {
            var doctors = await repository.GetDoctors();
            List<DoctorDTO> result = [];

            foreach (var doctor in doctors) 
            {
                DoctorDTO doctorDTO = doctor.ToDTO();
                doctorDTO.Appointments = await ToDoctorsAppointments(repository, doctor);
                result.Add(doctorDTO);
            }
            return TypedResults.Ok(result);
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetADoctor(IRepository repository, int id)
        {
            var doctor = await repository.GetADoctor(id);
            var doctorDTO = doctor.ToDTO();
            if (doctor.Appointments.Count == 0) return TypedResults.Ok(doctorDTO);
            doctorDTO.Appointments = await ToDoctorsAppointments(repository, doctor);

            return TypedResults.Ok(doctorDTO);
        }
        [ProducesResponseType(StatusCodes.Status201Created)]
        public static async Task<IResult> CreateDoctor(IRepository repository, DoctorPostModel doctorPost)
        {
            Doctor doctor = new Doctor() { FullName = doctorPost.FullName };
            doctor = await repository.CreateDoctor(doctor);
            return TypedResults.Created($"https://localhost:7235/surgery/patients/{doctor.Id}");

        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetAppointmentsByDoctor(IRepository repository, int id)
        {
            var appointments = await repository.GetAppointmentsByDoctor(id);
            List<object> result = new List<object>();
            appointments.ToList().ForEach(a =>
            {
                result.Add(new { Doctor = a.Doctor.FullName, Patient = a.Patient.FullName});
            });
            return TypedResults.Ok(result);
        }
        
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetAppointmentsByPatient(IRepository repository, int id) 
        {
            var appointments = await repository.GetAppointmentsByPatient(id);
            List<object> result = new List<object>();
            appointments.ToList().ForEach(a =>
            {
                result.Add(new { Doctor = a.Doctor.FullName, Patient = a.Patient.FullName });
            });
            return TypedResults.Ok(result);
        }
        
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetAppointment(IRepository repository, int patientId, int doctorId) 
        {
            var appointment = await repository.GetAppointment(patientId, doctorId);
            var patient = await repository.GetAPatient(appointment.PatientId);
            var doctor = await repository.GetADoctor(appointment.DoctorId);

            AppointmentDTO newAppointment = new()
            {
                Booking = appointment.Booking,
                DoctorId = doctor.Id,
                DoctorName = doctor.FullName,
                PatientId = patient.Id,
                PatientName = patient.FullName
            };
            return TypedResults.Ok(newAppointment);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetAppointments(IRepository repository) 
        {
            var appointments = await repository.GetAppointments();
            List<AppointmentDTO> result = [];
            foreach(var appointment in appointments) 
            {
                var patient = await repository.GetAPatient(appointment.PatientId);
                var doctor = await repository.GetADoctor(appointment.DoctorId);

                AppointmentDTO newAppointment = new()
                {
                    Booking = appointment.Booking,
                    DoctorId = doctor.Id,
                    DoctorName = doctor.FullName,
                    PatientId = patient.Id,
                    PatientName = patient.FullName
                };
                result.Add(newAppointment);
            }
            return TypedResults.Ok(result);
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        public static async Task<IResult> CreateAppointment(IRepository repository, AppointmentPostModel appointment) 
        {
            var patient = await repository.GetAPatient(appointment.PatientId);
            var doctor = await repository.GetADoctor(appointment.DoctorId);

            Appointment newAppointment = new Appointment()
            {
                Booking = appointment.Booking,
                Patient = patient,
                PatientId = patient.Id,
                Doctor = doctor,
                DoctorId = doctor.Id
            };

            await repository.CreateAppointment(newAppointment);
            return TypedResults.Created($"https://localhost:7235/appointments/patient{appointment.PatientId}/doctor{appointment.DoctorId}");
        }

        private static async Task<List<PatientAppointmentDTO>> ToPatientAppointments(IRepository repository, Patient patient)
        {
            List<PatientAppointmentDTO> DTOappointments = [];
            foreach (var appointment in patient.Appointments)
            {
                var doctor = await repository.GetADoctor(appointment.DoctorId);
                var appointmentDTO = appointment.ToAppointmentDTO(doctor);
                DTOappointments.Add(appointmentDTO);
            }
            return DTOappointments;
        }
        private static async Task<List<DoctorsAppointmentDTO>> ToDoctorsAppointments(IRepository repository, Doctor doctor)
        {
            List<DoctorsAppointmentDTO> DTOappointments = [];
            foreach (var appointment in doctor.Appointments)
            {
                var patient = await repository.GetAPatient(appointment.PatientId);
                var appointmentDTO = appointment.ToAppointmentDTO(patient);
                DTOappointments.Add(appointmentDTO);
            }
            return DTOappointments;
        }


        }
    }

