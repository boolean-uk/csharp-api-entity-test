using AutoMapper;
using Microsoft.AspNetCore.Identity;
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
            surgeryGroup.MapGet("/doctors", GetDoctors);
            surgeryGroup.MapGet("/patients/{id}", GetPatientById);
            surgeryGroup.MapGet("/doctors/{id}", GetDoctorById);
            surgeryGroup.MapGet("appointments/", GetAppointments);
            surgeryGroup.MapGet("/appointmentsbydoctor/{id}", GetAppointmentsByDoctor);
            surgeryGroup.MapGet("/appointmentsbypatient/{id}", GetAppointmentsByPatient);
            surgeryGroup.MapGet("/appointmentsbyid/{id}", GetAppointmentById);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetPatients(IRepository repository, IMapper mapper)
        {
            try
            {
                var patients = await repository.GetPatients();

                var response = mapper.Map<List<PatientDTO>>(patients);

                return TypedResults.Ok(response);
            }
            catch (Exception ex)
            {
                return TypedResults.Problem(ex.Message);
            }
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> GetPatientById(IRepository repository, IMapper mapper, int id)
        {
            try
            {
                var patient = await repository.GetPatientById(id);

                if (patient == null)
                    return TypedResults.NotFound("Patient not found.");

                var response = mapper.Map<PatientDTO>(patient);

                return TypedResults.Ok(response);
            }
            catch (Exception ex)
            {
                return TypedResults.Problem(ex.Message);
            }
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetDoctors(IRepository repository, IMapper mapper)
        {
            try
            {
                var doctors = await repository.GetDoctors();

                var response = mapper.Map<List<DoctorDTO>>(doctors);

                return TypedResults.Ok(response);
            }
            catch (Exception ex)
            {
                return TypedResults.Problem(ex.Message);
            }
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> GetDoctorById(IRepository repository, IMapper mapper, int id)
        {
            try
            {
                var doctor = await repository.GetDoctorById(id);

                if (doctor == null)
                    return TypedResults.NotFound("Doctor not found.");

                var response = mapper.Map<DoctorDTO>(doctor);

                return TypedResults.Ok(response);
            }
            catch (Exception ex)
            {
                return TypedResults.Problem(ex.Message);
            }
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetAppointments(IRepository repository, IMapper mapper)
        {
            try
            {
                var appointments = await repository.GetAppointments();

                var response = mapper.Map<List<AppointmentDTO>>(appointments);

                return TypedResults.Ok(response);
            }
            catch (Exception ex)
            {
                return TypedResults.Problem(ex.Message);
            }
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> GetAppointmentById(IRepository repository, IMapper mapper, int doctorId, int patientId)
        {
            try
            {
                var appointment = await repository.GetAppointmentById(doctorId, patientId);

                if (appointment == null)
                    return TypedResults.NotFound("Appointment not found.");

                var response = mapper.Map<AppointmentDTO>(appointment);

                return TypedResults.Ok(response);
            }
            catch (Exception ex)
            {
                return TypedResults.Problem(ex.Message);
            }
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetAppointmentsByDoctor(IRepository repository, IMapper mapper, int id)
        {
            try
            {
                var appointments = await repository.GetAppointmentsByDoctor(id);

                if (appointments == null)
                    return TypedResults.NotFound("No appointments found.");

                var response = mapper.Map<List<AppointmentDTO>>(appointments);

                return TypedResults.Ok(response);
            }
            catch (Exception ex)
            {
                return TypedResults.Problem(ex.Message);
            }
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetAppointmentsByPatient(IRepository repository, IMapper mapper, int id)
        {
            try
            {
                var appointments = await repository.GetAppointmentsByPatient(id);

                if (appointments == null)
                    return TypedResults.NotFound("No appointments found.");

                var response = mapper.Map<List<AppointmentDTO>>(appointments);

                return TypedResults.Ok(response);
            }
            catch (Exception ex)
            {
                return TypedResults.Problem(ex.Message);
            }
        }
    }
}
