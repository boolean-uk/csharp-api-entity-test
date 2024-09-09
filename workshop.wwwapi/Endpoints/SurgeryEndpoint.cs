using Microsoft.AspNetCore.Mvc;
using workshop.wwwapi.DTOs;
using workshop.wwwapi.Models;
using workshop.wwwapi.Repository;
using workshop.wwwapi.ViewModels;

namespace workshop.wwwapi.Endpoints
{
    public static class SurgeryEndpoint
    {
        public static void ConfigurePatientEndpoint(this WebApplication app)
        {
            var surgeryGroup = app.MapGroup("surgery");

            surgeryGroup.MapGet("/patients", GetPatients);
            surgeryGroup.MapGet("/patients/{id}", GetPatientById);
            surgeryGroup.MapPost("/patients", AddPatient);
            surgeryGroup.MapGet("/doctors", GetDoctors);
            surgeryGroup.MapPost("/doctors", GetDoctors);
            surgeryGroup.MapGet("/appointmentsbydoctor/{id}", GetAppointmentsByDoctor);
            surgeryGroup.MapGet("/appointmentsbypatient/{id}", GetAppointmentsByPatient);
            surgeryGroup.MapGet("/appointment/{patId}/{docId}", GetAppointmentById);
            surgeryGroup.MapGet("/appointments", GetAppointments);
            surgeryGroup.MapPost("/appointments", AddAppointment);
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetPatients(IRepository repository)
        { 
            var plist = await repository.GetPatients();
            List<PatientDTO> patients = new();
            foreach (var p in plist)
            {
                List<AppointmentDTO> appointments = new();
                foreach (var a in p.Appointments)
                {   
                    appointments.Add(new AppointmentDTO(a.Doctor.FullName, a.Booking));
                }
                patients.Add(new PatientDTO(p.FullName, appointments));
            }
            return TypedResults.Ok(patients);
        }
        
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetPatientById(IRepository repository, int id)
        { 
            var p = await repository.GetPatient(id);
            var appointments = p.Appointments.Select(a => new AppointmentDTO(a.Doctor.FullName, a.Booking)).ToList();
            return TypedResults.Ok(new PatientDTO(p.FullName, appointments));
        }
        
        [ProducesResponseType(StatusCodes.Status201Created)]
        public static async Task<IResult> AddPatient(IRepository repository, PostPatientModel patient)
        {
            var p = await repository.AddPatient(patient.FullName);
            var appointments = p.Appointments.Select(a => new AppointmentDTO(a.Doctor.FullName, a.Booking)).ToList();
            return TypedResults.Created("/patients/{id}",new PatientDTO(p.FullName, appointments));
        }
        
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetDoctors(IRepository repository)
        {
            var dlist = await repository.GetDoctors();
            List<DoctorDTO> doctors = new();
            foreach (var d in dlist)
            {
                List<AppointmentDTO> appointments = new();
                foreach (var a in d.Appointments)
                {   
                    appointments.Add(new AppointmentDTO(a.Patient.FullName, a.Booking));
                }
                doctors.Add(new DoctorDTO(d.FullName, appointments));
            }
            return TypedResults.Ok(doctors);
        }
        
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetDoctorById(IRepository repository, int id)
        {
            var d = await repository.GetDoctor(id);
            var appointments = d.Appointments.Select(a => new AppointmentDTO(a.Patient.FullName, a.Booking)).ToList();
            return TypedResults.Ok(new DoctorDTO(d.FullName, appointments));
        }
        
        [ProducesResponseType(StatusCodes.Status201Created)]
        public static async Task<IResult> AddDoctor(IRepository repository, PostDoctorModel doctor)
        {
            var d = await repository.AddDoctor(doctor.FullName);
            var appointments = d.Appointments.Select(a => new AppointmentDTO(a.Patient.FullName, a.Booking)).ToList();
            return TypedResults.Created("/doctors/{id}",new PatientDTO(d.FullName, appointments));
        }
        
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetAppointmentsByDoctor(IRepository repository, int id)
        {
            var doctor = await repository.GetDoctor(id);
            var alist = await repository.GetAppointmentsByDoctor(id);
            List<AppointmentDTO> appointments = new();
            foreach (var a in alist)
            {
                appointments.Add(new AppointmentDTO(a.Patient.FullName, a.Booking));
            }
            return TypedResults.Ok(new DoctorDTO(doctor.FullName, appointments));
        }
        
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetAppointmentsByPatient(IRepository repository, int id)
        {
            var patient = await repository.GetPatient(id);
            var alist = await repository.GetAppointmentsByPatient(id);
            List<AppointmentDTO> appointments = new();
            foreach (var a in alist)
            {
                appointments.Add(new AppointmentDTO(a.Doctor.FullName, a.Booking));
            }
            return TypedResults.Ok(new PatientDTO(patient.FullName, appointments));
        }
        
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetAppointmentById(IRepository repository, int patId, int docId)
        {
            var a = await repository.GetAppointment(patId, docId);
            return TypedResults.Ok(new FullAppointmentDTO(a.Patient.FullName, a.Doctor.FullName, a.Booking));
        }
        
        
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetAppointments(IRepository repository)
        {
            var alist = await repository.GetAppointments();
            List<FullAppointmentDTO> appointments = new();
            foreach (var a in alist)
            {
                appointments.Add(new FullAppointmentDTO(a.Patient.FullName, a.Doctor.FullName, a.Booking));
            }
            return TypedResults.Ok(appointments);
        }
        
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> AddAppointment(IRepository repository, PostAppointmentModel app)
        {
            var patient = await repository.GetPatient(app.PatientId);
            var doctor = await repository.GetDoctor(app.DoctorId);
            var appointment = new Appointment()
            {
                Booking = app.AppointmentTime,
                DoctorId = app.DoctorId,
                Doctor = doctor,
                PatientId = app.PatientId,
                Patient = patient
            };
            return TypedResults.Ok(appointment);
        }
    }
}
