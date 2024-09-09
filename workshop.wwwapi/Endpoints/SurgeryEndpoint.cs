﻿using Microsoft.AspNetCore.Mvc;
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
            surgeryGroup.MapGet("/patients/{patientid}", GetPatientById);
            surgeryGroup.MapPost("/patients/{patientid}", AddPatient);
            surgeryGroup.MapGet("/doctors", GetDoctors);
            surgeryGroup.MapGet("/doctors/{doctorid}", GetDoctorById);
            surgeryGroup.MapPost("/doctors/{doctorid}", AddDoctor);
            surgeryGroup.MapGet("/appointments", GetAppointments);
            surgeryGroup.MapGet("/appointments/{doctorid}/{patientid}", GetAppointmentById);
            surgeryGroup.MapGet("/appointmentsbydoctor/{doctorid}", GetAppointmentsByDoctor);
            surgeryGroup.MapGet("/appointmentsbypatient/{patientid}", GetAppointmentsByPatient);
            surgeryGroup.MapPost("/appointments/{patientid}", AddAppointment);
        }


        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetPatients(IRepository repository)
        { 
            GetPatientsResponse response = new GetPatientsResponse();
            var results = await repository.GetPatients();
            foreach (Patient p in results) 
            {
                DTOPatient patient = new DTOPatient();
                patient.PatientName = p.FullName;

                response.Patients.Add(patient);
            
            }

            return TypedResults.Ok(response);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public static async Task<IResult> GetPatientById(IRepository repository, int patientid)
        {
            var getPatient = await repository.GetPatientById(patientid);
            if(getPatient != null)
            {
                DTOPatient patient = new DTOPatient();
                patient.PatientName = getPatient.FullName;
                return TypedResults.Ok(patient);
            }
            return TypedResults.BadRequest("No patient matches given id");
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public static async Task<IResult> AddPatient(IRepository repository, string patientname)
        {
            if (patientname == null)
            {
                return TypedResults.BadRequest("Patient name is not valid");
            }
            Patient addPatient = await repository.AddPatient(patientname);
            DTOPatient patient = new DTOPatient();
            patient.PatientName = addPatient.FullName;

            return TypedResults.Ok(patient);
        }


        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetDoctors(IRepository repository)
        {
            GetDoctorsResponse response = new GetDoctorsResponse();
            var results = await repository.GetDoctors();

            foreach (Doctor d in results)
            {
                DTODoctor doctor = new DTODoctor();
                doctor.DoctorName = d.FullName;

                response.Doctors.Add(doctor);

            }

            return TypedResults.Ok(response);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public static async Task<IResult> GetDoctorById(IRepository repository, int doctorid)
        {
            var getDoctor = await repository.GetDoctorById(doctorid);
            if (getDoctor != null)
            {
                DTODoctor doctor = new DTODoctor();
                doctor.DoctorName = getDoctor.FullName;
                return TypedResults.Ok(doctor);
            }
            return TypedResults.BadRequest("No doctor matches given id");
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public static async Task<IResult> AddDoctor(IRepository repository, string doctorname)
        {
            if (doctorname == null)
            {
                return TypedResults.BadRequest("Doctor name is not valid");
            }
            Doctor addDoctor = await repository.AddDoctor(doctorname);
            DTODoctor doctor = new DTODoctor();
            doctor.DoctorName = addDoctor.FullName;

            return TypedResults.Ok(doctor);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetAppointments(IRepository repository)
        {
            GetAppointmentsResponse response = new GetAppointmentsResponse();
            var results = await repository.GetAppointments();

            foreach (Appointment a in results)
            {
                DTOAppointment appointment = new DTOAppointment();
                Doctor doctor = await repository.GetDoctorById(a.DoctorId);
                Patient patient = await repository.GetPatientById(a.PatientId);

                appointment.AppointmentDate = a.AppointmentDate;
                appointment.Doctor = doctor.FullName;
                appointment.Patient = patient.FullName;

                response.Appointments.Add(appointment);

            }

            return TypedResults.Ok(response);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public static async Task<IResult> GetAppointmentById(IRepository repository, int doctorid, int patientid)
        {
            DTOAppointment appointment = new DTOAppointment();

            var results = await repository.GetAppointmentById(doctorid, patientid);
            if(results != null) 
            {
                Doctor doctor = await repository.GetDoctorById(doctorid);
                Patient patient = await repository.GetPatientById(patientid);

                appointment.AppointmentDate = results.AppointmentDate;
                appointment.Doctor = doctor.FullName;
                appointment.Patient = patient.FullName;

                return TypedResults.Ok(appointment);
            }
            return TypedResults.BadRequest("No appointment matches given information");

        }


        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetAppointmentsByDoctor(IRepository repository, int doctorid)
        {
            GetAppointmentsResponse response = new GetAppointmentsResponse();
            var results = await repository.GetAppointmentsByDoctor(doctorid);
            Doctor doctor = await repository.GetDoctorById(doctorid);
            

            foreach (Appointment a in results) 
            {
                DTOAppointment appointment = new DTOAppointment();
                Patient patient = await repository.GetPatientById(a.PatientId);
                appointment.AppointmentDate = a.AppointmentDate;
                appointment.Doctor = doctor.FullName;
                appointment.Patient = patient.FullName;

                response.Appointments.Add(appointment);

            }
            return TypedResults.Ok(response);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetAppointmentsByPatient(IRepository repository, int patientid)
        {
            GetAppointmentsResponse response = new GetAppointmentsResponse();
            var results = await repository.GetAppointmentsByPatient(patientid);
            Patient patient = await repository.GetPatientById(patientid);


            foreach (Appointment a in results)
            {
                DTOAppointment appointment = new DTOAppointment();
                Doctor doctor = await repository.GetDoctorById(a.DoctorId);
                appointment.AppointmentDate = a.AppointmentDate;
                appointment.Doctor = doctor.FullName;
                appointment.Patient = patient.FullName;

                response.Appointments.Add(appointment);

            }
            return TypedResults.Ok(response);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public static async Task<IResult> AddAppointment(IRepository repository, int doctorid, int patientid)
        {
            Doctor doctor = await repository.GetDoctorById(doctorid);
            Patient patient = await repository.GetPatientById(patientid);

            if (doctor != null && patient != null) 
            {
                Appointment appointment = new Appointment() { AppointmentDate = DateTime.UtcNow, DoctorId = doctorid, PatientId = patientid };

                var results = await repository.AddAppointment(appointment);
                DTOAppointment newAppointment = new DTOAppointment();
                newAppointment.AppointmentDate = results.AppointmentDate;
                newAppointment.Patient = patient.FullName;
                newAppointment.Doctor = doctor.FullName;
                return TypedResults.Ok(newAppointment);
            }

            return TypedResults.BadRequest("Appointmentinformation is not valid");
            
            
        }

    }
}
