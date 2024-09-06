using Microsoft.AspNetCore.Http.HttpResults;
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
            surgeryGroup.MapGet("/patient/{id}", getPatient);
            surgeryGroup.MapPost("/patients/create", createPatient);
            surgeryGroup.MapGet("/doctors", GetDoctors);
            surgeryGroup.MapGet("/doctors/{id}", getDoctor);
            surgeryGroup.MapPost("/doctors/create", createDoctor);
            surgeryGroup.MapGet("/appointments", GetAppointments);
            surgeryGroup.MapGet("/appointmentsbydoctor/{id}", GetAppointmentsByDoctor);
            surgeryGroup.MapGet("/appointmentsbypatient/{id}", GetAppointmentsByPatient);
            surgeryGroup.MapPost("/appointments/create{patientId}/{doctorId}", createAppointment);
        }



        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> createPatient(IRepository<Patient> repository, CreatePatientDTO patientDTO)
        {
            var patient = new Patient { FullName = patientDTO.fullName, Id = patientDTO.Id };

            if (patient == null)
            {
                return TypedResults.NotFound(); ;
            }

            repository.Add(patient);
            return TypedResults.Created();
        }



        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetPatients(IRepository<Patient> repository)
        { 
            var list  = await repository.GetAll();
            var patientDTOs = list.Select(p => new PatientDTO
            {
                Id = p.Id,
                fullName = p.FullName
            }).ToList();

            return TypedResults.Ok(patientDTOs);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> getPatient(IAppointmentRepository AppointmentRepo,IRepository<Patient> repository, int patientId)
        {
            var patient = await repository.GetOne(patientId);
            var appointments = await AppointmentRepo.getAppointmentByPatient(patientId);
            var doctorAppointmentDTOs = appointments.Select(a => new DoctorAppointmentDTO
            {
                appointmentDate = a.Booking,
                doctorName = a.doctor.FullName,
                doctorId = a.doctor.Id,
            });
            var patientDTO = new PatientDTO
            {
                Id = patient.Id,
                fullName = patient.FullName,
                appointments = doctorAppointmentDTOs.ToList()
                
            };

            return TypedResults.Ok(patientDTO);
        }



        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetDoctors(IRepository<Doctor> repository)
        {
            var list = await repository.GetAll();
            var doctorDTOs = list.Select(p => new DoctorDTO
            {
                id = p.Id,
                fullName = p.FullName
            }).ToList();

            return TypedResults.Ok(doctorDTOs);
        }


        public static async Task<IResult> getDoctor(IAppointmentRepository AppointmentRepo, IRepository<Patient> repository, int doctorId)
        {
            var doctor = await repository.GetOne(doctorId);
            var appointments = await AppointmentRepo.getAppointmentByDoctor(doctorId);
            var patientAppointmentDTOs = appointments.Select(a => new PatientAppointmentDTO
            {
                appointmentDate = a.Booking,
                patientFullName = a.patient.FullName,
                patientId = a.patient.Id,
            });
            var DoctorDTO = new DoctorDTO
            {
                id = doctor.Id,
                fullName = doctor.FullName,
                appointments = patientAppointmentDTOs.ToList()

            };

            return TypedResults.Ok(DoctorDTO);
        }


        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> createDoctor(IRepository<Doctor> repository, CreateDoctorDTO doctorDTO)
        {
            var doctor = new Doctor { FullName = doctorDTO.fullName, Id = doctorDTO.Id };

            if (doctor == null)
            {
                return TypedResults.NotFound(); ;
            }

            repository.Add(doctor);
            return TypedResults.Created();
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetAppointments(IRepository<Appointment> repository)
        {
            var appointments = await repository.GetAll();
            if(appointments == null)
            {

               return TypedResults.NotFound();
            }
            var appointmentDTOS = appointments.Select(p => new GetAppointmentDTO
            {
                doctorId = p.doctor.Id,
                doctorName = p.doctor.FullName,
                patientId = p.patient.Id,
                patientFullName = p.patient.FullName
            }).ToList();

            return TypedResults.Ok(appointmentDTOS);
        }


        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetAppointmentsByDoctor(IAppointmentRepository repository, int doctorId)
        {
            var appointments = await repository.getAppointmentByDoctor(doctorId);
            var appointmentDTOs = appointments.Select(p => new GetAppointmentDTO
            {
                doctorId = p.doctor.Id,
                doctorName = p.doctor.FullName,
                patientId = p.patient.Id,
                patientFullName = p.patient.FullName
            }).ToList();

            return TypedResults.Ok(appointmentDTOs);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetAppointmentsByPatient(IAppointmentRepository repository, int patientId)
        {
            var appointments = await repository.getAppointmentByPatient(patientId);
            var appointmentDTOs = appointments.Select(p => new GetAppointmentDTO
            {
                doctorId = p.doctor.Id,
                doctorName = p.doctor.FullName,
                patientId = p.patient.Id,
                patientFullName = p.patient.FullName
            }).ToList();

            return TypedResults.Ok(appointmentDTOs);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> createAppointment(IRepository<Appointment> Generic,IAppointmentRepository repository, int patientId, int doctorId)
        {
            var appointment  = new Appointment() { Booking = DateTime.UtcNow, DoctorId = doctorId, PatientId = patientId };    

            if (appointment == null)
            {
                return TypedResults.NotFound(); ;
            }

            Generic.Add(appointment);
            return TypedResults.Created();
        }

    }
}
