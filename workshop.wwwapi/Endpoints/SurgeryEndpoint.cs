using Microsoft.AspNetCore.Mvc;
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
            //surgeryGroup.MapGet("/doctors/{id}", GetDoctorById);
            //surgeryGroup.MapPost("/doctors", CreateDoctor);

            surgeryGroup.MapGet("/appointmentsbydoctor/{id}", GetAppointmentsByDoctor);
            //surgeryGroup.MapGet("/appointmentsbypatient/{id}", GetAppointmentsByPatient);
            //surgeryGroup.MapGet("/appointments/{id}", GetAppointmentById);
            //surgeryGroup.MapPost("/appointments", CreateAppointment);
        }

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

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetDoctors(IRepository repository)
        {
            return TypedResults.Ok(await repository.GetPatients());
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetAppointmentsByDoctor(IRepository repository, int id)
        {
            return TypedResults.Ok(await repository.GetAppointmentsByDoctor(id));
        }
    }
}
