using Microsoft.AspNetCore.Mvc;
using System.Numerics;
using workshop.wwwapi.DTOs;
using workshop.wwwapi.Models;
using workshop.wwwapi.Repository;

namespace workshop.wwwapi.Endpoints
{
    public static class SurgeryEndpoint
    {
        //TODO:  add additional endpoints in here according to the requirements in the README.md 
        //get all appointments []
        //get appointment by id,
        //get appointments by doctor id,
        //get appointments by patient id
        //create new appointment
        //Update all dtos for patient, doctor and appointments to include the relevant loaded fields via the relations

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
                    new AppointmentDTO
                    {
                        Id = appointment.Id,
                        Booking = appointment.Booking,
                        Patient = new PatientDTO(appointment.Patient),
                        Doctor = new DoctorDTO(appointment.Doctor)
                    }
                ); 
            }
            return TypedResults.Ok(appointments);
        }

        public static async Task<IResult> GetAppointment(IRepository repository, int id)
        {
            var result = await repository.GetAppointment(id);
            var appointment = new AppointmentDTO
            {
                Id = result.Id,
                Booking = result.Booking,
                Patient = new PatientDTO(result.Patient),
                Doctor = new DoctorDTO(result.Doctor)
               
            };
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
            var a = new AppointmentDTO
            {
                Id=result.Id,
                Booking = result.Booking,
                Patient = new PatientDTO(result.Patient),
                Doctor = new DoctorDTO(result.Doctor)
            };
            return TypedResults.Ok(a);
        }

    }


}
