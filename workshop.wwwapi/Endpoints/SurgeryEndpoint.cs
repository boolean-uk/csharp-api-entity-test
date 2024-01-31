using Microsoft.AspNetCore.Mvc;
using workshop.wwwapi.Repository;
using workshop.wwwapi.Models;
using SurgeryEndpoints.DTOs;
using System.Numerics;
using workshop.wwwapi.DTOs;

namespace workshop.wwwapi.Endpoints
{
    public static class SurgeryEndpoint
    {
        //TODO:  add additional endpoints in here according to the requirements in the README.md 
        public static void ConfigurePatientEndpoint(this WebApplication app)
        {
            var surgeryGroup = app.MapGroup("surgery");

            surgeryGroup.MapGet("/patients", GetPatients);
            surgeryGroup.MapGet("/patients/{id}", GetAPatient);
            surgeryGroup.MapPost("/patients/{id}", CreatePatient);
            surgeryGroup.MapGet("/doctors", GetDoctors);
            surgeryGroup.MapGet("/doctors/{Id}", GetADoctor);
            surgeryGroup.MapPost("/doctors/{Id}", CreateDoctor);
            surgeryGroup.MapGet("/appointmentsbydoctor/{id}", GetAppointmentsByDoctor);
            surgeryGroup.MapGet("/appointmentsbyPatient/{id}", GetAppointmentsByPatient);
            surgeryGroup.MapGet("/appointment", GetAppointments);
            surgeryGroup.MapPost("/appointment", AddAppointment);
        }


        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetPatients(IRepository repository)
        {
            var patients = await repository.GetPatients();
            var patientDto = new List<PatientResponseDTO>();
            foreach (Patient patient in patients)
            {
                patientDto.Add(new PatientResponseDTO(patient));
            }
            return TypedResults.Ok(patientDto);
        }


        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(IResult))]
        private static async Task<IResult> GetAPatient(int patientid, IRepository repository)
        {
            var patient = await repository.GetPatient(patientid);

            if (patient == null)
            {
                return TypedResults.NotFound();
            }

            return TypedResults.Ok(new PatientResponseDTO(patient));
        }



        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public static async Task<IResult> CreatePatient(CreatePatientPayload payload, IRepository repository)
        {
            // validate: a) payload has all of the properties we need (ie. they are NOT null)
            if (payload.Name == null || payload.Name == "")
            {
                return Results.BadRequest("A non-empty Name is required");
            }
            // validate: b) payload properties have acceptable values (ie. not empty, or within required ranges, etc...)

            Patient? patient = new Patient { FullName = payload.Name };
                
            var newpatient = await repository.CreatePatient(patient);
            if (newpatient == null)
            {
                return Results.BadRequest("Failed to create patient.");
            }

            return TypedResults.Ok(new PatientResponseDTO(newpatient));
        }
        

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetDoctors(IRepository repository)
        {
            var doctors = await repository.GetDoctors();
            var doctorDto = new List<DoctorResponseDTO>();
            foreach (Doctor doctor in doctors)
            {
                doctorDto.Add(new DoctorResponseDTO(doctor));
            }
            return TypedResults.Ok(doctorDto);
        }


        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(IResult))]
        private static async Task<IResult> GetADoctor(int doctorid, IRepository repository)
        {
            var doctor = await repository.GetDoctor(doctorid);

            if (doctor == null)
            {
                return TypedResults.NotFound();
            }

            return TypedResults.Ok(new DoctorResponseDTO(doctor));
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public static async Task<IResult> CreateDoctor(CreateDoctorPayload payload, IRepository repository)
        {
            // validate: a) payload has all of the properties we need (ie. they are NOT null)
            if (payload.Name == null || payload.Name == "")
            {
                return Results.BadRequest("A non-empty Name is required");
            }
            // validate: b) payload properties have acceptable values (ie. not empty, or within required ranges, etc...)

            Doctor? doctor = new Doctor { FullName = payload.Name };

            var newDoctor = await repository.CreateDoctor(doctor);
            if (newDoctor == null)
            {
                return Results.BadRequest("Failed to create doctor.");
            }

            return TypedResults.Ok(new DoctorResponseDTO(newDoctor));
        }


        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetAppointmentsByDoctor(IRepository repository, int doctorId)
        {
            var appointments = await repository.GetAppointmentsByDoctor(doctorId);
            var appointmentDto = new List<AppointmentDTO>();
            foreach (Appointment appointment in appointments)
            {
                appointmentDto.Add(new AppointmentDTO(appointment));
            }
            return TypedResults.Ok(appointmentDto);
        }




        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetAppointmentsByPatient(IRepository repository, int patientId)
        {
            var appointments = await repository.GetAppointmentsByPatient(patientId);
            var appointmentDto = new List<AppointmentDTO>();
            foreach (Appointment appointment in appointments)
            {
                appointmentDto.Add(new AppointmentDTO(appointment));
            }
            return TypedResults.Ok(appointmentDto);
        }



        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public static async Task<IResult> AddAppointment(CreateAppointmentPayload payload, IRepository repository)
        {
            // a) check for null properties on my payload => return bad request if missing fields
            if (payload.patientId == null || payload.doctorId == null || payload.Booking == null)
            {
                return Results.BadRequest("All fields pateintID, doctorID and Booking are required");
            }

            // b) try to get student; return not found if null
            Patient? patient = await repository.GetPatient(payload.patientId);
            if (patient == null)
            {
                return Results.NotFound("Patient not found");
            }
            // c) try to get course; return not found if null
            Doctor? doctor = await repository.GetDoctor(payload.doctorId);
            if (doctor == null)
            {
                return Results.NotFound("Doctor not found");
            }
            /*
            // d) check academic year is within reasonable range of years
            if (payload.Booking < DateTime.Now.Year - 1 || payload.Booking > DateTime.Now.Year + 5)
            {
                return Results.BadRequest("Academic year must be -1 / +5 relative to current year.");
            }
            */
            Appointment? appointment = await repository.CreateAppointment(payload.Booking, patient, doctor);
            if (appointment == null)
            {
                return Results.BadRequest("Failed to create appointment; check if patient and doctor exist and Booking is valid.");
            }
           
            return TypedResults.Ok(new AppointmentDTO(appointment));

        }

      


        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetAppointments(IRepository repository)
        {
            var appointments = await repository.GetAppointments();
            var appointmentDto = new List<AppointmentDTO>();
            foreach (Appointment appointment in appointments)
            {
                appointmentDto.Add(new AppointmentDTO(appointment));
            }
            return TypedResults.Ok(appointmentDto);
        }
    }
}
