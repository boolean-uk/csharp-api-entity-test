using Microsoft.AspNetCore.Mvc;
using System.Numerics;
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
            surgeryGroup.MapPost("/create/patients/", CreatePatient);
            surgeryGroup.MapGet("/doctors", GetDoctors);
            surgeryGroup.MapGet("/doctors/{id}", GetDoctorById);
            surgeryGroup.MapPost("/create/doctors/", CreateDoctor);
            surgeryGroup.MapGet("/appointments", GetAppointments);
            surgeryGroup.MapPost("/create/appointments", CreateAppointment);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetPatients(IRepository repository)
        {
            GetPatientsResponse response = new GetPatientsResponse();
            var patients = await repository.GetPatients();

            foreach (Patient patient in patients)
            {
                PatientDTOWithAppointments patientDTO = new PatientDTOWithAppointments() 
                {
                    Id = patient.Id,
                    FullName = patient.FullName
                };

                foreach (Appointment appointment in patient.Appointments)
                {
                    patientDTO.Appointments.Add(new PatientAppointmentDTO()
                    {
                        Booking = appointment.Booking,
                        Doctor = new DoctorDTOWithoutAppointments() 
                        { 
                            Id = appointment.Doctor.Id, 
                            FullName = appointment.Doctor.FullName 
                        }
                    });
                }

                response.Patients.Add(patientDTO);
            }

            return TypedResults.Ok(response.Patients);
        }
        
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetPatientById(IRepository repository, int id)
        {
            var target = await repository.GetPatientById(id);

            PatientDTOWithAppointments patientDTO = new PatientDTOWithAppointments() 
            {
                Id = target.Id,
                FullName = target.FullName
            };

            foreach (Appointment appointment in target.Appointments)
            {
                patientDTO.Appointments.Add(new PatientAppointmentDTO()
                {
                    Booking = appointment.Booking,
                    Doctor = new DoctorDTOWithoutAppointments()
                    {
                        Id = appointment.Doctor.Id,
                        FullName = appointment.Doctor.FullName
                    }
                });
            }

            return TypedResults.Ok(patientDTO);
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        public static async Task<IResult> CreatePatient(IRepository repository, DoctorPatientPostModel model)
        {
            Patient newPatient = new Patient() 
            {
                FullName = model.FullName
            };

            var createdPatient = await repository.CreatePatient(newPatient);
            var response = await repository.GetPatientById(createdPatient.Id);

            return TypedResults.Ok(response);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetDoctors(IRepository repository)
        {
            GetDoctorsResponse response = new GetDoctorsResponse();
            var doctors = await repository.GetDoctors();

            foreach (Doctor doctor in doctors)
            {
                DoctorDTOWithAppointments doctorDTO = new DoctorDTOWithAppointments()
                {
                    Id = doctor.Id,
                    FullName = doctor.FullName
                };

                foreach (Appointment appointment in doctor.Appointments)
                {
                    doctorDTO.Appointments.Add(new DoctorAppointmentDTO()
                    {
                        Booking = appointment.Booking,
                        Patient = new PatientDTOWithoutAppointments()
                        {
                            Id = appointment.Patient.Id,
                            FullName = appointment.Patient.FullName
                        }
                    });
                }

                response.Doctors.Add(doctorDTO);
            }

            return TypedResults.Ok(response.Doctors);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetDoctorById(IRepository repository, int id)
        {
            var target = await repository.GetDoctorById(id);

            DoctorDTOWithAppointments doctorDTO = new DoctorDTOWithAppointments()
            {
                Id = target.Id,
                FullName = target.FullName
            };

            foreach (Appointment appointment in target.Appointments)
            {
                doctorDTO.Appointments.Add(new DoctorAppointmentDTO()
                {
                    Booking = appointment.Booking,
                    Patient = new PatientDTOWithoutAppointments()
                    {
                        Id = appointment.Patient.Id,
                        FullName = appointment.Patient.FullName
                    }
                });
            }

            return TypedResults.Ok(doctorDTO);
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        private static async Task<IResult> CreateDoctor(IRepository repository, DoctorPatientPostModel model)
        {
            Doctor newDoctor = new Doctor()
            {
                FullName = model.FullName
            };

            var createdDoctor = await repository.CreateDoctor(newDoctor);
            var response = await repository.GetDoctorById(createdDoctor.Id);

            return TypedResults.Ok(response);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetAppointments(IRepository repository)
        {
            GetAppointmentsResponse response = new GetAppointmentsResponse();
            var appointments = await repository.GetAppointments();

            foreach (Appointment appointment in appointments)
            {
                AllAppointmentsDTO allAppointmentsDTO = new AllAppointmentsDTO()
                {
                    Booking = appointment.Booking,
                    Doctor = new DoctorDTOWithoutAppointments() 
                    {
                        Id = appointment.Doctor.Id,
                        FullName = appointment.Doctor.FullName
                    },
                    Patient = new PatientDTOWithoutAppointments() 
                    {
                        Id = appointment.Patient.Id,
                        FullName = appointment.Patient.FullName
                    }
                };

                response.Appointments.Add(allAppointmentsDTO);
            }

            return TypedResults.Ok(response.Appointments);
        }

        public static async Task<IResult> CreateAppointment(IRepository repository, AppointmentPostModel model)
        {
            Appointment newAppointment = new Appointment()
            {
                Booking = DateTime.UtcNow,
                DoctorId = model.DoctorID,
                PatientId = model.PatientID
            };

            var createdAppointment = await repository.CreateAppointment(newAppointment);
            var response = await repository.GetAppointmentById(model.DoctorID, model.PatientID);

            GetAppointmentsResponse appointments = new GetAppointmentsResponse();

            foreach (Appointment appointment in response)
            {
                AllAppointmentsDTO allAppointmentsDTO = new AllAppointmentsDTO()
                {
                    Booking = appointment.Booking,
                    Doctor = new DoctorDTOWithoutAppointments()
                    {
                        Id = appointment.Doctor.Id,
                        FullName = appointment.Doctor.FullName
                    },
                    Patient = new PatientDTOWithoutAppointments()
                    {
                        Id = appointment.Patient.Id,
                        FullName = appointment.Patient.FullName
                    }
                };

                appointments.Appointments.Add(allAppointmentsDTO);
            }

            return TypedResults.Ok(appointments);
        }

        //[ProducesResponseType(StatusCodes.Status200OK)]
        //public static async Task<IResult> GetAppointmentsByDoctorId(IRepository repository, int id)
        //{
        //    return TypedResults.Ok(await repository.GetAppointmentsByDoctor(id));
        //}
    }
}
