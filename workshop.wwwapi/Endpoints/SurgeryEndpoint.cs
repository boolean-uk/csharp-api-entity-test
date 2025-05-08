using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
            surgeryGroup.MapGet("/patients/{id}", GetPatientById);
            surgeryGroup.MapPost("/patients", CreatePatient);

            surgeryGroup.MapGet("/doctors", GetDoctors);
            surgeryGroup.MapGet("/doctors/{id}", GetDoctorByIdWithAppointments);
            surgeryGroup.MapPost("/doctors", CreateDoctor);

            surgeryGroup.MapGet("/appointments", GetAppointments);
            surgeryGroup.MapGet("/appointments/{doctorId}/{patientId}", GetAppointmentById);
            surgeryGroup.MapPost("/appointments", CreateAppointment);

            surgeryGroup.MapGet("/prescriptions", GetPrescriptions);
            surgeryGroup.MapPost("/prescriptions", CreatePrescription);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> CreatePatient(IRepository<Patient> repository, PatientPost model)
        {
            var newPatient = new Patient()
            {
                FullName = model.FullName
            };
            var createdPatient = await repository.Insert(newPatient);

            var patientDTO = new PatientDTO()
            {
                Id = createdPatient.Id,
                FullName = createdPatient.FullName
            };

            return TypedResults.Created($"/surgery/patients/{createdPatient.Id}", patientDTO);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetPatients(IRepository<Patient> repository)
        {
            var patients = await repository.GetWithNestedIncludes(
                query => query
                    .Include(p => p.Appointments)
                    .ThenInclude(a => a.Doctor)
            );
            var patientDTOs = new List<PatientDTO>();

            foreach (var p in patients)
            {
                var patientDTO = new PatientDTO()
                {
                    Id = p.Id,
                    FullName = p.FullName,
                    Appointments = p.Appointments.Select(a => new AppointmentDoctorDTO()
                    {
                        DoctorId = a.DoctorId,
                        DoctorName = a.Doctor.FullName,
                        Booking = a.Booking
                    }).ToList()
                };
                patientDTOs.Add(patientDTO);
            }
            return TypedResults.Ok(patientDTOs);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetPatientById(IRepository<Patient> repository, int id)
        {

            var patient = await repository.GetByIdWithNestedIncludes(
                p => p.Id == id,
                query => query
                .Include(p => p.Appointments)
                .ThenInclude(a => a.Doctor));
            if (patient == null) return TypedResults.NotFound("Patient not found");
            var patientDTO = new PatientDTO()
            {
                Id = patient.Id,
                FullName = patient.FullName,
                Appointments = patient.Appointments.Select(a => new AppointmentDoctorDTO()
                {
                    DoctorId = a.DoctorId,
                    DoctorName = a.Doctor.FullName,
                    Booking = a.Booking
                }).ToList()
            };
            return TypedResults.Ok(patientDTO);
        }


        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> CreateDoctor(IRepository<Doctor> repository, DoctorPost model)
        {
            var newDoctor = new Doctor()
            {
                FullName = model.FullName
            };
            var createdDoctor = await repository.Insert(newDoctor);

            var doctorDTO = new DoctorDTO()
            {
                Id = createdDoctor.Id,
                FullName = createdDoctor.FullName
            };

            return TypedResults.Created($"/surgery/doctors/{createdDoctor.Id}", doctorDTO);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetDoctors(IRepository<Doctor> repository)
        {
            var doctors = await repository.GetWithNestedIncludes(
                query => query
                    .Include(d => d.Appointments)
                    .ThenInclude(a => a.Patient)
            );
            var doctorDTOs = new List<DoctorDTO>();

            foreach (var d in doctors)
            {
                var doctorDTO = new DoctorDTO()
                {
                    Id = d.Id,
                    FullName = d.FullName,
                    Appointments = d.Appointments.Select(a => new AppointmentPatientDTO()
                    {
                        PatientId = a.PatientId,
                        PatientName = a.Patient.FullName,
                        Booking = a.Booking
                    }).ToList()
                };
                doctorDTOs.Add(doctorDTO);
            }
            return TypedResults.Ok(doctorDTOs);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetDoctorByIdWithAppointments(IRepository<Doctor> repository, int id)
        {
            var target = await repository.GetByIdWithNestedIncludes(
                d => d.Id == id, 
                query => query
                    .Include(d => d.Appointments)
                    .ThenInclude(a => a.Patient)
            );

            if (target == null) return TypedResults.NotFound("Doctor not found");
            var doctorDTO = new DoctorDTO()
            {
                Id = target.Id,
                FullName = target.FullName,
                Appointments = target.Appointments.Select(a => new AppointmentPatientDTO()
                {
                    PatientId = a.PatientId,
                    PatientName = a.Patient.FullName,
                    Booking = a.Booking
                }).ToList()
            };
            return TypedResults.Ok(doctorDTO);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetAppointments(IRepository<Appointment> repository)
        {
            var appointments = await repository.GetWithNestedIncludes(
                query => query
                    .Include(a => a.Doctor)
                    .Include(a => a.Patient)
            );

            var result = new List<AppointmentDTO>();

            foreach(var a in appointments)
            {
                var dto = new AppointmentDTO()
                {
                    Booking = a.Booking,
                    DoctorId = a.DoctorId,
                    DoctorName = a.Doctor.FullName,
                    PatientId = a.PatientId,
                    PatientName = a.Patient.FullName
                };
                result.Add(dto);
            }
            return TypedResults.Ok(result);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetAppointmentById(IRepository<Appointment> repository, int doctorId, int patientId)
        {
            var target = await repository.GetByIdWithNestedIncludes(
                a => a.DoctorId == doctorId && a.PatientId == patientId,
                query => query
                    .Include(a => a.Doctor)
                    .Include(a => a.Patient)
            );

            var result = new AppointmentDTO()
            {
                Booking = target.Booking,
                DoctorId = target.DoctorId,
                DoctorName = target.Doctor.FullName,
                PatientId = target.PatientId,
                PatientName = target.Patient.FullName,
            };

            return TypedResults.Ok(result);

        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> CreateAppointment(IRepository<Appointment> repository, AppointmentPost model)
        {
            var newAppointment = new Appointment()
            {
                Booking = model.Booking,
                DoctorId = model.DoctorId,
                PatientId = model.PatientId,
                Type = model.AppointmentType
            };
            var createdAppointment = await repository.Insert(newAppointment);

            var result = new BasicAppointmentDTO()
            {
                Booking = createdAppointment.Booking,
                DoctorId = createdAppointment.DoctorId,
                PatientId = createdAppointment.PatientId,
            };

            return TypedResults.Created($"/surgery/appointments/{createdAppointment.DoctorId}/{createdAppointment.PatientId}", result);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetPrescriptions(IRepository<Prescription> repository)
        {
            var prescriptions = await repository.GetWithNestedIncludes(
                query => query
                    .Include(p => p.MedicinePrecriptions).ThenInclude(mp => mp.Medicine)
                    .Include(p => p.Doctor)
                    .Include(p => p.Patient)
            );

            var result = new List<PrescriptionDTO>();

            foreach (var p in prescriptions)
            {
                var dto = new PrescriptionDTO()
                {
                    Medicines = p.Medicines.Select(m => new MedicineDTO()
                    {
                        Name = m.Name,
                        Quantity = m.Quantity,
                        Notes = m.Notes,
                    }).ToList(),
                    DoctorName = p.Doctor.FullName,
                    PatientName = p.Patient.FullName
                };
                result.Add(dto);
            }
            return TypedResults.Ok(result);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> CreatePrescription(IRepository<Prescription> repository,IRepository<MedicinePrescription> msrepo, PrescriptionPost model)
        {
            var newPrescription = new Prescription()
            {
                MedicineIds = model.MedicineIds,
                DoctorId = model.DoctorId,
                PatientId = model.PatientId,
            };

            var created = await repository.Insert(newPrescription);
            var medicinePrescription = model.MedicineIds.Select(medicineId => new MedicinePrescription
            {
                PrescriptionId = created.Id,
                MedicineId = medicineId
            }).ToList();

            await msrepo.InsertRange(medicinePrescription);

            var getCreated = await repository.GetByIdWithNestedIncludes(
                p => p.Id == created.Id,
                query => query
                .Include(p => p.Medicines)
                .Include(p => p.Doctor)
                .Include(p => p.Patient)
            );
          
            var dto = new PrescriptionDTO()
            {
                Medicines = getCreated.Medicines.Select(m => new MedicineDTO()
                {
                    Name = m.Name,
                    Quantity = m.Quantity,
                    Notes = m.Notes,
                }).ToList(),
                DoctorName = getCreated.Doctor.FullName,
                PatientName = getCreated.Patient.FullName
            };

            return TypedResults.Created($"/surgery/patients/{getCreated.Id}", dto);
        }

    }
}
