using Microsoft.AspNetCore.Mvc;
using workshop.wwwapi.Enums;
using workshop.wwwapi.Models;
using workshop.wwwapi.Models.DTOs;
using workshop.wwwapi.Models.Post;
using workshop.wwwapi.Repository;

namespace workshop.wwwapi.Endpoints
{
    public static class SurgeryEndpoint
    {
        //TODO:  add additional endpoints in here according to the requirements in the README.md 
        public static void ConfigurePatientEndpoint(this WebApplication app)
        {
            var patients = app.MapGroup("patients");
            var doctors = app.MapGroup("doctors");
            var appointments = app.MapGroup("appointments");

            patients.MapGet("", GetPatients);
            patients.MapGet("/{id}", GetPatient);
            patients.MapPost("/{id}", AddPatient);

            doctors.MapGet("", GetDoctors);
            doctors.MapGet("/{id}", GetDoctor);
            doctors.MapPost("/{id}", AddDoctor)
                ;
            appointments.MapGet("", GetAppointments);
            appointments.MapGet("/{doctorId}&{patientId}", GetAppointment);
            appointments.MapGet("bydoctor/{id}", GetAppointmentsByDoctor);
            appointments.MapGet("bypatient/{id}", GetAppointmentsByPatient);
            appointments.MapPost("/{id}", AddAppointment);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetPatients(IRepository repository)
        {
            var patients = await repository.GetPatients();
            var patientsDTO = new List<PatientDTO>();

            foreach (var patient in patients)
            {
                patientsDTO.Add(patient.ToPatientDTO());
            }

            return TypedResults.Ok(patientsDTO);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> GetPatient(IRepository repository, int id)
        {
            var patient = await repository.GetPatient(id);

            if (patient == null)
            {
                return TypedResults.NotFound($"The patient with id {id} could not be found");
            }
            
            return TypedResults.Ok(patient.ToPatientDTO());
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public static async Task<IResult> AddPatient(IRepository repository, PatientDoctorPost patient)
        {
            if (patient == null)
            {
                return TypedResults.BadRequest("Invalid input for patient name");
            }

            Patient newPatient = new Patient { FullName = patient.FullName };
            return TypedResults.Created($"/{newPatient.Id}", await repository.AddPatient(newPatient));
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetDoctors(IRepository repository)
        {
            var doctors = await repository.GetDoctors();
            var doctorsDTO = new List<DoctorDTO>();

            foreach (var doctor in doctors)
            {
                doctorsDTO.Add(doctor.ToDTO());
            }

            return TypedResults.Ok(doctorsDTO);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> GetDoctor(IRepository repository, int id)
        {
            var doctor = await repository.GetDoctor(id);

            if (doctor == null)
            {
                return TypedResults.NotFound($"Doctor with id {id} could not be found");
            }

            return TypedResults.Ok(doctor.ToDTO());
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public static async Task<IResult> AddDoctor(IRepository repository, PatientDoctorPost doctor)
        {
            if (doctor == null)
            {
                return TypedResults.BadRequest("Invalid input for doctor name");
            }

            Doctor newDoctor = new Doctor { FullName = doctor.FullName };
            return TypedResults.Created($"{newDoctor.Id}", await repository.AddDoctor(newDoctor));
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetAppointments(IRepository repository)
        {
            var appointments = await repository.GetAppointments();
            var appointmentsDTO = new List<AppointmentResponseDTO>();

            foreach (var appointment in appointments)
            {
                appointmentsDTO.Add(appointment.ToResponseDTO());
            }

            return TypedResults.Ok(appointmentsDTO);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> GetAppointment(IRepository repository, int doctorId, int patientId)
        {
            var appointment = await repository.GetAppointment(doctorId, patientId);

            if (appointment == null)
            {
                return TypedResults.NotFound($"No appointment with doctor id {doctorId} and patient id {patientId} could not be found. Maybe they do not exist?");
            }

            return TypedResults.Ok(appointment.ToResponseDTO());
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> GetAppointmentsByDoctor(IRepository repository, int id)
        {
            var doctor = await repository.GetDoctor(id);

            if (doctor == null)
            {
                return TypedResults.NotFound($"Doctor with id {id} could not be found");
            }

            var appointments = await repository.GetAppointmentsByDoctor(id);
            var appointmentsDTO = new List<AppointmentDoctorDTO>();

            foreach (var appointment in appointments)
            {
                appointmentsDTO.Add(appointment.ToDoctorDTO());
            }

            var appointmentDoctorDTO = new AppointmentResponseDoctorDTO { 
                DoctorId = id,
                DoctorName = doctor.FullName,
                Appointments = appointmentsDTO};

            return TypedResults.Ok(appointmentDoctorDTO);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> GetAppointmentsByPatient(IRepository repository, int id)
        {
            var patient = await repository.GetPatient(id);

            if (patient == null)
            {
                return TypedResults.NotFound($"Patient with id {id} could not be found");
            }

            var appointments = await repository.GetAppointmentsByPatient(id);
            var appointmentsDTO = new List<AppointmentPatientDTO>();

            foreach (var appointment in appointments)
            {
                appointmentsDTO.Add(appointment.ToPatientDTO());
            }

            var appointmentPatientDTO = new AppointmentResponsePatientDTO {
                PatientId = id,
                PatientName = patient.FullName,
                Appointments = appointmentsDTO };

            return TypedResults.Ok(appointmentPatientDTO);
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> AddAppointment(IRepository repository, AppointmentPost appointmentPost)
        {
            if (!DateTime.TryParse(appointmentPost.BookingTime.ToString(), out DateTime time))
            {
                return TypedResults.BadRequest("Invalid datetime input!");
            }

            if (!Enum.IsDefined(typeof(AppointmentType), appointmentPost.AppointmentType)) {
                return TypedResults.BadRequest("Invalid appointment type! Use 0 for an online appointment and 1 for an in person appointment");
            }

            var appointment = await repository.AddAppointment(appointmentPost);

            if (appointment == null)
            {
                return TypedResults.NotFound($"Doctor with id {appointmentPost.DoctorId} or patient with id {appointmentPost.PatientId} could not be found");
            }

            return TypedResults.Created($"{appointment.PatientId}&{appointment.DoctorId}", appointment.ToResponseDTO());
        }
    }
}
