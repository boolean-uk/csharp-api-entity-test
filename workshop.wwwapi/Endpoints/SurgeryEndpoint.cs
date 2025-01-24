using System.IO;
using Microsoft.AspNetCore.Mvc;
using workshop.wwwapi.DTO;
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
            surgeryGroup.MapGet("/patients/{id}", GetPatient);
            surgeryGroup.MapPost("/patients/", AddPatient);
            surgeryGroup.MapGet("/doctors", GetDoctors);
            surgeryGroup.MapGet("/doctors/{id}", GetDoctor);
            surgeryGroup.MapPost("/doctors", AddDoctor);
            surgeryGroup.MapGet("/appointments", GetAppointments);
            surgeryGroup.MapPost("/appointments", AddAppointment);
            surgeryGroup.MapGet("/appointmentsbydoctor/{id}", GetAppointmentsByDoctor);
            surgeryGroup.MapGet("/appointmentsbyid/{id}", GetAppointmentsById);
            surgeryGroup.MapGet("/appointmentsbypatient/{id}", GetAppointmentsByPatient);
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> AddPatient(IRepository repository, PatientPost model)
        {
            Patient patient = new Patient();
            patient.FullName = model.FullName;
            var result = await repository.AddPatient(patient);
            return TypedResults.Created($"https://localhost:7235/surgery/patients/{result.Id}", result);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetPatients(IRepository repository)
        {
            List<PatientDTO> patientDTOs = new List<PatientDTO>();
            var result = await repository.GetPatients();
            foreach(var pat in result)
            {
                PatientDTO patientDTO = new PatientDTO
                {
                    FullName = pat.FullName,
                    Id = pat.Id,
                };
                foreach(var appointment in pat.Appointments)
                {
                    var doctor = await repository.GetDoctor(appointment.DoctorId);
                    AppointmentdoctorDTO appoint = new AppointmentdoctorDTO();
                    appoint.Name = doctor.FullName;
                    appoint.Id = doctor.Id;
                    patientDTO.Appointments.Add(appoint);
                }
                patientDTOs.Add(patientDTO);
            }
            return TypedResults.Ok(patientDTOs);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetPatient(IRepository repository, int id)
        {
            var pat = await repository.GetPatient(id);
            PatientDTO patientDTO = new PatientDTO
            {
                FullName = pat.FullName,
                Id = pat.Id,
            };
            foreach (var appointment in pat.Appointments)
            {
                var doctor = await repository.GetDoctor(appointment.DoctorId);
                AppointmentdoctorDTO appoint = new AppointmentdoctorDTO();
                appoint.Name = doctor.FullName;
                appoint.Id = doctor.Id;
                patientDTO.Appointments.Add(appoint);
            }
            return TypedResults.Ok(patientDTO);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> AddDoctor(IRepository repository, DoctorPost model)
        {
            Doctor doctor = new Doctor();
            doctor.FullName = model.FullName;
            var result = await repository.AddDoctor(doctor);
            return TypedResults.Created($"https://localhost:7235/surgery/doctors/{result.Id}", result);
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetDoctors(IRepository repository)
        {
            List<DoctorDTO> doctorDTOs = new List<DoctorDTO>();
            var result = await repository.GetDoctors();
            foreach(var doc in result)
            {
               DoctorDTO temp =  new DoctorDTO{
                    Id = doc.Id,
                    FullName = doc.FullName
                };
                foreach (var appointment in doc.Appointments)
                {
                    var patient = await repository.GetPatient(appointment.PatientId);
                    AppointmentdoctorDTO appoint = new AppointmentdoctorDTO();
                    appoint.Name = patient.FullName;
                    appoint.Id = patient.Id;
                    temp.Appointments.Add(appoint);
                }
                doctorDTOs.Add(temp);
            }
            return TypedResults.Ok(doctorDTOs);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetDoctor(IRepository repository, int id)
        {
            var result = await repository.GetDoctor(id);
            DoctorDTO doctorDTO = new DoctorDTO();

            doctorDTO.Id = result.Id;
            doctorDTO.FullName = result.FullName;
            foreach(var appointment in result.Appointments)
            {
                var patient = await repository.GetPatient(appointment.PatientId);
                AppointmentdoctorDTO appoint = new AppointmentdoctorDTO();
                appoint.Name = patient.FullName;
                appoint.Id = patient.Id;
                doctorDTO.Appointments.Add(appoint);
            }
            return TypedResults.Ok(doctorDTO);
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetAppointments(IRepository repository)
        {
            List<AppointmentDTO> appointmentDTOs = new List<AppointmentDTO>();
            var appointments = await repository.GetAppointments();
            foreach (var appointment in appointments)
            {
                var doc = await repository.GetDoctor(appointment.DoctorId);
                var pat = await repository.GetPatient(appointment.PatientId);
                AppointmentDTO appointmentDTO = new AppointmentDTO
                {
                    DateTime = appointment.Booking,
                    DoctorId = doc.Id,
                    DoctorName = doc.FullName,
                    PatientId = pat.Id,
                    PatientName = pat.FullName
                };
                appointmentDTOs.Add(appointmentDTO);
            }
            return TypedResults.Ok(appointmentDTOs);
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> AddAppointment(IRepository repository, AppointmentPost model)
        {
            Appointment appointment = new Appointment();
            var patient = await repository.GetPatient(model.PatientId);
            var doctor = await repository.GetDoctor(model.DoctorId);
            appointment.DoctorId = doctor.Id;
            appointment.PatientId = patient.Id;
            appointment.Booking = DateTime.UtcNow.Date;
            var result = repository.AddAppointment(appointment);
            doctor.Appointments.ToList().Add(result.Result);
            patient.Appointments.ToList().Add(result.Result);
            return TypedResults.Ok(result.Result);
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetAppointmentsByDoctor(IRepository repository, int id)
        {
            List<AppointmentDTO> appointmentDTOs = new List<AppointmentDTO>();
            var appointments = await repository.GetAppointmentsByDoctor(id);
            foreach (var appointment in appointments)
            {
                var doc = await repository.GetDoctor(appointment.DoctorId);
                var pat = await repository.GetPatient(appointment.PatientId);
                AppointmentDTO appointmentDTO = new AppointmentDTO
                {
                    DateTime = appointment.Booking,
                    DoctorId = doc.Id,
                    DoctorName = doc.FullName,
                    PatientId = pat.Id,
                    PatientName = pat.FullName
                };
                appointmentDTOs.Add(appointmentDTO);
            }
            return TypedResults.Ok(appointmentDTOs);
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetAppointmentsById(IRepository repository, int id)
        {
            List<AppointmentDTO> appointmentDTOs = new List<AppointmentDTO>();
            var appointments = await repository.GetAppointmentsById(id);
            foreach (var appointment in appointments)
            {
                var doc = await repository.GetDoctor(appointment.DoctorId);
                var pat = await repository.GetPatient(appointment.PatientId);
                AppointmentDTO appointmentDTO = new AppointmentDTO
                {
                    DateTime = appointment.Booking,
                    DoctorId = doc.Id,
                    DoctorName = doc.FullName,
                    PatientId = pat.Id,
                    PatientName = pat.FullName
                };
                appointmentDTOs.Add(appointmentDTO);
            }
            return TypedResults.Ok(appointmentDTOs);
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetAppointmentsByPatient(IRepository repository, int id)
        {
            List<AppointmentDTO> appointmentDTOs = new List<AppointmentDTO>();
            var appointments = await repository.GetAppointmentsByPatient(id);
            foreach (var appointment in appointments)
            {
                var doc = await repository.GetDoctor(appointment.DoctorId);
                var pat = await repository.GetPatient(appointment.PatientId);
                AppointmentDTO appointmentDTO = new AppointmentDTO
                {
                    DateTime = appointment.Booking,
                    DoctorId = doc.Id,
                    DoctorName = doc.FullName,
                    PatientId = pat.Id,
                    PatientName = pat.FullName
                };
                appointmentDTOs.Add(appointmentDTO);
            }
            return TypedResults.Ok(appointmentDTOs);
        }
    }
}
