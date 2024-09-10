using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using workshop.wwwapi.DTO;
using workshop.wwwapi.Models;
using workshop.wwwapi.Repository;
using workshop.wwwapi.ViewModels;

namespace workshop.wwwapi.Endpoints
{
    public static class SurgeryEndpoint
    {
        //TODO:  add additional endpoints in here according to the requirements in the README.md 
        public static void ConfigurePatientEndpoint(this WebApplication app)
        {
            var surgeryGroup = app.MapGroup("surgery");

            surgeryGroup.MapGet("/patients", GetPatients);
            surgeryGroup.MapGet("/patients{id}", GetPatientById);
            surgeryGroup.MapPost("/patients", CreatePatient);
            surgeryGroup.MapGet("/doctors", GetDoctors);
            surgeryGroup.MapGet("/doctors{id}", GetDoctorById);
            surgeryGroup.MapPost("/doctors", CreateDoctor);
            surgeryGroup.MapGet("/appointments", GetAppointments);
            surgeryGroup.MapGet("/appointments{doctorid, patientid}", GetAppointmentById);
            surgeryGroup.MapGet("/appointmentsbydoctor/{id}", GetAppointmentsByDoctorId);
            surgeryGroup.MapGet("/appointmentsbypasient/{id}", GetAppointmentsByPatientId);
            surgeryGroup.MapPost("/appointments", CreateAppointment);
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> GetPatients(IRepository repository)
        {
            var found = await repository.GetPatients();
            if (found != null)
            {
                GetPatientsResponse response = new GetPatientsResponse();
                foreach(var p in found)
                {
                    GetPatientDTO patient = new(p.FirstName, p.LastName); 
                    List<DTOPatientAppointment> patientAppointments = new List<DTOPatientAppointment>();
                    foreach (var appointments in p.Appointments)
                    {
                        patientAppointments.Add(new DTOPatientAppointment() { Booking = appointments.Booking, DoctorId = appointments.DoctorId });
                    }
                    patient.Appointments = patientAppointments;
                    response.Patients.Add(patient);
                }
                return TypedResults.Ok(response);
            }
            else
            {
                return TypedResults.NotFound("No patients found");
            }
        }
        
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> GetPatientById(IRepository repository, int id)
        {
            var found = await repository.GetPatientById(id);
            if (found != null)
            {
                GetPatientDTO patient = new(found.FirstName, found.LastName);
                List<DTOPatientAppointment> patientAppointments = new List<DTOPatientAppointment>();
                foreach(var appointments in found.Appointments)
                {
                    patientAppointments.Add(new DTOPatientAppointment() { Booking = appointments.Booking, DoctorId = appointments.DoctorId });
                }
                patient.Appointments = patientAppointments;
                return TypedResults.Ok(patient);
            }            
            else
            {
                return TypedResults.NotFound("Patient not found");
            }
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public static async Task<IResult> CreatePatient(IRepository repository, PatientPostModel model)
        {
            var newpatient = await repository.CreatePatient(new Models.Patient() { FirstName = model.FirstName, LastName = model.LastName });
            if (newpatient != null)
            {
                GetPatientDTO patient = new(newpatient.FirstName, newpatient.LastName);
                return TypedResults.Ok(patient);
            }
            else 
            {
                return TypedResults.BadRequest("Could not create patient");
            }
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> GetDoctors(IRepository repository)
        {
            var found = await repository.GetDoctors();
            if (found != null)
            {
                GetDoctorsResponse response = new GetDoctorsResponse();
                foreach (var d in found)
                {
                    GetDoctorDTO doctor = new(d.FirstName, d.LastName);
                    List<DTODoctorAppointment> doctorAppointments = new List<DTODoctorAppointment>();
                    foreach (var appointment in d.Appointments)
                    {
                        doctorAppointments.Add(new DTODoctorAppointment() { Booking=appointment.Booking, PatientId=appointment.PatientId });
                    }
                    doctor.Appointments = doctorAppointments;
                    response.Doctors.Add(doctor);
                }
                return TypedResults.Ok(response);
            }
            else
            {
                return TypedResults.NotFound("No doctors found");
            }
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> GetDoctorById(IRepository repository, int id)
        {
            var found = await repository.GetDoctorById(id);
            if (found != null)
            {
                GetDoctorDTO doctor = new (found.FirstName, found.LastName);
                List<DTODoctorAppointment> doctorAppointments = new List<DTODoctorAppointment>();
                foreach (var appointment in found.Appointments)
                {
                    doctorAppointments.Add(new DTODoctorAppointment() { Booking = appointment.Booking, PatientId = appointment.PatientId });
                }
                doctor.Appointments = doctorAppointments;
                return TypedResults.Ok(doctor);
            }
            else
            {
                return TypedResults.NotFound("No doctor found with that ID");
            }
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> CreateDoctor(IRepository repository, DoctorPostModel model)
        {
            var newDoctor = await repository.CreateDoctor(new Models.Doctor() { FirstName=model.FirstName, LastName=model.LastName });
            if (newDoctor != null)
            {
                GetDoctorDTO doctor = new (newDoctor.FirstName, newDoctor.LastName);
                return TypedResults.Ok(doctor);
            }
            else
            {
                return TypedResults.BadRequest("Could not create doctor");
            }
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> GetAppointments(IRepository repository)
        {
            var found = await repository.GetAppointments();
            if (found != null)
            {
                GetAppointmentsResponse response = new GetAppointmentsResponse();
                foreach (var a in found)
                {
                    var doctor = await repository.GetDoctorById(a.DoctorId);
                    GetDoctorDTO thisDoc = new(doctor.FirstName, doctor.LastName);

                    var patient = await repository.GetPatientById(a.PatientId);
                    GetPatientDTO thisPatient = new(patient.FirstName, patient.LastName);

                    GetAppointmentsDTO appointment = new GetAppointmentsDTO() { Booking=a.Booking, DoctorId=a.DoctorId, DoctorName=thisDoc.Name, PatientId=a.PatientId, Patientname=thisPatient.Name};
                    response.Appointments.Add(appointment);
                }
                return TypedResults.Ok(response);
            }
            else
            {
                return TypedResults.NotFound("No appointments found");
            }
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> GetAppointmentById(IRepository repository, int doctorid, int patientid)
        {
            var found = await repository.GetAppointmentById(doctorid, patientid);
            if (found != null)
            {
                var doctor = await repository.GetDoctorById(found.DoctorId);
                GetDoctorDTO thisDoc = new(doctor.FirstName, doctor.LastName);

                var patient = await repository.GetPatientById(found.PatientId);
                GetPatientDTO thisPatient = new(patient.FirstName, patient.LastName);

                GetAppointmentsDTO appointment = new GetAppointmentsDTO() { Booking = found.Booking, DoctorId = found.DoctorId, DoctorName = thisDoc.Name, PatientId = found.PatientId, Patientname = thisPatient.Name };
                return TypedResults.Ok(appointment);
            }
            else
            {
                return TypedResults.NotFound("No such appointment");
            }
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> GetAppointmentsByDoctorId(IRepository repository, int doctorid)
        {
            var found = await repository.GetAppointmentsByDoctorId(doctorid);
            if (found != null)
            {
                GetAppointmentsResponse response = new GetAppointmentsResponse();
                foreach (var a in found)
                {
                    var doctor = await repository.GetDoctorById(a.DoctorId);
                    GetDoctorDTO thisDoc = new(doctor.FirstName, doctor.LastName);

                    var patient = await repository.GetPatientById(a.PatientId);
                    GetPatientDTO thisPatient = new(patient.FirstName, patient.LastName);

                    GetAppointmentsDTO appointment = new GetAppointmentsDTO() { Booking = a.Booking, DoctorId = a.DoctorId, DoctorName = thisDoc.Name, PatientId = a.PatientId, Patientname = thisPatient.Name };
                    response.Appointments.Add(appointment);
                }

                return TypedResults.Ok(response);
            }
            else
            {
                return TypedResults.NotFound("No such appointment");
            }
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> GetAppointmentsByPatientId(IRepository repository, int patientid)
        {
            var found = await repository.GetAppointmentsByPatientId(patientid);
            if (found != null)
            {
                GetAppointmentsResponse response = new GetAppointmentsResponse();
                foreach (var a in found)
                {
                    var doctor = await repository.GetDoctorById(a.DoctorId);
                    GetDoctorDTO thisDoc = new(doctor.FirstName, doctor.LastName);

                    var patient = await repository.GetPatientById(a.PatientId);
                    GetPatientDTO thisPatient = new(patient.FirstName, patient.LastName);

                    GetAppointmentsDTO appointment = new GetAppointmentsDTO() { Booking = a.Booking, DoctorId = a.DoctorId, DoctorName = thisDoc.Name, PatientId = a.PatientId, Patientname = thisPatient.Name };
                    response.Appointments.Add(appointment);
                }

                return TypedResults.Ok(response);
            }
            else
            {
                return TypedResults.NotFound("No such appointment");
            }
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public static async Task<IResult> CreateAppointment(IRepository repository, AppointmentPostModel model)
        {
            var newAppointment = await repository.CreateAppointment(new Models.Appointment { Booking = model.Booking, DoctorId = model.DoctorId, PatientId = model.PatientId });
            if (newAppointment != null)
            {
                var doctor = await repository.GetDoctorById(newAppointment.DoctorId);
                if (doctor == null)
                {
                    return TypedResults.BadRequest("Cant make an appointment - That doctor does not exist");
                }

                GetDoctorDTO thisDoc = new(doctor.FirstName, doctor.LastName);

                var patient = await repository.GetPatientById(newAppointment.PatientId);

                if (patient == null)
                {
                    return TypedResults.BadRequest("Cant make an appointment - That person is not a patient here, please register patient first");
                }

                GetPatientDTO thisPatient = new(patient.FirstName, patient.LastName);

                GetAppointmentsDTO made = new GetAppointmentsDTO() { Booking = newAppointment.Booking, DoctorId = newAppointment.DoctorId, DoctorName = thisDoc.Name, PatientId = newAppointment.PatientId, Patientname = thisPatient.Name };

                return TypedResults.Ok(made);
            }
            else
            {
                return TypedResults.BadRequest("Could not create appointment");
            }
        }
    }
}
