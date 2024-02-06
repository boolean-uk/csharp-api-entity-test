using Microsoft.AspNetCore.Mvc;
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
            var patientGroup = app.MapGroup("patients");

            patientGroup.MapGet("/", GetPatients);
            patientGroup.MapGet("/{id}", GetPatientsById);
            patientGroup.MapPost("/create", CreatePatient);
            surgeryGroup.MapGet("/doctors", GetDoctors);
            surgeryGroup.MapGet("/doctors/{id}", GetDoctorById);
            surgeryGroup.MapPost("/doctors/create", CreateDoctor);
            surgeryGroup.MapGet("/appointmentsbydoctor/{doctorId}", GetAppointmentsByDoctor);
            patientGroup.MapGet("/{id}/appointments", GetAppointmentsByPatient);
            surgeryGroup.MapGet("/appointments", GetAppointments);
            surgeryGroup.MapGet("/appointments/{doctorId}:{patientId}", GetAppointmentsId);
            surgeryGroup.MapPost("appointments/create", CreateAppointment);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetPatients(IRepository repository)
        {
            var data = await repository.GetPatients();
            var patients = from patient in data
                           select new PatientDTO()
                           {
                               Id = patient.Id,
                               Name = $"{patient.FirstName} {patient.LastName}",
                           };
            
            return TypedResults.Ok(patients);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> GetPatientsById(IRepository repository, int id)
        {
            var patient = await repository.GetPatientById(id);
            if(patient == null)
            {
                return TypedResults.NotFound();
            }
            var result = new PatientDTO()
            {
                Id = patient.Id,
                Name = $"{patient.FirstName} {patient.LastName}",
            };
            
            return TypedResults.Ok(result);
        }
        
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public static async Task<IResult> CreatePatient(IRepository repository, PostPatient model)
        {
            if(model.FirstName.Length == 0 || model.LastName.Length == 0)
            {
                return TypedResults.BadRequest();
            }
            var patient = await repository.CreatePatient(model);
            var result = new PatientDTO()
            {
                Id = patient.Id,
                Name = $"{patient.FirstName} {patient.LastName}",
            };

            return TypedResults.Ok(result);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetDoctors(IRepository repository)
        {
            var data = await repository.GetDoctors();
            var doctors = from doctor in data
                           select new DoctorDTO()
                           {
                               Id = doctor.Id,
                               Name = $"{doctor.FirstName} {doctor.LastName}",
                           };
            return TypedResults.Ok(doctors);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> GetDoctorById(IRepository repo, int id)
        {
            var doctor = await repo.GetDoctorById(id);
            if (doctor == null )
            {
                return TypedResults.NotFound();
            }
            var result = new DoctorDTO()
            {
                Id = doctor.Id,
                Name = $"{doctor.FirstName} {doctor.LastName}"
            };

            return TypedResults.Ok(result);

        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public static async Task<IResult> CreateDoctor(IRepository repository, PostDoctor model)
        {
            if (model.FirstName.Length == 0 || model.LastName.Length == 0)
            {
                return TypedResults.BadRequest();
            }
            var doctor = await repository.CreateDoctor(model);
            var result = new DoctorDTO()
            {
                Id = doctor.Id,
                Name = $"{doctor.FirstName} {doctor.LastName}",
            };

            return TypedResults.Ok(result);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetAppointments(IRepository repository)
        {
            var data = await repository.GetAppointments();
            var apps = from app in data
                          select new AppointmentDTO()
                          {
                              PatientId = app.PatientId,
                              DoctorId = app.DoctorId,
                              Booking = app.Booking,
                              PatientName = $"{app.Patient.FirstName} {app.Patient.LastName}",
                              DoctorName = $"{app.Doctor.FirstName} {app.Doctor.LastName}"

                          };
            return TypedResults.Ok(apps);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> GetAppointmentsId(IRepository repository, int doctorId, int patientId)
        {
            var app = await repository.GetAppointmentById(doctorId, patientId);
            if (app == null)
            {
                return TypedResults.NotFound();
            }
            var result = new AppointmentDTO()
            {
                PatientId = app.PatientId,
                DoctorId = app.DoctorId,
                Booking = app.Booking,
                PatientName = $"{app.Patient.FirstName} {app.Patient.LastName}",
                DoctorName = $"{app.Doctor.FirstName} {app.Doctor.LastName}"
            };

            return TypedResults.Ok(result);
        }


        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public static async Task<IResult> GetAppointmentsByDoctor(IRepository repository, int id)
        {
            var apps = await repository.GetAppointmentsByDoctor(id);
            if (apps == null)
            {
                return TypedResults.NotFound();
            }
            var appointmentDTOs = from app in apps
                                                   select new AppointmentDTO()
                                                   {
                                                       PatientId = app.PatientId,
                                                       DoctorId = app.DoctorId,
                                                       Booking = app.Booking,
                                                       PatientName = $"{app.Patient.FirstName} {app.Patient.LastName}",
                                                       DoctorName = $"{app.Doctor.FirstName} {app.Doctor.LastName}"
                                                   };

            return TypedResults.Ok(appointmentDTOs);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public static async Task<IResult> GetAppointmentsByPatient(IRepository repository, int id)
        {
            var apps = await repository.GetAppointmentsByPatient(id);
            if (apps == null)
            {
                return TypedResults.NotFound();
            }
            var appointmentDTOs = from app in apps
                                  select new AppointmentDTO()
                                  {
                                      PatientId = app.PatientId,
                                      DoctorId = app.DoctorId,
                                      Booking = app.Booking,
                                      PatientName = $"{app.Patient.FirstName} {app.Patient.LastName}",
                                      DoctorName = $"{app.Doctor.FirstName} {app.Doctor.LastName}"
                                  };

            return TypedResults.Ok(appointmentDTOs);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public static async Task<IResult> CreateAppointment(IRepository repository, PostAppointment model)
        {

            var app = await repository.CreateAppointment(model);
            if(app == null) { 
                return TypedResults.BadRequest("Appointment between this patient and doctor already exists"); 
            }
            var result = new AppointmentDTO()
            {
                DoctorId = app.DoctorId,
                PatientId = app.PatientId,
                Booking = app.Booking,
                PatientName = $"{app.Patient.FirstName} {app.Patient.LastName}",
                DoctorName = $"{app.Doctor.FirstName} {app.Doctor.LastName}",  
            };

            return TypedResults.Ok(result);
        }
    }
}
