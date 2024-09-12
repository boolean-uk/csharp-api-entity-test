﻿using Microsoft.AspNetCore.Mvc;
using workshop.wwwapi.Models.DatabaseModels;
using workshop.wwwapi.Models.Dto.Appointment;
using workshop.wwwapi.Models.Dto.Doctor;
using workshop.wwwapi.Models.Dto.GenericDto;
using workshop.wwwapi.Models.Dto.Medicine;
using workshop.wwwapi.Models.Dto.Patient;
using workshop.wwwapi.Models.Dto.Prescription;
using workshop.wwwapi.Models.Dto.PrescriptionMedicine;
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
            surgeryGroup.MapGet("/patients/{id}", GetAPatient);
            surgeryGroup.MapPost("/patients", CreatePatient);

            surgeryGroup.MapGet("/doctors", GetDoctors);
            surgeryGroup.MapGet("/doctors/{id}", GetADoctor);
            surgeryGroup.MapPost("/doctors", CreateDoctor);
            surgeryGroup.MapGet("/appointments", GetAppointments);

            surgeryGroup.MapGet("/appointmentsbyids/{Doc_id},{Pat_id}", GetAppointmentsByIds);
            surgeryGroup.MapGet("/appointmentsbydoctor/{id}", GetAppointmentsByDoctor);
            surgeryGroup.MapGet("/appointmentsbypatient/{id}", GetAppointmentsByPatient);
            surgeryGroup.MapPost("/appointment", CreateAppointment);

            surgeryGroup.MapGet("/prescriptions", GetPrescriptions);
            surgeryGroup.MapGet("/prescriptions{id}", GetAPrescription);
            surgeryGroup.MapPost("/prescriptions", CreatePresctiprion);

            surgeryGroup.MapGet("/medicines", GetMedicines);
            surgeryGroup.MapGet("/medicines{id}", GetAMedicine);
            surgeryGroup.MapPost("/medicines", CreateMedicine);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetPatients(IRepository repository)
        { 
            var patients = await repository.GetPatients();

            List<PatientDto> patientsDto = new List<PatientDto>();

            foreach (var patient in patients)
            {
                var patientDto = new PatientDto()
                {
                    Id = patient.Id,
                    Name = patient.FullName,
                    Appointments = new List<AppointmentDoctorDto>()
                };
                foreach (var appointment in patient.Appointments)
                {
                    var appointmentDto = new AppointmentDoctorDto()
                    {
                        Booking = appointment.Booking,
                        DoctorId = appointment.DoctorId,
                        Doctor = new Models.Dto.Doctor.DoctorPlainDto()
                        {
                            Name = appointment.Doctor.FullName,
                            Id  = appointment.Doctor.Id
                        }
                    };
                    patientDto.Appointments.Add(appointmentDto);
                }
                patientsDto.Add(patientDto);
            }

            Payload<List<PatientDto>> payload = new Payload<List<PatientDto>>();
            payload.data = patientsDto;
            return TypedResults.Ok(payload);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetAPatient(IRepository repository, int id)
        {
            var patient = await repository.GetAPatient(id);

            PatientDto patientDto  = new PatientDto()
            {
                Id = patient.Id,
                Name = patient.FullName,
             Appointments = new List<AppointmentDoctorDto>()
            };
            foreach (var appointment in patient.Appointments)
            {
                var appointmentDto = new AppointmentDoctorDto()
                {
                    Booking = appointment.Booking,
                    DoctorId = appointment.DoctorId,
                    Doctor = new Models.Dto.Doctor.DoctorPlainDto()
                    {
                        Name = appointment.Doctor.FullName,
                        Id = appointment.Doctor.Id
                    }
                };
                patientDto.Appointments.Add(appointmentDto);
            }


            Payload<PatientDto> payload = new Payload<PatientDto>();
            payload.data = patientDto;
            return TypedResults.Ok(payload);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        private static async Task<IResult> CreatePatient(IRepository repository, string input)
        {
            var test = await repository.CreatePatient(input);
            PatientPlainDto patientDto = new PatientPlainDto()
            {
                Id = test.Id,
                Name = test.FullName
            };
            return test == null ? Results.BadRequest() : TypedResults.Created($"{patientDto.Name}", patientDto);
        }

       
        
        
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetDoctors(IRepository repository)
        {
            var doctors = await repository.GetDoctors();

            List<DoctorDto> doctorsDto = new List<DoctorDto>();

            foreach (var doctor in doctors)
            {
                var doctorDto = new DoctorDto()
                {
                    Id = doctor.Id,
                    Name = doctor.FullName,
                    Appointments = new List<AppointmentPatientDto>()
                };
                foreach (var appointment in doctor.Appointments)
                {
                    var appointmentDto = new AppointmentPatientDto()
                    {
                        Booking = appointment.Booking,
                        PatientId = appointment.DoctorId,
                        Patient = new PatientPlainDto() 
                        {
                            Name = appointment.Patient.FullName,
                            Id = appointment.Patient.Id
                        }
                    };
                    doctorDto.Appointments.Add(appointmentDto);
                }
                doctorsDto.Add(doctorDto);
            }

            Payload<List<DoctorDto>> payload = new Payload<List<DoctorDto>>();
            payload.data = doctorsDto;
            return TypedResults.Ok(payload);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetADoctor(IRepository repository, int id)
        {
            var doctor = await repository.GetADoctor(id);

            DoctorDto doctorDto = new DoctorDto()
            {
                Id = doctor.Id,
                Name = doctor.FullName,
                Appointments = new List<AppointmentPatientDto>()
            };
            foreach (var appointment in doctor.Appointments)
            {
                var appointmentDto = new AppointmentPatientDto()
                {
                    Booking = appointment.Booking,
                    PatientId = appointment.DoctorId,
                    Patient = new PatientPlainDto()
                    {
                        Name = appointment.Patient.FullName,
                        Id = appointment.Patient.Id
                    }
                };
                doctorDto.Appointments.Add(appointmentDto);
            }


            Payload<DoctorDto> payload = new Payload<DoctorDto>();
            payload.data = doctorDto;
            return TypedResults.Ok(payload);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        private static async Task<IResult> CreateDoctor(IRepository repository, string input)
        {
            var test = await repository.CreateDoctor(input);
            DoctorPlainDto DoctorDto = new DoctorPlainDto()
            {
                Id = test.Id,
                Name = test.FullName
            };
            return test == null ? Results.BadRequest() : TypedResults.Created($"{DoctorDto.Name}", DoctorDto);
        }

        
        
        
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetAppointments(IRepository repository)
        {
            var appointments = await repository.GettAppointments();

            List<AppointmentDto> appointmentDtos = new List<AppointmentDto>();

            foreach (var appointment in appointments)
            {
                var appointmentDto = new AppointmentDto()
                {
                    PatientId = appointment.PatientId,
                    DoctorId = appointment.DoctorId,
                    Patient = new PatientPlainDto()
                    {
                        Id = appointment.Patient.Id,
                        Name = appointment.Patient.FullName
                    },
                    Doctor = new DoctorPlainDto()
                    {
                        Id = appointment.Doctor.Id,
                        Name = appointment.Doctor.FullName
                    }
                };
                appointmentDtos.Add(appointmentDto);
            }

            Payload<List<AppointmentDto>> payload = new Payload<List<AppointmentDto>>();
            payload.data = appointmentDtos;
            return TypedResults.Ok(payload);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetAppointmentsByIds(IRepository repository, int Doc_id, int Pat_id)
        {
            var appointments = await repository.GetAppointmentsByIds(Doc_id, Pat_id);

            List<AppointmentDto> appointmentDtos = new List<AppointmentDto>();

            foreach (var appointment in appointments)
            {
                var appointmentDto = new AppointmentDto()
                {
                    PatientId = appointment.PatientId,
                    DoctorId = appointment.DoctorId,
                    Patient = new PatientPlainDto()
                    {
                        Id = appointment.Patient.Id,
                        Name = appointment.Patient.FullName
                    },
                    Doctor = new DoctorPlainDto()
                    {
                        Id = appointment.Doctor.Id,
                        Name = appointment.Doctor.FullName
                    }
                };
                appointmentDtos.Add(appointmentDto);
            }

            Payload<List<AppointmentDto>> payload = new Payload<List<AppointmentDto>>();
            payload.data = appointmentDtos;
            return TypedResults.Ok(payload);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetAppointmentsByDoctor(IRepository repository, int id)
        {
            var appointments = await repository.GetAppointmentsByDoctor(id);

            List<AppointmentDto> appointmentDtos = new List<AppointmentDto>();

            foreach (var appointment in appointments)
            {
                var appointmentDto = new AppointmentDto()
                {
                    PatientId = appointment.PatientId,
                    DoctorId = appointment.DoctorId,
                    Patient = new PatientPlainDto()
                    {
                        Id = appointment.Patient.Id,
                        Name = appointment.Patient.FullName
                    },
                    Doctor = new DoctorPlainDto()
                    {
                        Id = appointment.Doctor.Id,
                        Name = appointment.Doctor.FullName
                    }
                };
                appointmentDtos.Add(appointmentDto);
            }

            Payload<List<AppointmentDto>> payload = new Payload<List<AppointmentDto>>();
            payload.data = appointmentDtos;
            return TypedResults.Ok(payload);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetAppointmentsByPatient(IRepository repository, int id)
        {
            var appointments = await repository.GetAppointmentsByPatient(id);

            List<AppointmentDto> appointmentDtos = new List<AppointmentDto>();

            foreach (var appointment in appointments)
            {
                var appointmentDto = new AppointmentDto()
                {
                    PatientId = appointment.PatientId,
                    DoctorId = appointment.DoctorId,
                    Patient = new PatientPlainDto()
                    {
                        Id = appointment.Patient.Id,
                        Name = appointment.Patient.FullName
                    },
                    Doctor = new DoctorPlainDto()
                    {
                        Id = appointment.Doctor.Id,
                        Name = appointment.Doctor.FullName
                    }
                };
                appointmentDtos.Add(appointmentDto);
            }

            Payload<List<AppointmentDto>> payload = new Payload<List<AppointmentDto>>();
            payload.data = appointmentDtos;
            return TypedResults.Ok(payload);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        private static async Task<IResult> CreateAppointment(IRepository repository, int Doc_id, int Pat_id)
        {
            var test = await repository.CreateAppointment(Doc_id, Pat_id);
            AppointmentDto AppointmentDto = new AppointmentDto()
            {
                DoctorId = test.DoctorId,
                PatientId = test.PatientId
            };
            return test == null ? Results.BadRequest() : TypedResults.Created($"{AppointmentDto.Booking}", AppointmentDto);
        }




        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetPrescriptions(IRepository repository)
        {
            var prescriptions = await repository.GetPrescriptions();

            List<PrescriptionDto> prescriptionDtos = new List<PrescriptionDto>();

            foreach (var prescription in prescriptions)
            {
                var prescriptionDto = new PrescriptionDto()
                {
                    Id = prescription.Id,
                    DoctorId = prescription.DoctorId,
                    PatientId = prescription.PatientId
                };
                prescriptionDto.Doctor = new DoctorPlainDto()
                {
                    Id = prescription.Doctor.Id,
                    Name = prescription.Doctor.FullName
                };
                prescriptionDto.Patient = new PatientPlainDto()
                {
                    Id = prescription.Patient.Id,
                    Name = prescription.Patient.FullName,
                };

                foreach (var perMed in prescription.PrescriptionMedicine)
                {
                    var relationDto = new MedicineNoPrescriptionDto()
                    {
                        MedicineId = perMed.MedicineId,
                        Quantity = perMed.Quantity,
                        Notes = perMed.Notes
                    };
                    relationDto.Medicine = new Models.Dto.Medicine.MedicinePlainDto()
                    {
                        Name = perMed.Medicine.Name,
                        Id = perMed.Medicine.Id
                    };
                    prescriptionDto.PrescriptionMedicine.Add(relationDto);
                }
                prescriptionDtos.Add(prescriptionDto);
            }

            Payload<List<PrescriptionDto>> payload = new Payload<List<PrescriptionDto>>();
            payload.data = prescriptionDtos;
            return TypedResults.Ok(payload);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetAPrescription(IRepository repository, int id)
        {
            var prescription = await repository.GetAPrescription(id);

            PrescriptionDto prescriptionDto = new PrescriptionDto()
            {
                Id = prescription.Id,
                DoctorId = prescription.DoctorId,
                PatientId = prescription.PatientId
            };

            prescriptionDto.Doctor = new DoctorPlainDto()
            {
                Id = prescription.Doctor.Id,
                Name = prescription.Doctor.FullName
            };
            prescriptionDto.Patient = new PatientPlainDto()
            {
                Id = prescription.Patient.Id,
                Name = prescription.Patient.FullName,
            };

            foreach (var perMed in prescription.PrescriptionMedicine)
            {
                var relationDto = new MedicineNoPrescriptionDto()
                {
                    MedicineId = perMed.MedicineId,
                    Quantity = perMed.Quantity,
                    Notes = perMed.Notes
                };
                relationDto.Medicine = new Models.Dto.Medicine.MedicinePlainDto()
                {
                    Name = perMed.Medicine.Name,
                    Id = perMed.Medicine.Id
                };
                prescriptionDto.PrescriptionMedicine.Add(relationDto);
            }

            Payload<PrescriptionDto> payload = new Payload<PrescriptionDto>();
            payload.data = prescriptionDto;
            return TypedResults.Ok(payload);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        private static async Task<IResult> CreatePresctiprion(IRepository repository, int Doc_id, int Pat_id)
        {
            var test = await repository.CreatePrescription(Doc_id, Pat_id);
            PrescriptionPlainDto PrescriptionDto = new PrescriptionPlainDto()
            {
                Id = test.Id,
                DoctorId = test.DoctorId,
                PatientId = test.PatientId
            };
            return test == null ? Results.BadRequest() : TypedResults.Created($"{PrescriptionDto.Id}", PrescriptionDto);
        }




        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetMedicines(IRepository repository)
        {
            var medicines = await repository.GetMedicines();

            List<MedicineDto> medicineDtos = new List<MedicineDto>();

            foreach (var medicine in medicines)
            {
                var medicineDto = new MedicineDto()
                {
                    Id = medicine.Id,
                    Name = medicine.Name
                };

                foreach (var perMed in medicine.PrescriptionMedicine)
                {
                    var relationDto = new PrescritptionNoMedicineDto()
                    {
                        PerscriptionId = perMed.PrescriptionId,
                        Quantity = perMed.Quantity,
                        Notes = perMed.Notes
                    };
                    relationDto.Prescription = new PrescriptionPlainDto()
                    {
                        Id = perMed.Prescription.Id,
                        DoctorId = perMed.Prescription.DoctorId,
                        PatientId = perMed.Prescription.PatientId,
                    };
                    medicineDto.PrescriptionMedicine.Add(relationDto);
                }
                medicineDtos.Add(medicineDto);
            }

            Payload<List<MedicineDto>> payload = new Payload<List<MedicineDto>>();
            payload.data = medicineDtos;
            return TypedResults.Ok(payload);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetAMedicine(IRepository repository, int id)
        {
            var medicine = await repository.GetAMedicine(id);

            MedicineDto medicineDto = new MedicineDto()
            {
                Id = medicine.Id,
                Name = medicine.Name
            };

            foreach (var perMed in medicine.PrescriptionMedicine)
            {
                var relationDto = new PrescritptionNoMedicineDto()
                {
                    PerscriptionId = perMed.PrescriptionId,
                    Quantity = perMed.Quantity,
                    Notes = perMed.Notes
                };
                relationDto.Prescription = new PrescriptionPlainDto()
                {
                    Id = perMed.Prescription.Id,
                    DoctorId = perMed.Prescription.DoctorId,
                    PatientId = perMed.Prescription.PatientId,
                };
                medicineDto.PrescriptionMedicine.Add(relationDto);
            }

            Payload<MedicineDto> payload = new Payload<MedicineDto>();
            payload.data = medicineDto;
            return TypedResults.Ok(payload);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        private static async Task<IResult> CreateMedicine(IRepository repository, string name)
        {
            var test = await repository.CreateMedicine(name);
            MedicinePlainDto MedicineDto = new MedicinePlainDto()
            {
                Id = test.Id,
                Name = test.Name
            };
            return test == null ? Results.BadRequest() : TypedResults.Created($"{MedicineDto.Id}", MedicineDto);
        }
    }
}