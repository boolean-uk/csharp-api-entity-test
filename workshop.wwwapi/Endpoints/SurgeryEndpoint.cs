using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Any;
using System.Net.NetworkInformation;
using workshop.wwwapi.Models;
using workshop.wwwapi.Models.DatabaseModels;
using workshop.wwwapi.Models.GenericDto;
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
            surgeryGroup.MapGet("/doctors", GetDoctors);
            surgeryGroup.MapGet("/doctors/{id}", GetDoctorById);
            surgeryGroup.MapPost("/doctors", CreateDoctor);
            surgeryGroup.MapGet("/appointments", GetAppointments);
            surgeryGroup.MapGet("/appointmentsbydoctors/{doctorid}", GetAppointmentsByDoctorId);
            surgeryGroup.MapGet("/appointmentsbypatients/{patientid}", GetAppointmentsByPatientId);
            surgeryGroup.MapGet("/perscriptions", GetPerscriptions);
            surgeryGroup.MapGet("/perscriptions/{id}", GetPerscriptionById);
            surgeryGroup.MapPost("/Perscriptions", CreatePerscription);

        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetPatients(IRepository repository)
        {
            var entities = await repository.GetPatients();
            await repository.GetDoctors();

            List<PatientDto> patients = new List<PatientDto>();

            foreach(var entity in entities)
            {
                var patient = new PatientDto()
                {
                    Id = entity.Id,
                    FullName = entity.FullName,
                    Appointments = entity.Appointments.Select(x => new DoctorAppointmentDto()
                    {
                        Booking = x.Booking,
                        DoctorId = x.DoctorId,
                        DoctorName = x.Doctor.FullName,
                        

                    }).ToList(),
                };
                patients.Add(patient);
            }

            Payload<List<PatientDto>> result = new Payload<List<PatientDto>>();
            result.data = patients;

            return TypedResults.Ok(result);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> GetPatientById(IRepository repository, int id)
        {

            var entities = await repository.GetPatients();
            await repository.GetDoctors();

            if (!entities.Any(x => x.Id == id))
            {
                return TypedResults.NotFound("Patient was not found");
            }

            var entity = await repository.GetPatientById(id);

            PatientDto patient = new PatientDto()
            {
                Id = entity.Id,
                FullName = entity.FullName,
                Appointments = entity.Appointments.Select(x => new DoctorAppointmentDto()
                {
                    Booking = x.Booking,
                    DoctorId = x.DoctorId,
                    DoctorName = x.Doctor.FullName,
                }).ToList(),
            };

            Payload<PatientDto> result = new Payload<PatientDto>();
            result.data = patient;

            return TypedResults.Ok(result);


        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetDoctors(IRepository repository)
        {
            var entities = await repository.GetDoctors();
            await repository.GetPatients();

            List<DoctorDto> doctors = new List<DoctorDto>();

            foreach(var entity in entities)
            {
                var doctor = new DoctorDto()
                {
                    Id = entity.Id,
                    FullName = entity.FullName,
                    Appointments = entity.Appointments.Select(x => new PatientAppointmentDto()
                    {
                        Booking = x.Booking,
                        PatientId = x.PatientId,
                        PatientName = x.Patient.FullName,

                    }).ToList(),
                };
                doctors.Add(doctor);
            }

            Payload<List<DoctorDto>> result = new Payload<List<DoctorDto>>();
            result.data = doctors;

            return TypedResults.Ok(result);


        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> GetDoctorById(IRepository repository, int id)
        {
            var entities = await repository.GetDoctors();
            await repository.GetPatients();

            if (!entities.Any(x => x.Id == id))
            {
                return TypedResults.NotFound("Doctor was not found");
            }

            var entity = await repository.GetDoctorById(id);
            var doctor = new DoctorDto()
            {
                Id = entity.Id,
                FullName = entity.FullName,
                Appointments = entity.Appointments.Select(x => new PatientAppointmentDto()
                    {
                        Booking = x.Booking,
                        PatientId = x.PatientId,
                        PatientName = x.Patient.FullName,

                }).ToList(),
            };

            Payload<DoctorDto> result = new Payload<DoctorDto>();
            result.data = doctor;

            return TypedResults.Ok(result);
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public static async Task<IResult> CreateDoctor(IRepository repository, DoctorCreateDto doctor)
        {
            var doctorEntries = await repository.GetDoctors();

            if(doctorEntries.Any(d => d.Id == doctor.Id))
            {
                return TypedResults.BadRequest($"Doctor with id {doctor.Id} already exists");
            }

            if(doctorEntries.Any(d => d.FullName == doctor.FullName))
            {
                return TypedResults.BadRequest("Doctor already exists");
            }

            Doctor entity = new Doctor();

            entity.Id = doctor.Id;
            entity.FullName = doctor.FullName;

            await repository.CreateDoctor(entity);
            return TypedResults.Ok(doctor);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetAppointments(IRepository repository)
        {
            var entities = await repository.GetAppointments();
            await repository.GetDoctors();
            await repository.GetPatients();


            List<AppointmentDto> appointments = new List<AppointmentDto>();

            foreach(var entity in entities)
            {
                AppointmentDto appointment = new AppointmentDto()
                {
                    Booking = entity.Booking,
                    DoctorId = entity.DoctorId,
                    DoctorName = entity.Doctor.FullName,
                    PatientId = entity.PatientId,
                    PatientName = entity.Patient.FullName,
                };
                appointments.Add(appointment);
            }
            Payload<List<AppointmentDto>> result = new Payload<List<AppointmentDto>>();
            result.data = appointments;

            return TypedResults.Ok(result);
        }


        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> GetAppointmentsByDoctorId(IRepository repository, int doctorid)
        {
            var entities = await repository.GetAppointmentsByDoctorId(doctorid);
            await repository.GetDoctors();
            await repository.GetPatients();

            if (!entities.Any(p => p.DoctorId == doctorid))
            {
                return TypedResults.NotFound("Doctor was not found");
            }

            List<AppointmentDto> appointments = new List<AppointmentDto>();

            foreach (var entity in entities)
            {
                AppointmentDto appointment = new AppointmentDto()
                {
                    Booking = entity.Booking,
                    DoctorId = entity.DoctorId,
                    DoctorName = entity.Doctor.FullName,
                    PatientId = entity.PatientId,
                    PatientName = entity.Patient.FullName,
                };
                appointments.Add(appointment);
            }
            Payload<List<AppointmentDto>> result = new Payload<List<AppointmentDto>>();
            result.data = appointments;

            return TypedResults.Ok(result);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> GetAppointmentsByPatientId(IRepository repository, int patientid)
        {
            var entities = await repository.GetAppointmentsByPatientId(patientid);
            await repository.GetDoctors();
            await repository.GetPatients();

            if(!entities.Any(p => p.PatientId == patientid)){
                return TypedResults.NotFound("Patient was not found");
            }
            List<AppointmentDto> appointments = new List<AppointmentDto>();

            foreach (var entity in entities)
            {
                AppointmentDto appointment = new AppointmentDto()
                {
                    Booking = entity.Booking,
                    DoctorId = entity.DoctorId,
                    DoctorName = entity.Doctor.FullName,
                    PatientId = entity.PatientId,
                    PatientName = entity.Patient.FullName,
                };
                appointments.Add(appointment);
            }
            Payload<List<AppointmentDto>> result = new Payload<List<AppointmentDto>>();
            result.data = appointments;

            return TypedResults.Ok(result);
        }

        public static async Task<IResult> GetPerscriptions(IRepository repository)
        {
            var entities = await repository.GetPerscriptions();

            List<PerscriptionDto> perscriptions = new List<PerscriptionDto>();

            foreach(var entity in entities)
            {
                PerscriptionDto perscription = new PerscriptionDto()
                {
                    Id = entity.Id,
                    Medicines = entity.Medicines.Select(m => new MedicineDto()
                    {
                        Id = m.Id,
                        Name = m.Name,
                        Notes = m.Notes,
                        Quantity = m.Quantity,                       
                    }).ToList()
                };
                perscriptions.Add(perscription);
            }

            Payload<List<PerscriptionDto>> result = new Payload<List<PerscriptionDto>>();
            result.data = perscriptions;

            return TypedResults.Ok(result);
        }

        public static async Task<IResult> GetPerscriptionById(IRepository repository, int id)
        {
            var entities = await repository.GetPerscriptions();

            if (!entities.Any(x => x.Id == id))
            {
                return TypedResults.NotFound("Perscription was not found");
            }

            var entity = await repository.GetPerscriptionById(id);
            PerscriptionDto perscription = new PerscriptionDto()
            {
                Id = entity.Id,
                Medicines = entity.Medicines.Select(m => new MedicineDto()
                {
                    Id = m.Id,
                    Name = m.Name,
                    Notes = m.Notes,
                    Quantity = m.Quantity,
                }).ToList()
            };

            Payload<PerscriptionDto> result = new Payload<PerscriptionDto>();
            result.data = perscription;

            return TypedResults.Ok(result);

        }

        public static async Task<IResult> CreatePerscription(IRepository repository, CreatePerscriptionDto perscription)
        {
            var entities = await repository.GetPerscriptions();

            if(entities.Any(p => p.Id == perscription.Id))
            {
                return TypedResults.BadRequest("Perscription with id already exists");
            }

            Perscription entity = new Perscription();

            entity.Id = perscription.Id;
             
            await repository.CreatePerscription(entity);
            return TypedResults.Ok(entity);
        }
    }
}
