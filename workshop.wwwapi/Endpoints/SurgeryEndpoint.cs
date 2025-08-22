using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Numerics;
using workshop.wwwapi.DTOs;
using workshop.wwwapi.Models;
using workshop.wwwapi.NewFolder;
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
            surgeryGroup.MapGet("/patients/{id}", GetPatientsById);
            surgeryGroup.MapPost("/", AddPatient);
            surgeryGroup.MapGet("/doctors", GetDoctors);
            surgeryGroup.MapGet("/doctors/{id}", GetDoctorById);
            surgeryGroup.MapPost("/doctor", AddDoctor);
            surgeryGroup.MapGet("/appointments/", GetAllAppointments);
            surgeryGroup.MapGet("/appointmentsbydoctor/{id}", GetAppointmentsByDoctor);
            surgeryGroup.MapGet("/appointmentsbypatient/{id}", GetAppointmentsByPatient);
            surgeryGroup.MapPost("/appointment/", AddAppointment);


        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetPatients(IRepository repository)
        {
            List<Object> patients = new List<Object>();
            var results = await repository.GetPatients();
            foreach (var patient in results)
            {
                List<Object> appointmentDTO = new List<Object>();
                foreach (Appointment appointment in patient.Appointments)
                {
                    appointmentDTO.Add(new { Id = appointment.Id }); // Maybe add more later
                }
                patients.Add(new { Id = patient.Id, FullName = patient.FullName, Appointments = appointmentDTO });
            }

            return TypedResults.Ok(patients);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> GetPatientsById(IRepository repository, int id)
        {
            var patient = await repository.GetPatientById(id);
            if (patient == null) return TypedResults.NotFound(new {Error = "No Patient Found!"});
            List<Object> appointmentDTO = new List<Object>();
            foreach (Appointment appointment in patient.Appointments)
            {
                appointmentDTO.Add(new { Id = appointment.Id }); // Maybe add more later
            }
            var patientDTO = new { Id = patient.Id, Fullname = patient.FullName, Appointment = appointmentDTO };
            return TypedResults.Ok(patientDTO);
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public static async Task<IResult> AddPatient(IRepository repository, PatientPost model)
        {
            if (model.Fullname == "") return TypedResults.BadRequest(new { Error = "Need to type name!!" });

            Patient patient = new Patient();
            patient.FullName = model.Fullname;

            var results = await repository.AddAsync(patient);
            return TypedResults.Created($"https://localhost:7235/patients/{patient.Id}", new { Fullname = model.Fullname });
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetDoctors(IRepository repository)
        {
            List<Object> doctors = new List<Object>();
            var results = await repository.GetDoctors();
            foreach (var doctor in results)
            {
                List<Object> appointmentDTO = new List<Object>();
                foreach (Appointment appointment in doctor.Appointments)
                {
                    appointmentDTO.Add(new { Id = appointment.Id }); // Maybe add more later
                }
                doctors.Add(new { Id = doctor.Id, FullName = doctor.FullName, Appointments = appointmentDTO });
            }
            return TypedResults.Ok(doctors);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> GetDoctorById(IRepository repository, int id)
        {
            var doctor = await repository.GetDoctorById(id);
            if (doctor == null) return TypedResults.NotFound(new { Error = "No Doctor Found!" });
            List<Object> appointmentDTO = new List<Object>();
            foreach (Appointment appointment in doctor.Appointments)
            {
                appointmentDTO.Add(new { Id = appointment.Id }); // Maybe add more later
            }
            var doctorDTO = new { Id = doctor.Id, Fullname = doctor.FullName, Appointment = appointmentDTO };
            return TypedResults.Ok(doctorDTO);
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        public static async Task<IResult> AddDoctor(IRepository repository, DoctorPost model)
        {
            if (model.Fullname == "") return TypedResults.BadRequest(new { Error = "Need to type name!!" });

            Doctor doctor = new Doctor();
            doctor.FullName = model.Fullname;

            var results = await repository.AddAsync(doctor);
            return TypedResults.Created($"https://localhost:7235/doctors/{doctor.Id}", new { Fullname = model.Fullname });
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetAllAppointments(IRepository repository)
        {
            var results = await repository.GetAppointments();
            List<AppointmentGet> response = new List<AppointmentGet>();
            foreach (Appointment appointment in results)
            {
                response.Add(new AppointmentGet() { DoctorName = appointment.Doctor.FullName, AppointmentDate = appointment.Booking, PatientName = appointment.Patient.FullName });  
                
            }
            return TypedResults.Ok(response);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> GetAppointmentsByDoctor(IRepository repository, int id)
        {
            var results = await repository.GetAppointmentsByDoctor(id);
            if (results == null) return TypedResults.NotFound(new { Error = "No Doctor Found!" });

            List<AppointmentGet> response = new List<AppointmentGet>();
            foreach (Appointment appointment in results)
            {
                response.Add(new AppointmentGet() { DoctorName = appointment.Doctor.FullName, AppointmentDate = appointment.Booking, PatientName = appointment.Patient.FullName });

            }

            return TypedResults.Ok(response);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> GetAppointmentsByPatient(IRepository repository, int id)
        {
            var results = await repository.GetAppointmentsByPatient(id);
            if (results == null) return TypedResults.NotFound(new { Error = "No Patient Found!" });

            List<AppointmentGet> response = new List<AppointmentGet>();
            foreach (Appointment appointment in results)
            {
                response.Add(new AppointmentGet() { DoctorName = appointment.Doctor.FullName, AppointmentDate = appointment.Booking, PatientName = appointment.Patient.FullName });

            }

            return TypedResults.Ok(response);
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        public static async Task<IResult> AddAppointment(IRepository repository, AppointmentPost model)
        {
            Appointment appointment = new Appointment();
            appointment.Booking = model.Booking;
            appointment.PatientId = model.PatientId;
            appointment.DoctorId = model.DoctorId;
            var results = await repository.AddAsync(appointment);
            return TypedResults.Created($"https://localhost:7235/appointment/{appointment.Id}", new { Booking = model.Booking, Patient = model.PatientId, Doctor = model.DoctorId });
        }


    }
}
