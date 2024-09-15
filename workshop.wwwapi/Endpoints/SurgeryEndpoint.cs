using Microsoft.AspNetCore.Mvc;
using System.Numerics;
using workshop.wwwapi.DTOs;
using workshop.wwwapi.Models;
using workshop.wwwapi.Repository;

namespace workshop.wwwapi.Endpoints
{
    public static class SurgeryEndpoint
    {
        public static void ConfigurePatientEndpoint(this WebApplication app)
        {
            var surgeryGroup = app.MapGroup("surgery");
            surgeryGroup.MapGet("/patients", GetPatients);
            surgeryGroup.MapGet("/patients/{id}", GetPatient);
            surgeryGroup.MapGet("/doctors", GetDoctors);
            surgeryGroup.MapGet("/doctors/{id}", GetDoctor);
            surgeryGroup.MapGet("/appointments", GetAppointments);
            surgeryGroup.MapGet("/appointments/{id}", GetAppointment);
            surgeryGroup.MapGet("/appointments/doctors/{id}", GetDoctorsAppointments);
            surgeryGroup.MapGet("/appointments/patients/{id}", GetPatientsAppointments);
            surgeryGroup.MapPost("/appointments/appointment", NewAppointment);

            app.MapGet("/prescriptions", GetPrescriptions);
            app.MapPost("/prescriptions", CreatePrescription);
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetPatient(IRepository repository, int id)
        {
            var result = await repository.GetPatient(id);
            return TypedResults.Ok(new PatientDTO(result));
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetPatients(IRepository repository)
        {
            var result = await repository.GetPatients();
            List<PatientDTO> patients = new List<PatientDTO>();
            foreach (var patient in result)
            {
                patients.Add(new PatientDTO(patient));
            }
            return TypedResults.Ok(await repository.GetPatients());
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetDoctor(IRepository repository, int id)
        {
            var result = await repository.GetDoctor(id);
            if (result == null)
            {
                return TypedResults.NotFound("Doctor not found");
            }
            return TypedResults.Ok(new DoctorDTO(result));
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetDoctors(IRepository repository)
        {
            var result = await repository.GetDoctors();
            List<DoctorDTO> doctors = new List<DoctorDTO>();
            foreach (var doctor in result)
            {
                doctors.Add(new DoctorDTO(doctor));
            }
            return TypedResults.Ok(doctors);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetAppointments(IRepository repository)
        {
            var result = await repository.GetAppointments();
            List<AppointmentDTO> appointments = new List<AppointmentDTO>();
            foreach (var appointment in result)
            {
                appointments.Add(
                    new AppointmentDTO(appointment)
                ); 
            }
            return TypedResults.Ok(appointments);
        }

        public static async Task<IResult> GetAppointment(IRepository repository, int id)
        {
            var result = await repository.GetAppointment(id);
            var appointment = new AppointmentDTO(result);
            return TypedResults.Ok(appointment);
        }

        public static async Task<IResult> GetDoctorsAppointments(IRepository repository, int id)
        {
            var result = await repository.GetDoctorWithAppointments(id);
            var appointment = new DoctorsAppointmentsDTO(result);
            return TypedResults.Ok(appointment);
        }
        public static async Task<IResult> GetPatientsAppointments(IRepository repository, int id)
        {
            var result = await repository.GetPatientWithAppointments(id);
            var appointment = new PatientsAppointmentsDTO(result);
            return TypedResults.Ok(appointment);
        }

        public static async Task<IResult> NewAppointment(IRepository repository, PostAppointment appointment)
        {
            var result = await repository.AddAppointment(appointment);
            var a = new AppointmentDTO(result);
            return TypedResults.Ok(a);
        }

        public static async Task<IResult> GetPrescriptions(IRepository repository)
        {
            var result = await repository.GetPrescriptions();
            List<PrescriptionDTO> prescriptions = new List<PrescriptionDTO>();
            foreach (var prescription in result)
            {
                prescriptions.Add(new PrescriptionDTO(prescription));
            }
            return TypedResults.Ok(prescriptions);
        }

        public static async Task<IResult> CreatePrescription(IRepository repository, PrescriptionPost prescriptionPost, int appointmentId, int medicineId)
        {
            // Should update tables Prescription and PrescriptionMedicine
            var p = new Prescription
            {
                AppointmentId = appointmentId,
                MedicineId = medicineId,
                Note = prescriptionPost.Note,
                Quantity = prescriptionPost.Quantity
            };
            var prescription = await repository.AddPrescription(p);

            return TypedResults.Ok(new PrescriptionDTO(prescription));
        }

    }


}
