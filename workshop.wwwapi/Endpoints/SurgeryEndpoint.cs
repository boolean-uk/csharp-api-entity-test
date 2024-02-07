using Microsoft.AspNetCore.Mvc;
using System.Numerics;
using workshop.wwwapi.Data;
using workshop.wwwapi.DTOs;
using workshop.wwwapi.DTOs.Core;
using workshop.wwwapi.DTOs.Extension;
using workshop.wwwapi.Models.Post.Core;
using workshop.wwwapi.Models.Post.Extension;
using workshop.wwwapi.Repository;

namespace workshop.wwwapi.Endpoints
{
    public static class SurgeryEndpoint
    {
        //TODO:  add additional endpoints in here according to the requirements in the README.md 
        public static void ConfigureSurgeryEndpoint(this WebApplication app)
        {
            var surgeryGroup = app.MapGroup("surgery");

            surgeryGroup.MapGet ("/patients", GetPatients);
            surgeryGroup.MapGet ("/patients/{id}", GetPatientById);
            surgeryGroup.MapPost("/patients", CreatePatient);

            surgeryGroup.MapGet ("/doctors", GetDoctors);
            surgeryGroup.MapGet ("/doctors/{id}", GetDoctorById);
            surgeryGroup.MapPost("/doctors", CreateDoctor);

            surgeryGroup.MapGet ("/appointments", GetAppointments);
            surgeryGroup.MapGet ("/appointmentsbydoctor/{id}", GetAppointmentsByDoctor);
            surgeryGroup.MapGet ("/appointmentsbypatient/{id}", GetAppointmentsByPatient);
            surgeryGroup.MapPost("/appointments", CreateAppointment);

            surgeryGroup.MapGet ("/Prescriptions", GetPrescriptions);
            surgeryGroup.MapGet ("/Prescriptions/{id}", GetPrescriptionById);
            surgeryGroup.MapPost("/Prescriptions", CreatePrescription);
        }

        //PATIENTS

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetPatients(IRepository repository)
        {
            var patientClasses = await repository.GetPatients();
            List<PatientDTO_L2> patientDTOs = new List<PatientDTO_L2>();

            foreach (var patient in patientClasses)
            {
                var patientDTO = DTOHelper.CreatePatientDTO(patient);
                patientDTOs.Add(patientDTO);
            }

            return TypedResults.Ok(patientDTOs);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetPatientById(IRepository repository, int id)
        {
            var patientClass = await repository.GetPatientById(id);

            if (patientClass == null)
            {
                return TypedResults.NotFound("Patient not found");
            }

            var patientDTO = DTOHelper.CreatePatientDTO(patientClass);

            return TypedResults.Ok(patientDTO);
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        public static async Task<IResult> CreatePatient(IRepository repository, PatientPost model)
        {
            if (!NameHelper.NameCheck(model.FullName))
            {
                return TypedResults.BadRequest("Please write name correctly");
            }

            var patient = await repository.CreatePatient(model);
            return TypedResults.Created($"/{patient.Id}", patient);
        }


        //DOCTORS

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetDoctors(IRepository repository)
        {
            var doctorClasses = await repository.GetDoctors();
            List<DoctorDTO_L2> doctorDTOs = new List<DoctorDTO_L2>();

            foreach (var doctor in doctorClasses)
            {
                var doctorDTO = DTOHelper.CreateDoctortDTO(doctor);
                doctorDTOs.Add(doctorDTO);
            }

            return TypedResults.Ok(doctorDTOs);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetDoctorById(IRepository repository, int id)
        {
            var doctorClass = await repository.GetDoctorById(id);

            if (doctorClass == null)
            {
                return TypedResults.NotFound("Doctor not found");
            }

            var doctorDTO = DTOHelper.CreateDoctortDTO(doctorClass);

            return TypedResults.Ok(doctorDTO);
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        public static async Task<IResult> CreateDoctor(IRepository repository, DoctorPost model)
        {
            if (!NameHelper.NameCheck(model.FullName))
            {
                return TypedResults.BadRequest("Please write name correctly");
            }

            var doctor = await repository.CreateDoctor(model);
            return TypedResults.Created($"/{doctor.Id}", doctor);
        }


        //APPOINTMENTS

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetAppointments(IRepository repository)
        {
            var appointments = await repository.GetAppointments();
            var appointmentDTOs = DTOHelper.AppointmentDTOListReturner(appointments);

            if (appointmentDTOs.Count == 0)
            {
                return TypedResults.NotFound("No appointments found");
            }
            return TypedResults.Ok(appointmentDTOs);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetAppointmentsByDoctor(IRepository repository, int id)
        {
            var appointments = await repository.GetAppointmentsByDoctor(id);
            var appointmentDTOs = DTOHelper.AppointmentDTOListReturner(appointments);

            if (appointmentDTOs.Count == 0)
            {
                return TypedResults.NotFound("No appointments found");
            }
            return TypedResults.Ok(appointmentDTOs);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetAppointmentsByPatient(IRepository repository, int id)
        {
            var appointments = await repository.GetAppointmentsByPatient(id);
            var appointmentDTOs = DTOHelper.AppointmentDTOListReturner(appointments);

            if (appointmentDTOs.Count == 0)
            {
                return TypedResults.NotFound("No appointments found");
            }
            return TypedResults.Ok(appointmentDTOs);
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        public static async Task<IResult> CreateAppointment(IRepository repository, AppointmentPost model)
        {
            var patient = await repository.GetPatientById(model.PatientId);
            if (patient == null)
            {
                return TypedResults.BadRequest("Patient does not exist");
            }

            var doctor = await repository.GetDoctorById(model.DoctorId);
            if (doctor == null)
            {
                return TypedResults.BadRequest("Doctor does not exist");
            }

            var appointmentClass = await repository.CreateAppointment(model);

            var apointmentDTO = DTOHelper.CreateAppointmentDTO(appointmentClass);

            return TypedResults.Created($"/{apointmentDTO.Id}", apointmentDTO);
        }

        //PRESCRIPTIONS
        [ProducesResponseType(StatusCodes.Status200OK)]
        private static async Task<IResult> GetPrescriptions(IRepository repository)
        {
            var prescriptionClasses = await repository.GetPrescriptions();
            List<PrescriptionDTO_L2> prescriptionDTOs = new List<PrescriptionDTO_L2>();

            foreach(var prescription in prescriptionClasses)
            {
                var prescriptionDTO = DTOHelper.CreatePrescriptionDTO(prescription);
                prescriptionDTOs.Add(prescriptionDTO);
            }

            return TypedResults.Ok(prescriptionDTOs);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        private static async Task<IResult> GetPrescriptionById(IRepository repository, int id)
        {
            var prescriptionClass = await repository.GetPrescriptionById(id);

            if (prescriptionClass == null)
            {
                return TypedResults.NotFound("Prescription does not exist");
            }

            var prescriptionDTO = DTOHelper.CreatePrescriptionDTO(prescriptionClass);

            return TypedResults.Ok(prescriptionDTO);
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        private static async Task<IResult> CreatePrescription(IRepository repository, PrescriptionPost model)
        {
            var areMedicineIdsValid = await repository.AreMedicineIDsValid(model.MedicineIds);
            if(!areMedicineIdsValid)
            {
                return TypedResults.BadRequest("One or more medicine not found");
            }

            var appointment = await repository.GetAppointmentById(model.AppointmentId);
            if (appointment == null)
            {
                return TypedResults.BadRequest("Appointment does not exist");
            }

            var prescriptionClass = await repository.CreatePrescription(model);
            if(prescriptionClass == null)
            {
                return TypedResults.BadRequest("Prescription could not be created"); //This should not happen due to the areMedicinesValid check, but better safe than sorry
            }

            var prescriptionDTO = DTOHelper.CreatePrescriptionDTO(prescriptionClass);

            return TypedResults.Created($"/{prescriptionDTO.Id}", prescriptionDTO);
        }


        //MEDICINEPRESCRIPTION
        /* Late in the day and I just thought really backwards, or not thinking at all.
        [ProducesResponseType(StatusCodes.Status200OK)]
        private static async Task<IResult> GetMedicinePrescription(IRepository repository)
        {
            var medicinePrescriptions = await repository.GetMedicinePrescriptions();
            var medicinePrescriptionDTOs = DTOHelper.MedicinePrescriptionDTOListReturner(medicinePrescriptions);

            if (medicinePrescriptionDTOs.Count == 0)
            {
                return TypedResults.NotFound("No medicine prescriptions found");
            }

            return TypedResults.Ok(medicinePrescriptionDTOs);
        }


        [ProducesResponseType(StatusCodes.Status200OK)]
        private static async Task<IResult> GetMedicinePrescriptionById(IRepository repository, int id)
        {
            var MedicinePrescriptionClass = await repository.GetMedicinePrescriptionsById(id);

            if (MedicinePrescriptionClass == null)
            {
                return TypedResults.NotFound("Medicine prescription does not exist");
            }

            var medicinePrescriptionDTOs = DTOHelper.CreateMedicinePrescriptionDTO(MedicinePrescriptionClass);

            return TypedResults.Ok(medicinePrescriptionDTOs);
        }


        [ProducesResponseType(StatusCodes.Status201Created)]
        private static async Task<IResult> CreateMedicinePrescription(IRepository repository, MedicinePrescriptionPost model)
        {
            var medicine = await repository.GetMedicineById(model.MedicineId);
            if (medicine == null)
            {
                return TypedResults.BadRequest("Medicine does not exist");
            }
            var prescription = await repository.GetPrescriptionById(model.PrescriptionId);
            if (prescription == null)
            {
                return TypedResults.BadRequest("Prescription does not exist");
            }
            var appointment = await repository.GetAppointmentById(model.AppointmentId);
            if (appointment == null)
            {
                return TypedResults.BadRequest("Appointment does not exist");
            }

            var medicineAppointmentClass = await repository.CreateMedicinePrescription(model);
            var medicineAppointmentDTO = DTOHelper.CreateMedicinePrescriptionDTO(medicineAppointmentClass);

            return TypedResults.Created($"/{medicineAppointmentDTO.Id}", medicineAppointmentDTO);
        }
         */
    }
}
