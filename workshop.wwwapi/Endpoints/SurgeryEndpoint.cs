using Microsoft.AspNetCore.Mvc;
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
            surgeryGroup.MapGet("/patient/{id}", GetPatient);
            surgeryGroup.MapPost("/patientAdd", AddPatient);
            surgeryGroup.MapGet("/doctors", GetDoctors);
            surgeryGroup.MapGet("/doctor/{id}", GetDoctor);
            surgeryGroup.MapPost("/doctorAdd", AddDoctor);
            surgeryGroup.MapGet("/appointments", GetAppointments);
            surgeryGroup.MapGet("/appointmentsbydoctor/{id}", GetAppointmentsByDoctor);
            surgeryGroup.MapGet("/appointmentsbypatient/{id}", GetAppointmentsByPatient);
            surgeryGroup.MapGet("/appointment/{id}", GetAppointmentById);
            surgeryGroup.MapPost("/appointmentAdd", AddAppointment);

        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetPatients(IRepository repository)
        {
            var result = await repository.GetPatients();
            var resultsDTO = result.Select(p => new PatientListDTO
            {
                Id = p.Id,
                FullName = p.FullName,
                Appointments = p.Appointments.Select(a => new AppointmentPatientListDTO
                {
                    id = a.id,
                    Booking = a.Booking,
                    DoctorId = a.DoctorId,
                    AppointmentType = a.AppointmentType,
                    Doctor = new DoctorDTO
                    {
                        Id = a.Doctor.Id,
                        FullName = a.Doctor.FullName
                    }

                }).ToList()
            });
            return TypedResults.Ok(resultsDTO);
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> GetPatient(IRepository repository, int id)
        {
            var patient = await repository.GetPatientById(id);
            if (patient == null)
            {
                return TypedResults.NotFound("No Patient");
            }
            var patientDTO = new PatientListDTO
            {
                Id = patient.Id,
                FullName = patient.FullName,
                Appointments = patient.Appointments.Select(a => new AppointmentPatientListDTO
                {
                    id = a.id,
                    Booking = a.Booking,
                    DoctorId = a.DoctorId,
                    AppointmentType = a.AppointmentType,
                    Doctor = new DoctorDTO
                    {
                        Id = a.Doctor.Id,
                        FullName = a.Doctor.FullName                        
                    }

                }).ToList()
            };
            return TypedResults.Ok(patientDTO);
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        private static async Task<IResult> AddPatient(IRepository repository, PatientPost model)
        {
            try
            {
                Patient patient = new Patient
                {
                    Id = model.id,
                    FullName = model.FullName
                };
                var result = await repository.AddPatient(patient);

                return TypedResults.Ok(result);
            }
            catch (Exception e)
            {
                return TypedResults.BadRequest(e);
            }
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetDoctors(IRepository repository)
        {
            var result = await repository.GetDoctors();
            var resultsDTO = result.Select(p => new DoctorListDTO
            {
                Id = p.Id,
                FullName = p.FullName,
                Appointments = p.Appointments.Select(a => new AppointmentDoctorListDTO
                {
                    id = a.id,
                    Booking = a.Booking,
                    DoctorId = a.DoctorId,
                    AppointmentType = a.AppointmentType,
                    Patient = new PatientDTO
                    {
                        Id = a.Patient.Id,
                        FullName = a.Patient.FullName
                    }

                }).ToList()
            });
            return TypedResults.Ok(resultsDTO);
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> GetDoctor(IRepository repository, int id)
        {
            var doctor = await repository.GetDoctorById(id);
            if (doctor == null)
            {
                return TypedResults.NotFound("No Doctor");
            }
            var doctorDTO = new DoctorListDTO
            {
                Id = doctor.Id,
                FullName = doctor.FullName,
                Appointments = doctor.Appointments.Select(a => new AppointmentDoctorListDTO
                {
                    id = a.id,
                    Booking = a.Booking,
                    DoctorId = a.DoctorId,
                    AppointmentType = a.AppointmentType,
                    Patient = new PatientDTO
                    {
                        Id = a.Patient.Id,
                        FullName = a.Patient.FullName
                    }

                }).ToList()
            };
            return TypedResults.Ok(doctorDTO);
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        private static async Task<IResult> AddDoctor(IRepository repository, DoctorPost model)
        {
            try
            {
                Doctor doctor = new Doctor
                {
                    Id = model.id,
                    FullName = model.FullName
                };
                var result = await repository.AddDoctor(doctor);

                return TypedResults.Ok(result);
            }
            catch (Exception e)
            {
                return TypedResults.BadRequest(e);
            }
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetAppointmentById(IRepository repository, int id)
        {
            var appointment = await repository.GetAppointmentsById(id);
            var appointmentDTO = new AppointmentDTO
            {
                id = appointment.id,
                Booking = appointment.Booking,
                DoctorId = appointment.DoctorId,
                PatientId = appointment.PatientId,
                AppointmentType = appointment.AppointmentType,

                Doctor = new DoctorDTO
                {
                    Id = appointment.Doctor.Id,
                    FullName = appointment.Doctor.FullName
                },
                Patient = new PatientDTO
                {
                    Id = appointment.Patient.Id,
                    FullName = appointment.Patient.FullName
                }

            };
            return TypedResults.Ok(appointmentDTO);
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetAppointmentsByDoctor(IRepository repository, int id)
        {
            var appointment = await repository.GetAppointmentsByDoctor(id);
            var appointmentDTO = appointment.Select(a => new AppointmentDTO
            {
                id = a.id,
                Booking = a.Booking,
                DoctorId = a.DoctorId,
                PatientId = a.PatientId,
                AppointmentType = a.AppointmentType,
                Doctor = new DoctorDTO
                {
                    Id = a.Doctor.Id,
                    FullName = a.Doctor.FullName
                },
                Patient = new PatientDTO
                {
                    Id = a.Patient.Id,
                    FullName = a.Patient.FullName
                }

            });
            return TypedResults.Ok(appointmentDTO);
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetAppointmentsByPatient(IRepository repository, int id)
        {
            var appointment = await repository.GetAppointmentsByPatient(id);
            var appointmentDTO = appointment.Select(a => new AppointmentDTO
            {
                id = a.id,
                Booking = a.Booking,
                DoctorId = a.DoctorId,
                PatientId = a.PatientId,
                AppointmentType = a.AppointmentType,
                Doctor = new DoctorDTO
                {
                    Id = a.Doctor.Id,
                    FullName = a.Doctor.FullName
                },
                Patient = new PatientDTO
                {
                    Id = a.Patient.Id,
                    FullName = a.Patient.FullName
                }

            });
            return TypedResults.Ok(appointmentDTO);
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetAppointments(IRepository repository)
        {
            var appointment = await repository.GetAppointments();
            var appointmentDTO = appointment.Select(a => new AppointmentDTO
            {
                id = a.id,
                Booking = a.Booking,
                DoctorId = a.DoctorId,
                PatientId = a.PatientId,
                AppointmentType = a.AppointmentType,
                Doctor = new DoctorDTO
                {
                    Id = a.Doctor.Id,
                    FullName = a.Doctor.FullName
                },
                Patient = new PatientDTO
                {
                    Id = a.Patient.Id,
                    FullName = a.Patient.FullName
                }

            });
            return TypedResults.Ok(appointmentDTO);
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        private static async Task<IResult> AddAppointment(IRepository repository, AppointmentPost model)
        {
            try
            {
                Appointment appointment = new Appointment
                {
                    id = model.id,
                    Booking = model.Booking,
                    DoctorId = model.DoctorId,
                    PatientId = model.PatientId,
                    AppointmentType = model.AppointmentType
                };
                var result = await repository.AddAppointment(appointment);
                var resulted = new AppointmentDTO
                {
                    id = result.id,
                    Booking = result.Booking,
                    DoctorId = result.DoctorId,
                    PatientId = result.PatientId,
                    AppointmentType = result.AppointmentType,
                    Doctor = new DoctorDTO
                    {
                        Id = result.Doctor.Id,
                        FullName = result.Doctor.FullName
                    },
                    Patient = new PatientDTO
                    {
                        Id = result.Patient.Id,
                        FullName = result.Patient.FullName
                    }
                };

                return TypedResults.Ok(resulted);
            }
            catch (Exception e)
            {
                return TypedResults.BadRequest(e);
            }
        }
    }
}
