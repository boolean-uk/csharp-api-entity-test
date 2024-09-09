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
            surgeryGroup.MapGet("/appointments/perscriptions", GetAllPerscriptions);
            surgeryGroup.MapGet("/appointments/perscriptions/{perscriptionId}", GetAPerscription);
            surgeryGroup.MapPost("/appointments/perscriptions", CreatePerscription);
            surgeryGroup.MapPost("/appointments/perscriptions/injectInto/{perscriptionId}/{appointmentId}", injectPerscription);

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
        public static async Task<IResult> GetPatients(IRepository<Patient> repository, IAppointmentRepository appointmentRepository)
        {
            var patients = await repository.GetAll();

            var patientDTOs = new List<PatientDTO>();

            foreach (var p in patients)
            {
                var appointmentList = await appointmentRepository.getAppointmentByPatient(p.Id);


                var patientDTO = new PatientDTO
                {
                    fullName = p.FullName,
                    Id = p.Id,
                    appointments = appointmentList.Select(a => new DoctorAppointmentDTO
                    {

                        appointmentDate = a.Booking,
                        doctorName = a.doctor.FullName,
                        doctorId = a.doctor.Id,

                    }).ToList()
                };

                patientDTOs.Add(patientDTO);

            }


            return TypedResults.Ok(patientDTOs);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> getPatient(IAppointmentRepository AppointmentRepo, IRepository<Patient> repository, int patientId)
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
        public static async Task<IResult> GetDoctors(IRepository<Doctor> repository, IAppointmentRepository appointmentRepository)
        {
            var doctors = await repository.GetAll();

            var doctorDTOs = new List<DoctorDTO>();

            foreach (var doctor in doctors)
            {
                var appointmentList = await appointmentRepository.getAppointmentByDoctor(doctor.Id);

                var doctorDTO = new DoctorDTO
                {
                    fullName = doctor.FullName,
                    id = doctor.Id,
                    appointments = appointmentList.Select(a => new PatientAppointmentDTO
                    {
                        appointmentDate = a.Booking,
                        patientFullName = a.patient.FullName,
                        patientId = a.patient.Id,
                    }).ToList()
                };
                doctorDTOs.Add(doctorDTO);
            }

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
        public static async Task<IResult> GetAppointments(IAppointmentRepository appointmentRepository)
        {
            var appointments = await appointmentRepository.GetAppointments();
            if (appointments == null)
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
        public static async Task<IResult> createAppointment(IRepository<Appointment> Generic, IAppointmentRepository repository, int patientId, int doctorId)
        {
            var appointment = new Appointment() { Booking = DateTime.UtcNow, DoctorId = doctorId, PatientId = patientId };

            if (appointment == null)
            {
                return TypedResults.NotFound(); ;
            }

            Generic.Add(appointment);
            return TypedResults.Created();
        }

        [ProducesResponseType(StatusCodes.Status200OK)]

        public async static Task<IResult> GetAllPerscriptions(IRepository<Perscription> repository)
        {
            var perscriptions = await repository.GetAll();
            if (perscriptions == null)
            {
                return TypedResults.NotFound();
            }
            var perscriptionDTOs = new List<PerscriptionDTO>();

            foreach (var perscription in perscriptions)
            {
                var DTO = new PerscriptionDTO
                {
                    AppointmentId = perscription.AppointmentId,
                    doctorId = perscription.Appointment.DoctorId,
                    patientId = perscription.Appointment.PatientId,
                    Medicines = perscription.Medicines.Select(m => new MedicineDTO
                    {
                        name = m.Name,
                        quantity = m.Quantity,
                        instructions = m.Instructions
                    }).ToList()
                };
                perscriptionDTOs.Add(DTO);
            }


            return TypedResults.Ok(perscriptionDTOs);
        }

        public static async Task<IResult> GetAPerscription(IPerscriptionRepository repository, int id)
        {
            var perscription = await repository.GetOne(id);
            var medicines = await repository.GetMedicinesByPrescriptionIdAsync(id);
            if (perscription == null)
            {
                return TypedResults.NotFound();
            }
            PerscriptionDTO perscriptionDTO = new PerscriptionDTO
            {
                Id = id,
                AppointmentId = perscription.AppointmentId,
                doctorId = perscription.Appointment.DoctorId,
                patientId = perscription.Appointment.PatientId,
                Medicines = medicines.Select(m => new MedicineDTO
                {
                    name = m.Name,
                    quantity = m.Quantity,
                    instructions = m.Instructions
                }).ToList()
            };
            return TypedResults.Ok(perscriptionDTO);

        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> CreatePerscription(IPerscriptionRepository perscriptionRepository, CreatePerscriptionDTO perscriptionDTO)
        {
            var medicines = new List<Medicine>();
            var medicineIds = perscriptionDTO.medicineIds;
            foreach (var item in medicineIds)
            {
                Medicine medicinetoAdd = await perscriptionRepository.GetMedicineById(item);
                Medicine medcicine = new Medicine
                {
                    Name = medicinetoAdd.Name,
                    Instructions = medicinetoAdd.Instructions,
                    Quantity = medicinetoAdd.Quantity
                };
                medicines.Add(medcicine);
            }
            var perscription = new Perscription
            {
                AppointmentId = perscriptionDTO.appointmentId,
                Id = perscriptionDTO.Id,
                Medicines = medicines


            };

            if (perscription == null)
            {
                return TypedResults.NotFound(); ;
            }

            await perscriptionRepository.Create(perscription);
            return TypedResults.Created();
        }

        public static async Task<IResult> injectPerscription(IPerscriptionRepository perscriptionRepository, int perscriptionId, int appointmentId)
        {
            await perscriptionRepository.InjectToAppointment(appointmentId, perscriptionId);
            var perscription = await perscriptionRepository.GetOne(perscriptionId);
            return TypedResults.Ok(perscription);
        }
    }
}
