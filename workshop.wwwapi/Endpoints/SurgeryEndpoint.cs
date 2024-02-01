﻿using Microsoft.AspNetCore.Mvc;
using workshop.wwwapi.Models;
using workshop.wwwapi.Models.PureModels;
using workshop.wwwapi.Models.TransferModels;
using workshop.wwwapi.Repository;

namespace workshop.wwwapi.Endpoints
{
    public static class SurgeryEndpoint
    {
        //TODO:  add additional endpoints in here according to the requirements in the README.md 
        // Would be cleaner to have in sperate files, but ok.
        public static void ConfigurePatientEndpoint(this WebApplication app)
        {
            var surgeryGroup = app.MapGroup("surgery");

            var patients = surgeryGroup.MapGroup("/patients");
            var doctors = surgeryGroup.MapGroup("/doctors");
            var appointments = surgeryGroup.MapGroup("/appointments");

            // Patients
            patients.MapGet("/", GetPatients);
            patients.MapGet("/{id}", GetSpecificPatient);
            patients.MapPost("/", CreatePatient);


            // Doctors
            doctors.MapGet("/", GetDoctors);
            doctors.MapGet("/{id}", GetSpecificDoctor);
            doctors.MapPost("/", CreateDoctor);

            // Appointments
            appointments.MapGet("/doctors/{id}", GetAppointmentsForDoctor);
            appointments.MapGet("/patients/{id}", GetAppointmentsForPatients);
            appointments.MapGet("/appointmentsbydoctor/{id}", GetAppointmentsByDoctor);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetPatients(IRepository repository)
        {
            var patients = await repository.GetPatients();


            IEnumerable<PatientDTO> patientsOut = patients.Select(p => new PatientDTO(p.Id, p.FullName));
            Payload<IEnumerable<PatientDTO>> payload = new Payload<IEnumerable<PatientDTO>>(patientsOut);

            return TypedResults.Ok(payload);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        private static async Task<IResult> GetSpecificPatient(IRepository repository, int id) 
        {
            var patient = await repository.GetPatientById(id);
            if (patient == null) 
            {
                return TypedResults.NotFound("No patient with the provided Id could be found");
            }

            PatientDTO patientOut = new PatientDTO(patient.Id, patient.FullName);
            Payload<PatientDTO> payload = new Payload<PatientDTO>(patientOut);

            return TypedResults.Ok(payload);
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        private static async Task<IResult> CreatePatient(IRepository repository, PatientInputDTO patientPost) 
        {
            Patient postedPatient = await repository.PostPatient(new Patient() { FullName = patientPost.fullName});

            Payload<Patient> payload = new Payload<Patient>(postedPatient);
            return TypedResults.Created($"/{postedPatient.Id}", payload);

        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetDoctors(IRepository repository)
        {
            var doctors = await repository.GetDoctors();

            IEnumerable<DoctorDTO> patientsOut = doctors.Select(d => new DoctorDTO(d.Id, d.FullName, d.Appointments)).ToList();
            Payload<IEnumerable<DoctorDTO>> payload = new Payload<IEnumerable<DoctorDTO>>(patientsOut);

            return TypedResults.Ok(payload);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> GetSpecificDoctor(IRepository repository, int id) 
        {
            Doctor? doc = await repository.GetSpecificDoctor(id);
            if (doc == null) 
            {
                return TypedResults.NotFound("No doctor with the provided id could be found.");
            }

            DoctorDTO docOut = new DoctorDTO(doc.Id, doc.FullName, doc.Appointments);
            Payload<DoctorDTO> payload = new Payload<DoctorDTO>(docOut);
            return TypedResults.Ok(payload);
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public static async Task<IResult> CreateDoctor(IRepository repository, DoctorInputDTO doctorPost) 
        {
            Doctor doctorInput = new Doctor() { FullName = doctorPost.fullName };

            Doctor postResult = await repository.PostDoctor(doctorInput);

            DoctorDTO doctorOut = new DoctorDTO(postResult.Id, postResult.FullName, postResult.Appointments);
            Payload<DoctorDTO> payload = new Payload<DoctorDTO>(doctorOut);
            return TypedResults.Created($"/{doctorOut.ID}", payload);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> GetAppointmentsForDoctor(IRepository repository, int id) 
        {
            IEnumerable<Appointment> appointments = await repository.GetAppointmentsForDoctors(id);
            if (appointments == null)
            {
                return TypedResults.NotFound($"No appointments for patient with id {id}");
            }

            IEnumerable<AppointmentDTO> appointmentsOut = appointments.Select(a => new AppointmentDTO(a.Booking, a.PatientId, a.DoctorId, a.Doctor, a.Patient));
            Payload<IEnumerable<AppointmentDTO>> payload = new Payload<IEnumerable<AppointmentDTO>>(appointmentsOut);
            return TypedResults.Ok(payload);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> GetAppointmentsForPatients(IRepository repository, int id)
        {
            IEnumerable<Appointment> appointments = await repository.GetAppointmentsForPatients(id);
            if (appointments == null)
            {
                return TypedResults.NotFound($"No appointments for patient with id {id}");
            }

            IEnumerable<AppointmentDTO> appointmentsOut = appointments.Select(a => new AppointmentDTO(a.Booking, a.PatientId, a.DoctorId, a.Doctor, a.Patient));
            Payload<IEnumerable<AppointmentDTO>> payload = new Payload<IEnumerable<AppointmentDTO>>(appointmentsOut);
            return TypedResults.Ok(payload);
        }


        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetAppointmentsByDoctor(IRepository repository, int id)
        {
            return TypedResults.Ok(await repository.GetAppointmentsByDoctor(id));
        }
    }
}
