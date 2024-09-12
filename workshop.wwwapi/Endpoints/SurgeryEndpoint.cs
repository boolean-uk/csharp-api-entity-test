using System.ComponentModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using workshop.wwwapi.DTOs;
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
            surgeryGroup.MapGet("/patients/{id}", GetPatientById);
            surgeryGroup.MapPost("/patients", AddPatient); 

            surgeryGroup.MapGet("/doctors", GetDoctors);
            surgeryGroup.MapGet("/doctors/{id}", GetDoctorById);
            surgeryGroup.MapPost("/doctors", AddDoctor);

            surgeryGroup.MapGet("/appointments", GetAppointments);
            surgeryGroup.MapGet("/appointments/{doctorId}/{patientId}", GetAppointmentsById);
            surgeryGroup.MapGet("/appointmentsbydoctor/{doctorId}", GetAppointmentsByDoctor);
            surgeryGroup.MapGet("/appointmentsbypatient/{patientId}", GetAppointmentsByPatient);
            surgeryGroup.MapPost("/appointments", AddAppointment);
        }



        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetPatients(IRepository repository)
        {
            GetAllResponse<DTOPatient> patientsResponse = new GetAllResponse<DTOPatient>();
            var patients = await repository.GetPatients();

            foreach (Patient patient in patients)
            {
                patientsResponse.Response.Add(_getDtoPatient(patient));
            }
            return TypedResults.Ok(patientsResponse);
        }

        [Route("patients/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> GetPatientById(int id, IRepository repotistory)
        {
            Patient patient = await repotistory.GetPatientById(id);

            if (patient != null)
            {
                return TypedResults.Ok(_getDtoPatient(patient));
            }
            return TypedResults.NotFound(new Message());
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public static async Task<IResult> AddPatient(IRepository repository, PersonPostModel model)
        {
            try
            {
                Patient patient = await repository.AddPatient(new Patient() { FullName = model.Name });

                return TypedResults.Created("", _getDtoPatient(patient));
            }
            catch (Exception ex)
            {
                return TypedResults.BadRequest(ex.Message);
            } 
        }




        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetDoctors(IRepository repository)
        {
            GetAllResponse<DTODoctor> doctorsResponse = new GetAllResponse<DTODoctor>();
            var doctors = await repository.GetDoctors();

            foreach (Doctor doctor in doctors)
            {
                doctorsResponse.Response.Add(_getDtoDoctor(doctor));
            }
            return TypedResults.Ok(doctorsResponse);
        }

        [Route("doctors/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> GetDoctorById(int id, IRepository repository)
        {
            Doctor doctor = await repository.GetDoctorById(id);

            if (doctor != null)
            {
                return TypedResults.Ok(_getDtoDoctor(doctor));
            }
            return TypedResults.NotFound(new Message());
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public static async Task<IResult> AddDoctor(IRepository repository, PersonPostModel model)
        {
            try
            {
                Doctor doctor = await repository.AddDoctor(new Doctor() { FullName = model.Name });

                return TypedResults.Created("", _getDtoDoctor(doctor));
            }
            catch (Exception ex)
            {
                return TypedResults.BadRequest(ex.Message);
            }
        }




        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetAppointments(IRepository repository)
        {
            GetAllResponse<DTOAppointment> appointmentsResponse = new GetAllResponse<DTOAppointment>();
            var appointments = await repository.GetAppointments();

            foreach (Appointment appointment in appointments)
            {
                appointmentsResponse.Response.Add(_getDtoAppointment(appointment));
            }
            return TypedResults.Ok(appointmentsResponse);
        }

        [Route("appointments{doctorId}/{patientId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> GetAppointmentsById(IRepository repository, int doctorId, int patientId)
        {
            Appointment appointment = await repository.GetAppointmentById(doctorId, patientId);

            if (appointment != null)
            {
                return TypedResults.Ok(_getDtoAppointment(appointment));
            }
            return TypedResults.NotFound(new Message());
        }

        [Route("appointmentsbydoctor/{doctorId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> GetAppointmentsByDoctor(IRepository repository, int doctorId)
        {
            if (await repository.GetDoctorById(doctorId) == null)
            {
                return TypedResults.NotFound(new Message() { Information = "Doctor does not exists in database" });
            }

            GetAllResponse<DTOAppointment> appointmentsResponse = new GetAllResponse<DTOAppointment>();
            var appointments = await repository.GetAppointmentsByDoctor(doctorId);

            foreach (Appointment appointment in appointments)
            {
                appointmentsResponse.Response.Add(_getDtoAppointment(appointment));
            }
            return TypedResults.Ok(appointmentsResponse);
        }

        [Route("appointmentsbypatient/{patientId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> GetAppointmentsByPatient(IRepository repository, int patientId)
        {
            if(await repository.GetPatientById(patientId) == null)
            {
                return TypedResults.NotFound(new Message() { Information = "Patient does not exists in database" });
            }

            GetAllResponse<DTOAppointment> appointmentsResponse = new GetAllResponse<DTOAppointment>();
            var appointments = await repository.GetAppointmentsByPatient(patientId);

            foreach (Appointment appointment in appointments)
            {
                appointmentsResponse.Response.Add(_getDtoAppointment(appointment));
            }
            return TypedResults.Ok(appointmentsResponse);
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public static async Task<IResult> AddAppointment(IRepository repository, AppointmentPostModel model)
        {
            try
            {
                if (await repository.GetPatientById(model.patientId) == null)
                {
                    return TypedResults.NotFound(new Message() { Information = "Patient does not exists in database" });
                }
                if (await repository.GetDoctorById(model.doctorId) == null)
                {
                    return TypedResults.NotFound(new Message() { Information = "Doctor does not exists in database" });
                }

                Appointment appointment = await repository.AddAppointment(new Appointment() { 
                    Booking = new DateTime(model.year, model.month, model.day, model.hour, model.minute, 0, DateTimeKind.Utc),
                    DoctorId = model.doctorId, 
                    PatientId = model.patientId 
                });

                return TypedResults.Created("", _getDtoAppointment(appointment));
            }
            catch (Exception ex)
            {
                return TypedResults.BadRequest(ex.Message);
            }
        }



        private static DTOPatient _getDtoPatient(Patient patient) 
        {
            DTOPatient dtoPatient = new DTOPatient() { ID = patient.Id, Name = patient.FullName };
            foreach (Appointment appointment in patient.Appointments)
            {
                DTODoctorWithoutAppointment dtoDoctor = new DTODoctorWithoutAppointment() { ID = appointment.DoctorId, Name = appointment.Doctor.FullName };
                DTOAppointmentWithoutPatient dtoAppointment = new DTOAppointmentWithoutPatient() { Booking = appointment.Booking.ToString("hh:mm dd.MM.yyyy"), Doctor = dtoDoctor };
                dtoPatient.Appointments.Add(dtoAppointment);
            }
            return dtoPatient;
        }
        private static DTODoctor _getDtoDoctor(Doctor doctor)
        {
            DTODoctor dtoDoctor = new DTODoctor() { ID = doctor.Id, Name = doctor.FullName };
            foreach (Appointment appointment in doctor.Appointments)
            {
                DTOPatientWithoutAppointment dtoPatient = new DTOPatientWithoutAppointment() { ID = appointment.PatientId, Name = appointment.Patient.FullName };
                DTOAppointmentWithoutDoctor dtoAppointment = new DTOAppointmentWithoutDoctor() { Booking = appointment.Booking.ToString("hh:mm dd.MM.yyyy"), Patient = dtoPatient };
                dtoDoctor.Appointments.Add(dtoAppointment);
            }
            return dtoDoctor;
        }

        private static DTOAppointment _getDtoAppointment(Appointment appointment)
        {
            DTOPatientWithoutAppointment dtoPatient = new DTOPatientWithoutAppointment() { ID = appointment.PatientId, Name = appointment.Patient.FullName };
            DTODoctorWithoutAppointment dtoDoctor = new DTODoctorWithoutAppointment() { ID = appointment.DoctorId, Name = appointment.Doctor.FullName };
            
            return new DTOAppointment { Booking = appointment.Booking.ToString("hh:mm dd.MM.yyyy"), Doctor = dtoDoctor, Patient = dtoPatient};
        }
    }
}
