using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using System.Text.RegularExpressions;
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
            surgeryGroup.MapGet("/patients/{id}", GetPatientById);
            surgeryGroup.MapPost("/patients", CreatePatient);

            surgeryGroup.MapGet("/doctors", GetDoctors);
            surgeryGroup.MapGet("/doctors/{id}", GetDoctorById);
            surgeryGroup.MapPost("/doctors", CreateDoctor);

            surgeryGroup.MapGet("/appointmentsbydoctor/{id}", GetAppointmentsByDoctor);
            surgeryGroup.MapGet("/appointmentsbypatient/{id}", GetAppointmentsByPatient);
            surgeryGroup.MapGet("/appointments/{id}", GetAppointmentById);
            surgeryGroup.MapPost("/appointments", CreateAppointment);
        }

        // Patients
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public static async Task<IResult> GetPatients(IRepository repository)
        {
            var results = await repository.GetPatients();
            List<Patient> patients = results.ToList();
            if (patients.Count <= 0)
            {
                return TypedResults.NoContent();
            }

            List<ResponsePatientDTO> responsePatients = new List<ResponsePatientDTO>();

            foreach (Patient p in patients)
            {
                responsePatients.Add(CreateResponsePatientDTO(p));
            }

            return TypedResults.Ok(responsePatients);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> GetPatientById(IRepository repository, int id)
        {
            try
            {
                var result = await repository.GetPatientById(id);
                if (result is null)
                {
                    return TypedResults.NotFound("Patient Not Found");
                }

                ResponsePatientDTO responsePatient = CreateResponsePatientDTO(result);

                return TypedResults.Ok(responsePatient);
            }
            catch (Exception ex)
            {
                return TypedResults.Problem(ex.ToString());
            }
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public static async Task<IResult> CreatePatient(IRepository repository, PostPatientDTO model)
        {
            try
            {
                if (model == null)
                {
                    return TypedResults.BadRequest($"Invalid patient object");
                }

                if (String.IsNullOrEmpty(model.FullName))
                {
                    return TypedResults.BadRequest($"No patient name given");
                }

                var newPatient = await repository.CreatePatient(new Patient { FullName = model.FullName });
                ResponsePatientDTO responsePatient = CreateResponsePatientDTO(newPatient);
                
                return TypedResults.Created($"https://localhost:7054/patients/{responsePatient.Id}", responsePatient);
            }
            catch (Exception ex)
            {
                return TypedResults.BadRequest($"Invalid patient object - {ex}");
            }
        }

        public static ResponsePatientDTO CreateResponsePatientDTO(Patient patient)
        {
            ResponsePatientDTO responsePatient = new ResponsePatientDTO();
            responsePatient.Id = patient.Id;
            responsePatient.FullName = patient.FullName;

            foreach (Appointment a in patient.Appointments)
            {
                ResponseDoctorAppointmentDTO responseDoctorAppointment = new ResponseDoctorAppointmentDTO();
                responseDoctorAppointment.Booking = a.Booking;
                responseDoctorAppointment.DoctorId = a.DoctorId;
                responseDoctorAppointment.DoctorFullName = a.Doctor.FullName;
                responsePatient.Appointments.Add(responseDoctorAppointment);
            }

            return responsePatient;
        }

        // Doctors
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public static async Task<IResult> GetDoctors(IRepository repository)
        {
            var results = await repository.GetDoctors();
            List<Doctor> doctors = results.ToList();
            if (doctors.Count <= 0)
            {
                return TypedResults.NoContent();
            }

            List<ResponseDoctorDTO> responseDoctors = new List<ResponseDoctorDTO>();

            foreach (Doctor d in doctors)
            {
                responseDoctors.Add(CreateResponseDoctorDTO(d));
            }

            return TypedResults.Ok(responseDoctors);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> GetDoctorById(IRepository repository, int id)
        {
            try
            {
                var result = await repository.GetDoctorById(id);
                if (result is null)
                {
                    return TypedResults.NotFound("Doctor Not Found");
                }

                ResponseDoctorDTO responseDoctor = CreateResponseDoctorDTO(result);

                return TypedResults.Ok(responseDoctor);
            }
            catch (Exception ex)
            {
                return TypedResults.Problem(ex.ToString());
            }
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public static async Task<IResult> CreateDoctor(IRepository repository, PostDoctorDTO model)
        {
            try
            {
                if (model == null)
                {
                    return TypedResults.BadRequest($"Invalid doctor object");
                }

                if (String.IsNullOrEmpty(model.FullName))
                {
                    return TypedResults.BadRequest($"No doctor name given");
                }

                var newDoctor = await repository.CreateDoctor(new Doctor { FullName = model.FullName });
                ResponseDoctorDTO responseDoctor = CreateResponseDoctorDTO(newDoctor);

                return TypedResults.Created($"https://localhost:7054/doctors/{responseDoctor.Id}", responseDoctor);
            }
            catch (Exception ex)
            {
                return TypedResults.BadRequest($"Invalid doctor object - {ex}");
            }
        }

        public static ResponseDoctorDTO CreateResponseDoctorDTO(Doctor doctor)
        {
            ResponseDoctorDTO responseDoctor = new ResponseDoctorDTO();
            responseDoctor.Id = doctor.Id;
            responseDoctor.FullName = doctor.FullName;

            foreach (Appointment a in doctor.Appointments)
            {
                ResponsePatientAppointmentDTO responsePatientAppointment = new ResponsePatientAppointmentDTO();
                responsePatientAppointment.Booking = a.Booking;
                responsePatientAppointment.PatientId = a.PatientId;
                responsePatientAppointment.PatientFullName = a.Patient.FullName;
                responseDoctor.Appointments.Add(responsePatientAppointment);
            }

            return responseDoctor;
        }


        // Appointment
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> GetAppointmentsByDoctor(IRepository repository, int id)
        {
            var results = await repository.GetAppointmentsByDoctor(id);
            List<Appointment> appointments = results.ToList();
            if (appointments.Count <= 0)
            {
                return TypedResults.NotFound("Doctor has no appointments");
            }

            List<ResponseAppointmentDTO> responseAppointments = new List<ResponseAppointmentDTO>();

            foreach (Appointment a in appointments)
            {
                responseAppointments.Add(CreateResponseAppointmentDTO(a));
            }

            return TypedResults.Ok(responseAppointments);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> GetAppointmentsByPatient(IRepository repository, int id)
        {
            var results = await repository.GetAppointmentsByPatient(id);
            List<Appointment> appointments = results.ToList();
            if (appointments.Count <= 0)
            {
                return TypedResults.NotFound("Patient has no appointments");
            }

            List<ResponseAppointmentDTO> responseAppointments = new List<ResponseAppointmentDTO>();

            foreach (Appointment a in appointments)
            {
                responseAppointments.Add(CreateResponseAppointmentDTO(a));
            }

            return TypedResults.Ok(responseAppointments);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> GetAppointmentById(IRepository repository, string bookingTime, int doctorId, int patientId)
        {
            try
            {
                bool dateSuccess = DateTime.TryParse(bookingTime, CultureInfo.InvariantCulture, DateTimeStyles.AdjustToUniversal, out var booking);
                if (dateSuccess == false)
                {
                    return TypedResults.BadRequest("Invalid booking time format - it needs to be in the format of yyyy-mm-ddThh:mm:ss.000000Z");
                }

                var doctorResult = await repository.GetDoctorById(doctorId);
                if (doctorResult is null)
                {
                    return TypedResults.NotFound("Doctor Not Found");
                }

                var patientResult = await repository.GetPatientById(patientId);
                if (patientResult is null)
                {
                    return TypedResults.NotFound("Patient Not Found");
                }

                var result = await repository.GetAppointmentById(booking, doctorId, patientId);

                if (result is null)
                {
                    return TypedResults.NotFound("Appointment not found");
                }

                ResponseAppointmentDTO responseAppointment = CreateResponseAppointmentDTO(result);

                return TypedResults.Ok(responseAppointment);
            }
            catch (Exception ex)
            {
                return TypedResults.Problem(ex.ToString());
            }
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public static async Task<IResult> CreateAppointment(IRepository repository, PostAppointmentDTO model)
        {
            try
            {
                if (model == null)
                {
                    return TypedResults.BadRequest($"Invalid appointment object");
                }

                bool dateSuccess = DateTime.TryParse(model.Booking, CultureInfo.InvariantCulture, DateTimeStyles.AdjustToUniversal, out var booking);
                if (dateSuccess == false)
                {
                    return TypedResults.BadRequest("Invalid booking time format - it needs to be in the format of yyyy-mm-ddThh:mm:ss.000000Z");
                }

                var doctorResult = await repository.GetDoctorById(model.DoctorId);
                if (doctorResult is null)
                {
                    return TypedResults.NotFound("Doctor Not Found");
                }

                var patientResult = await repository.GetPatientById(model.PatientId);
                if (patientResult is null)
                {
                    return TypedResults.NotFound("Patient Not Found");
                }

                var newAppointment = await repository.CreateAppointment(new Appointment() { 
                    Booking=booking, 
                    DoctorId=model.DoctorId,
                    Doctor=doctorResult,
                    PatientId=model.PatientId,
                    Patient=patientResult
                });

                ResponseAppointmentDTO responseAppointment = CreateResponseAppointmentDTO(newAppointment);

                return TypedResults.Created($"https://localhost:7054/appointments/{responseAppointment.Booking}&{responseAppointment.DoctorId}&{responseAppointment.PatientId}", responseAppointment);
            }
            catch (Exception ex)
            {
                return TypedResults.BadRequest($"Invalid appointment object - {ex}");
            }
        }

        public static ResponseAppointmentDTO CreateResponseAppointmentDTO(Appointment appointment)
        {
            ResponseAppointmentDTO responseAppointment = new ResponseAppointmentDTO();
            responseAppointment.Booking = appointment.Booking;
            responseAppointment.DoctorId = appointment.DoctorId;
            responseAppointment.DoctorFullName = appointment.Doctor.FullName;
            responseAppointment.PatientId = appointment.PatientId;
            responseAppointment.PatientFullName = appointment.Patient.FullName;
            return responseAppointment;
        }
    }
}
