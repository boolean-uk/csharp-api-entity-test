using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System.Diagnostics.Eventing.Reader;
using System.IO;
using workshop.wwwapi.DTOs.AppointmentDTOs;
using workshop.wwwapi.DTOs.DoctorDTOs;
using workshop.wwwapi.DTOs.PatientDTOs;
using workshop.wwwapi.DTOs.Payload;
using workshop.wwwapi.Repository;

namespace workshop.wwwapi.Endpoints
{
    public static class SurgeryEndpoint
    {
        //TODO:  add additional endpoints in here according to the requirements in the README.md 
        public static void ConfigurePatientEndpoint(this WebApplication app)
        {
            var surgeryGroup = app.MapGroup("surgery");

            //Patient API
            surgeryGroup.MapGet("/patients", GetPatients);
            surgeryGroup.MapGet("/patient{id}", GetPatientById);
            surgeryGroup.MapPost("/patient", CreatePatient);
            //Doctor API
            surgeryGroup.MapGet("/doctors", GetDoctors);
            surgeryGroup.MapGet("/doctors/{id}", GetDoctorById);
            surgeryGroup.MapPost("/doctors", CreateDoctor);
            //Appointment API
            surgeryGroup.MapGet("/appointments", GetAppointments);
            surgeryGroup.MapGet("/appointments/{id}", GetAppointmentById);
            surgeryGroup.MapPost("/appointments", CreateAppointment);
            surgeryGroup.MapGet("/appointmentsbydoctor/{id}", GetAppointmentsByDoctor);
            surgeryGroup.MapGet("/appointmentsbypatient/{id}", GetAppointmentsByPatient);
            surgeryGroup.MapGet("/appointmentsbyids/{docID},{patID}", GetAppointmentById);
        }
        /*
         * PATIENT METHODS FROM HERE
         */
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetPatients(IRepository repository)
        { 
            var result = await repository.GetPatients();

            List<PatientDTO> patients = new List<PatientDTO>();

            foreach(var patient in result)
            {
                var patientDTO = new PatientDTO()
                {
                    Id = patient.Id,
                    FullName = patient.FullName,
                    Appointments = new List<AppointmentDoctorDTO>()
                };
                foreach(var appointment in  patient.Appointments)
                {
                    var appointmentDTO = new AppointmentDoctorDTO()
                    {
                        Booking = appointment.Booking,
                        DoctorId = appointment.DoctorId,
                        Doctor = new DTOs.DoctorDTOs.DoctorDTO()
                        {
                            FullName = appointment.Doctor.FullName,
                            Id = appointment.Doctor.Id
                        }
                    };
                    patientDTO.Appointments.Add(appointmentDTO);
                }
                patients.Add(patientDTO);
            }
            Payload<List<PatientDTO>> payload = new Payload<List<PatientDTO>>();
            payload.data = patients;
            return TypedResults.Ok(payload);

        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetPatientById(IRepository repository, int id)
        {
            var results = await repository.GetPatientById(id);

            PatientDTO patient = new PatientDTO()
            {
                Id = id,
                FullName = results.FullName,
                Appointments = new List<AppointmentDoctorDTO>()
            };
            foreach (var appointment in patient.Appointments)
            {
                var appointmentDTO = new AppointmentDoctorDTO()
                {
                    Booking = appointment.Booking,
                    DoctorId = appointment.DoctorId,
                    Doctor = new DTOs.DoctorDTOs.DoctorDTO()
                    {
                        FullName = appointment.Doctor.FullName,
                        Id = appointment.Doctor.Id
                    }
                };
                patient.Appointments.Add(appointmentDTO);
            };

            Payload<PatientDTO> payload = new Payload<PatientDTO>();
            payload.data = patient; 
            return TypedResults.Ok(payload);
        }


        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> CreatePatient(IRepository repository, string name)
        {
            var result = await repository.CreatePatient(name);

            PatientDTO resultPatient = new PatientDTO()
            {
                Id = result.Id,
                FullName = result.FullName
            };

            return result == null ? Results.BadRequest() : TypedResults.Created($"{resultPatient.FullName}", resultPatient);
        }

        /*
         * DOCTOR METHODS FROM HERE
         */
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetDoctors(IRepository repository)
        {
            var result = await repository.GetDoctors();

            List<DoctorDTO> doctors = new List<DoctorDTO>();

            foreach (var doctor in result)
            {
                var doctorDTO = new DoctorDTO()
                {
                    Id = doctor.Id,
                    FullName = doctor.FullName,
                    Appointments = new List<AppointmentPatientDTO>()
                };
                foreach (var appointment in doctor.Appointments)
                {
                    var appointmentDTO = new AppointmentPatientDTO()
                    {
                        Booking = appointment.Booking,
                        PatientId = appointment.PatientId,
                        Patient = new DTOs.PatientDTOs.PatientDTO()
                        {
                            FullName = appointment.Patient.FullName,
                            Id = appointment.Patient.Id
                        }
                    };
                    doctorDTO.Appointments.Add(appointmentDTO);
                }
                doctors.Add(doctorDTO);
            }
            Payload<List<DoctorDTO>> payload = new Payload<List<DoctorDTO>>();
            payload.data = doctors;
            return TypedResults.Ok(payload);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetDoctorById(IRepository repository, int id)
        {
            var results = await repository.GetDoctorById(id);

            DoctorDTO doctor = new DoctorDTO()
            {
                Id = id,
                FullName = results.FullName,
                Appointments = new List<AppointmentPatientDTO>()
            };
            foreach (var appointment in doctor.Appointments)
            {
                var appointmentDTO = new AppointmentPatientDTO()
                {
                    Booking = appointment.Booking,
                    PatientId = appointment.PatientId,
                    Patient = new DTOs.PatientDTOs.PatientDTO()
                    {
                        FullName = appointment.Patient.FullName,
                        Id = appointment.Patient.Id
                    }
                };
                doctor.Appointments.Add(appointmentDTO);
            };

            Payload<DoctorDTO> payload = new Payload<DoctorDTO>();
            payload.data = doctor;
            return TypedResults.Ok(payload);
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        public static async Task<IResult> CreateDoctor(IRepository repository, string name)
        {
            var result = await repository.CreateDoctor(name);

            DoctorDTO resultDoctor = new DoctorDTO()
            {
                Id = result.Id,
                FullName = result.FullName
            };

            return result == null ? Results.BadRequest() : TypedResults.Created($"{resultDoctor.FullName}", resultDoctor);
        }
        /*
         * APPOINTMENT METHODS FROM HERE
         */
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetAppointments(IRepository repository)
        {
            var result = await repository.GetAppointments();

            List<AppointmentDTO> appointments = new List<AppointmentDTO>();

            foreach (var appointment in result)
            {
                var appointmentDTO = new AppointmentDTO()
                {
                    PatientId = appointment.Patient.Id,
                    DoctorId = appointment.Doctor.Id,
                    Patient = new PatientDTO2()
                    {
                        Id = appointment.Patient.Id,
                        FullName = appointment.Patient.FullName
                    },
                    Doctor = new DoctorDTO2()
                    {
                        Id = appointment.Doctor.Id,
                        FullName = appointment.Patient.FullName
                    }
                };
                appointments.Add(appointmentDTO);
            }
            Payload<List<AppointmentDTO>> payload = new Payload<List<AppointmentDTO>>();
            payload.data = appointments;
            return TypedResults.Ok(payload);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetAppointmentById (IRepository repository, int docID, int patID)
        {
            var result = await repository.GetAppointmentById(docID, patID);

            List<AppointmentDTO> appointments = new List<AppointmentDTO>();

            foreach (var appointment in result)
            {
                var appointmentDTO = new AppointmentDTO()
                {
                    PatientId = appointment.Patient.Id,
                    DoctorId = appointment.Doctor.Id,
                    Patient = new PatientDTO2()
                    {
                        Id = appointment.Patient.Id,
                        FullName = appointment.Patient.FullName
                    },
                    Doctor = new DoctorDTO2()
                    {
                        Id = appointment.Doctor.Id,
                        FullName = appointment.Doctor.FullName
                    }
                };
                appointments.Add(appointmentDTO);
            }
            Payload<List<AppointmentDTO>> payload = new Payload<List<AppointmentDTO>>();
            payload.data = appointments;
            return TypedResults.Ok(payload);
        }
        [ProducesResponseType(StatusCodes.Status201Created)]
        public static async Task<IResult> CreateAppointment(IRepository repository, int docID, int patID)
        {
            var result = await repository.CreateAppointment(docID, patID);
            AppointmentDTO appointmentDTO = new AppointmentDTO()
            {
                PatientId = patID,
                DoctorId = docID,
            };
            return result == null ? Results.BadRequest() : TypedResults.Created($"{appointmentDTO.Booking}");
        }


        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetAppointmentsByDoctor(IRepository repository, int id)
        {
            var result = await repository.GetAppointmentsByDoctor(id);

            List<AppointmentDTO> appointments = new List<AppointmentDTO>();

            foreach (var appointment in result)
            {
                var appointmentDTO = new AppointmentDTO()
                {
                    PatientId = appointment.Patient.Id,
                    DoctorId = appointment.Doctor.Id,
                    Patient = new PatientDTO2()
                    {
                        Id = appointment.Patient.Id,
                        FullName = appointment.Patient.FullName
                    },
                    Doctor = new DoctorDTO2()
                    {
                        Id = appointment.Doctor.Id,
                        FullName = appointment.Doctor.FullName
                    }
                };
                appointments.Add(appointmentDTO);
            }
            Payload<List<AppointmentDTO>> payload = new Payload<List<AppointmentDTO>>();
            payload.data = appointments;
            return TypedResults.Ok(payload);
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetAppointmentsByPatient(IRepository repository, int id)
        {
            var result = await repository.GetAppointmentsByPatient(id);

            List<AppointmentDTO> appointments = new List<AppointmentDTO>();

            foreach (var appointment in result)
            {
                var appointmentDTO = new AppointmentDTO()
                {
                    PatientId = appointment.Patient.Id,
                    DoctorId = appointment.Doctor.Id,
                    Patient = new PatientDTO2()
                    {
                        Id = appointment.Patient.Id,
                        FullName = appointment.Patient.FullName
                    },
                    Doctor = new DoctorDTO2()
                    {
                        Id = appointment.Doctor.Id,
                        FullName = appointment.Doctor.FullName
                    }
                };
                appointments.Add(appointmentDTO);
            }
            Payload<List<AppointmentDTO>> payload = new Payload<List<AppointmentDTO>>();
            payload.data = appointments;
            return TypedResults.Ok(payload);
        }
    }
}
