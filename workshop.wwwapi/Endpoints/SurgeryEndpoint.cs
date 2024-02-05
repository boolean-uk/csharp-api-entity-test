using Microsoft.AspNetCore.Mvc;
using workshop.wwwapi.Data;
using workshop.wwwapi.DTOs;
using workshop.wwwapi.Models;
using workshop.wwwapi.Repository;

namespace workshop.wwwapi.Endpoints
{
    public static class SurgeryEndpoint
    {
        //TODO:  add additional endpoints in here according to the requirements in the README.md 
        public static void ConfigureSurgeryEndpoint(this WebApplication app)
        {
            var surgeryGroup = app.MapGroup("surgery");

            surgeryGroup.MapGet("/patients", GetPatients);
            surgeryGroup.MapGet("/patients/{id}", GetPatientById);
            surgeryGroup.MapPost("/patients", CreatePatient);

            surgeryGroup.MapGet("/doctors", GetDoctors);
            surgeryGroup.MapGet("/doctors/{id}", GetDoctorById);
            surgeryGroup.MapPost("/doctors", CreateDoctor);

            surgeryGroup.MapGet("/appointments", GetAppointments);
            surgeryGroup.MapGet("/appointmentsbydoctor/{id}", GetAppointmentsByDoctor);
            surgeryGroup.MapGet("/appointmentsbypatient/{id}", GetAppointmentsByPatient);
            surgeryGroup.MapPost("/appointments", CreateAppointment);
        }

        //PATIENTS
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetPatients(IRepository repository)
        {
            var patientClasses = await repository.GetPatients();
            List<PatientDTO> patientDTOs = new List<PatientDTO>();

            foreach (var patient in patientClasses)
            {
                var patientDTO = new PatientDTO
                {
                    Id = patient.Id,
                    FullName = patient.FullName
                };
                patientDTOs.Add(patientDTO);
            }

            return TypedResults.Ok(patientDTOs);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetPatientById(IRepository repository, int id)
        {
            var patientClass = await repository.GetPatientById(id);

            if (patientClass == null)
            {
                return TypedResults.NotFound("Patient not found");
            }

            var patientDTO = new PatientDTO
            {
                Id = patientClass.Id,
                FullName = patientClass.FullName
            };

            return TypedResults.Ok(patientDTO);
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        public static async Task<IResult> CreatePatient(IRepository repository, PatientPost model)
        {
            if (!NameHelper.NameCheck(model.FullName))
            {
                return TypedResults.BadRequest("Please write name correctly");
            }

            var patient = await repository.CreatePatient(model);
            return TypedResults.Created($"/{patient.Id}", patient);
        }


        //DOCTORS
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetDoctors(IRepository repository)
        {
            var doctorClasses = await repository.GetDoctors();
            List<DoctorDTO> doctorDTOs = new List<DoctorDTO>();

            foreach (var doctor in doctorClasses)
            {
                var doctorDTO = new DoctorDTO
                {
                    Id = doctor.Id,
                    FullName = doctor.FullName
                };
                doctorDTOs.Add(doctorDTO);
            }

            return TypedResults.Ok(doctorDTOs);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetDoctorById(IRepository repository, int id)
        {
            var doctorClass = await repository.GetDoctorById(id);

            if (doctorClass == null)
            {
                return TypedResults.NotFound("Doctor not found");
            }

            var doctorDTO = new DoctorDTO
            {
                Id = doctorClass.Id,
                FullName = doctorClass.FullName
            };

            return TypedResults.Ok(doctorDTO);
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        public static async Task<IResult> CreateDoctor(IRepository repository, DoctorPost model)
        {
            if (!NameHelper.NameCheck(model.FullName))
            {
                return TypedResults.BadRequest("Please write name correctly");
            }

            var doctor = await repository.CreateDoctor(model);
            return TypedResults.Created($"/{doctor.Id}", doctor);
        }


        //APPOINTMENTS

        //Method reduce code duplication.
        public static List<AppointmentDTO> AppointmentDTOListReturner(IEnumerable<Appointment> appointments)
        {
            List<AppointmentDTO> appointmentDTOs = new List<AppointmentDTO>();

            foreach (var appointment in appointments)
            {
                AppointmentDTO appointmentDTO = new AppointmentDTO
                {
                    Id = appointment.Id,
                    DoctorId = appointment.DoctorId,
                    Doctor = new DoctorDTO
                    {
                        Id = appointment.Doctor.Id,
                        FullName = appointment.Doctor.FullName
                    },
                    PatientId = appointment.PatientId,
                    Patient = new PatientDTO
                    {
                        Id = appointment.Patient.Id,
                        FullName = appointment.Patient.FullName
                    },
                    Booking = appointment.Booking
                };
                appointmentDTOs.Add(appointmentDTO);
            }

            return appointmentDTOs;
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetAppointments(IRepository repository)
        {
            var appointments = await repository.GetAppointments();
            var appointmentDTOs = AppointmentDTOListReturner(appointments);

            if (appointmentDTOs.Count == 0)
            {
                return TypedResults.NotFound("No appointments found");
            }
            return TypedResults.Ok(appointmentDTOs);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetAppointmentsByDoctor(IRepository repository, int docId)
        {
            var appointments = await repository.GetAppointmentsByDoctor(docId);
            var appointmentDTOs = AppointmentDTOListReturner(appointments);

            if (appointmentDTOs.Count == 0)
            {
                return TypedResults.NotFound("No appointments found");
            }
            return TypedResults.Ok(appointmentDTOs);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetAppointmentsByPatient(IRepository repository, int patId)
        {
            var appointments = await repository.GetAppointmentsByPatient(patId);
            var appointmentDTOs = AppointmentDTOListReturner(appointments);

            if (appointmentDTOs.Count == 0)
            {
                return TypedResults.NotFound("No appointments found");
            }
            return TypedResults.Ok(appointmentDTOs);
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        public static async Task<IResult> CreateAppointment(IRepository repository, AppointmentPost model)
        {
            var patient = await repository.GetPatientById(model.PatientId);
            if (patient == null)
            {
                return TypedResults.NotFound("Patient does not exist");
            }

            var doctor = await repository.GetDoctorById(model.DoctorId);
            if (doctor == null)
            {
                return TypedResults.NotFound("Doctor does not exist");
            }

            var appointmentClass = await repository.CreateAppointment(model);

            var apointmentDTO = new AppointmentDTO
            {
                Id = appointmentClass.Id,
                DoctorId = appointmentClass.DoctorId,
                Doctor = new DoctorDTO
                {
                    Id = appointmentClass.Doctor.Id,
                    FullName = appointmentClass.Doctor.FullName
                },
                PatientId = appointmentClass.PatientId,
                Patient = new PatientDTO
                {
                    Id = appointmentClass.Patient.Id,
                    FullName = appointmentClass.Patient.FullName
                },
                Booking = appointmentClass.Booking
            };
            return TypedResults.Created($"/{apointmentDTO.Id}", apointmentDTO);
        }
    }
}
