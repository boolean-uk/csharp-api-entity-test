using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System.Diagnostics.Eventing.Reader;
using workshop.wwwapi.DTOs.AppointmentDTOs;
using workshop.wwwapi.DTOs.PatientDTOs;
using workshop.wwwapi.DTOs.Payload;
using workshop.wwwapi.Repository;

namespace workshop.wwwapi.Endpoints
{
    public static class SurgeryEndpoint
    {
        //TODO:  add additional endpoints in here according to the requirements in the README.md 
        public static void ConfigurePatientEndpoint(this WebApplication app)
        {
            var surgeryGroup = app.MapGroup("surgery");

            //Patient API
            surgeryGroup.MapGet("/patients", GetPatients);
            surgeryGroup.MapGet("/patient{id}", GetPatientById);
            surgeryGroup.MapPost("/patient", CreatePatient);
            //Doctor API
            surgeryGroup.MapGet("/doctors", GetDoctors);
            surgeryGroup.MapGet("/appointmentsbydoctor/{id}", GetAppointmentsByDoctor);
        }
        /*
         * PATIENT METHODS FROM HERE
         */
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetPatients(IRepository repository)
        { 
            var result = await repository.GetPatients();

            List<PatientDTO> patients = new List<PatientDTO>();

            foreach(var patient in result)
            {
                var patientDTO = new PatientDTO()
                {
                    Id = patient.Id,
                    FullName = patient.FullName,
                    Appointments = new List<AppointmentDoctorDTO>()
                };
                foreach(var appointment in  patient.Appointments)
                {
                    var appointmentDTO = new AppointmentDoctorDTO()
                    {
                        Booking = appointment.Booking,
                        DoctorId = appointment.DoctorId,
                        Doctor = new DTOs.DoctorDTOs.DoctorDTO()
                        {
                            FullName = appointment.Doctor.FullName,
                            Id = appointment.Doctor.Id
                        }
                    };
                    patientDTO.Appointments.Add(appointmentDTO);
                }
                patients.Add(patientDTO);
            }
            Payload<List<PatientDTO>> payload = new Payload<List<PatientDTO>>();
            payload.data = patients;
            return TypedResults.Ok(payload);

        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetPatientById(IRepository repository, int id)
        {
            var results = await repository.GetPatientById(id);

            PatientDTO patient = new PatientDTO()
            {
                Id = id,
                FullName = results.FullName,
                Appointments = new List<AppointmentDoctorDTO>()
            };
            foreach (var appointment in patient.Appointments)
            {
                var appointmentDTO = new AppointmentDoctorDTO()
                {
                    Booking = appointment.Booking,
                    DoctorId = appointment.DoctorId,
                    Doctor = new DTOs.DoctorDTOs.DoctorDTO()
                    {
                        FullName = appointment.Doctor.FullName,
                        Id = appointment.Doctor.Id
                    }
                };
                patient.Appointments.Add(appointmentDTO);
            };

            Payload<PatientDTO> payload = new Payload<PatientDTO>();
            payload.data = patient; 
            return TypedResults.Ok(payload);
        }


        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> CreatePatient(IRepository repository, string name)
        {
            var result = await repository.CreatePatient(name);

            PatientDTO resultPatient = new PatientDTO()
            {
                Id = result.Id,
                FullName = result.FullName
            };

            return result == null ? Results.BadRequest() : TypedResults.Created($"{resultPatient.FullName}", resultPatient);
        }

        /*
         * DOCTOR METHODS FROM HERE
         */
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
