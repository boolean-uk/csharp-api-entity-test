using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using System.Xml.Linq;
using workshop.wwwapi.Models;
using workshop.wwwapi.Models.DTOs;
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
            surgeryGroup.MapGet("/patient/{id}", GetPatientById);
            surgeryGroup.MapPost("/patient/post", CreatePatient);
            surgeryGroup.MapGet("/doctors", GetDoctors);
            surgeryGroup.MapGet("/doctor/{id}", GetDoctorById);
            surgeryGroup.MapGet("/appointments/doctor/{id}", GetAppointmentsByDoctor);
            surgeryGroup.MapGet("/appointments/patient/{id}", GetAppointmentsByPatient);
            surgeryGroup.MapPost("/appointments/post", CreateAppointment);
            surgeryGroup.MapGet("/Prescriptions/get", GetPrescriptions);
            surgeryGroup.MapPost("/Presciptions/post", CreatePrescriptions);
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        public static async Task<IResult> CreatePatient(IRepository repository, string name)
        {
            var patientsDtos = new List<CreatePatientDto>();
            var patient = repository.CreatePatient(name);
            var patientDto = new CreatePatientDto();
            patientDto.FullName = patient.Result.FullName;
            patientDto.Id = patient.Id;
            patientsDtos.Add(patientDto);
            return TypedResults.Ok(patientDto);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetPatients(IRepository repository)
        {
            var patients = await repository.GetPatients();
            var patientsDtos = new List<PatientDtoApps>();

            foreach (var patient in patients)
            {
                PatientDtoApps patientDto = new PatientDtoApps()
                {
                    FullName = patient.FullName,
                    Id = patient.Id,

                };
                foreach (var appointment in patient.Appointments)
                {
                    var app = new AppointmentForPatientDto
                    {
                        Doctor = new GetDoctorDto
                        {
                            FullName = appointment.Doctor.FullName,
                            Id = appointment.Doctor.Id
                        },
                        Booking = appointment.Booking
                    };
                    patientDto.Appointments.Add(app);


                }
                patientsDtos.Add(patientDto);

            }
            return TypedResults.Ok(patientsDtos);
        }


        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetPatientById(IRepository repository, int id)
        {
            var patient = await repository.GetPatientById(id);

            var patientDto = new PatientDtoApps()
            {
                FullName = patient.FullName,
                Id = patient.Id
            };

            foreach (var appointment in patient.Appointments)
            {
                var app = new AppointmentForPatientDto
                {
                    Doctor = new GetDoctorDto
                    {
                        FullName = appointment.Doctor.FullName,
                        Id = appointment.Doctor.Id
                    },
                    Booking = appointment.Booking
                };
                patientDto.Appointments.Add(app);

            }
            return TypedResults.Ok(patientDto);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetDoctors(IRepository repository)
        {
            var doctors = await repository.GetDoctors();
            var doctorDtos = new List<DoctorAppointmentsDto>();
            foreach (var doctor in doctors)
            {
                var doctorDto = new DoctorAppointmentsDto()
                { 
                    Id = doctor.Id,
                    FullName = doctor.FullName
                };
                foreach (var appointment in doctor.Appointments)
                {
                    var app = new AppointmentForDoctorDto
                    {
                        Patient = new GetPatientDto
                        {
                            FullName = appointment.Patient.FullName,
                            Id = appointment.Patient.Id
                        },
                        Booking = appointment.Booking
                    };
                    doctorDto.Appointments.Add(app);
                }

                doctorDtos.Add(doctorDto);
            }
            return TypedResults.Ok(doctorDtos);

        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetDoctorById(IRepository repository, int id)
        {
            var doctor = await repository.GetDcotorById(id);
            var doctorDto = new DoctorAppointmentsDto()
            {
                FullName = doctor.FullName,
                Id = doctor.Id
            };
            foreach (var appointment in doctor.Appointments)
            {
                var app = new AppointmentForDoctorDto
                {
                    Patient = new GetPatientDto
                    {
                        FullName = appointment.Patient.FullName,
                        Id = appointment.Patient.Id
                    },
                    Booking = appointment.Booking
                };
                doctorDto.Appointments.Add(app);
            }
                return TypedResults.Ok(doctorDto);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetAppointmentsByDoctor(IRepository repository, int id)
        {
            var OgAppointment = await repository.GetAppointmentsByDoctor(id);
            var NewAppointments = new List<GetAppointmentDto>();
            foreach (var appointment in OgAppointment)
            {
                var appointmentDto = new GetAppointmentDto()
                {
                    Patient = new GetPatientDto
                    {
                        FullName = appointment.Patient.FullName,
                        Id = appointment.Patient.Id
                    },
                    Doctor = new GetDoctorDto
                    {
                        Id = appointment.Doctor.Id,
                        FullName = appointment.Doctor.FullName
                    },
                    Booking = appointment.Booking
                };
                NewAppointments.Add(appointmentDto);
            }
            return TypedResults.Ok(NewAppointments);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetAppointmentsByPatient(IRepository repository, int id)
        {
            var OgAppointment = await repository.GetAppointmentsByPatient(id);
            var NewAppointments = new List<GetAppointmentDto>();

            foreach (var appointment in OgAppointment)
            {
                var appointmentDto = new GetAppointmentDto()
                {
                    Patient = new GetPatientDto
                    {
                        FullName = appointment.Patient.FullName,
                        Id = appointment.Patient.Id
                    },
                    Doctor = new GetDoctorDto
                    {
                        Id = appointment.Doctor.Id,
                        FullName = appointment.Doctor.FullName
                    },
                    Booking = appointment.Booking
                };
                NewAppointments.Add(appointmentDto);
            }
            return TypedResults.Ok(NewAppointments);
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(CreateAppointmentDto))]
        public static async Task<IResult> CreateAppointment(IRepository repository, CreateAppointmentDto createAppointmentDto)
        {
            var appointment = await repository.CreateAppointment(createAppointmentDto);

           
            var createdAppointmentDto = new CreateAppointmentDto
            {
                DoctorId = appointment.Doctor.Id,
                PatientId = appointment.Patient.Id,
                AppointmentTime = appointment.Booking
            };

            return TypedResults.Created(nameof(CreateAppointment),createdAppointmentDto);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetPrescriptions(IRepository repository)
        {
            IEnumerable<Prescription> ogPrescritpions = await repository.GetPrescriptions();
            IEnumerable<GetPrescriptionDto> prescriptionDto = ogPrescritpions.Select(x => new GetPrescriptionDto()
            {
               Medicines = x.Medicine.Select(m => new GetMedicineDto()
               {
                   Instruction = m.Instructions,
                   Name = m.Name,
                   Quantity = m.Quantity
               }).ToList()
            });
            return TypedResults.Ok(prescriptionDto);
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        public static async Task<IResult> CreatePrescriptions(IRepository repository, CreateMedicinePrescriptionDto medpre)
        {
            try
            {
                Prescription prescription = await repository.CreatePrescription(medpre);
                GetPrescriptionDto getPrescriptionDto = new GetPrescriptionDto()
                {
                    Medicines = prescription.Medicine.Select(x => new GetMedicineDto()
                    {
                        Name = x.Name,
                        Quantity = x.Quantity,
                        Instruction = x.Instructions
                    }).ToList()
                };
             return TypedResults.Created(nameof(CreatePrescriptions), getPrescriptionDto);
            } catch (Exception ex)
            {
                return TypedResults.BadRequest(ex.Message);
            }
        }
    }
}
