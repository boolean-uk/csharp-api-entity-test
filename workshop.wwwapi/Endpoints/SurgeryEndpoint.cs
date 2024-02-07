﻿using Microsoft.AspNetCore.Mvc;
using workshop.wwwapi.Models;
using workshop.wwwapi.Models.DTOs;
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
            surgeryGroup.MapGet("/patients/{id}", GetPatient);
            surgeryGroup.MapGet("/doctors", GetDoctors);
            surgeryGroup.MapGet("/doctors/{id}", GetDoctor);
            //surgeryGroup.MapGet("/appointmentsbydoctor/{id}", GetAppointmentsByDoctor);
            surgeryGroup.MapGet("/prescriptions", GetPrescriptions);
            surgeryGroup.MapGet("/prescriptions/{id}", GetPrescription);
            surgeryGroup.MapPost("/prescriptions/{id}", CreatePrescription);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetPatients(IRepository repository)
        {
            var patients = await repository.GetPatients();
            var returnList = new List<PatientWithAppointmentsDoctorAndPrescriptionDTO>();
            foreach (var patient in patients)
            {
                returnList.Add(PatientWithAppointmentsDoctorAndPrescriptionDTO.ToDTO(patient));
            }
            return TypedResults.Ok(returnList);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetPatient(IRepository repository, int id)
        {
            var patient = await repository.GetPatient(id);
            if (patient == null)
            {
                return TypedResults.NotFound($"Id: {id} not found!");
            }
            return TypedResults.Ok(PatientWithAppointmentsDoctorAndPrescriptionDTO.ToDTO(patient));
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetDoctors(IRepository repository)
        {
            var doctors = await repository.GetDoctors();
            var returnList = new List<DoctrorWithAppointmentsPatientAndPrescriptionDTO>();
            foreach (var doctor in doctors)
            {
                returnList.Add(DoctrorWithAppointmentsPatientAndPrescriptionDTO.ToDTO(doctor));
            }
            return TypedResults.Ok(returnList);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetDoctor(IRepository repository, int id)
        {
            var doctor = await repository.GetDoctor(id);
            if (doctor == null)
            {
                return TypedResults.NotFound($"Id: {id} not found!");
            }
            return TypedResults.Ok(DoctrorWithAppointmentsPatientAndPrescriptionDTO.ToDTO(doctor));
        }

        /*[ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetAppointmentsByDoctor(IRepository repository, int id)
        {
            return TypedResults.Ok(await repository.GetAppointmentsByDoctor(id));
        }*/

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetPrescriptions(IRepository repository)
        {
            var prescriptions = await repository.GetPrescriptions();
            var returnList = new List<PrescriptionWithMedicinesDTO>();
            foreach (var prescription in prescriptions)
            {
                returnList.Add(PrescriptionWithMedicinesDTO.ToDTO(prescription));
            }
            return TypedResults.Ok(returnList);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetPrescription(IRepository repository, int id)
        {
            var prescription = await repository.GetPrescription(id);
            if (prescription == null)
            {
                return TypedResults.NotFound($"Id: {id} not found!");
            }
            return TypedResults.Ok(PrescriptionWithMedicinesDTO.ToDTO(prescription));
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        public static async Task<IResult> CreatePrescription(IRepository repository, int id, PostPrescription prescription)
        {
            var appointment = await repository.GetAppointment(id);
            if (appointment == null)
            {
                return TypedResults.NotFound($"Appointment-Id: {id} not found!");
            }

            var newPrescription = await repository.CreatePrescription(prescription);
            if (newPrescription == null)
            {
                return TypedResults.NotFound($"Could not find all medicines!");
            }

            appointment.Prescription = newPrescription;
            await repository.SaveChangesAsync();
            return TypedResults.Created($"/prescriptions/{newPrescription.Id}", PrescriptionWithMedicinesDTO.ToDTO(newPrescription));
        }
    }
}
