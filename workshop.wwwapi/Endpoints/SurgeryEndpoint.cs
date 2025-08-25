using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using workshop.wwwapi.DTOs.AppointmentGets;
using workshop.wwwapi.DTOs.Posts;
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

            surgeryGroup.MapGet("/getpatient", GetPatients);
            surgeryGroup.MapGet("/getonepatient/{id}", GetOnePatient);
            surgeryGroup.MapPost("/createpatient", CreatePatient);

            surgeryGroup.MapGet("/getdoctor", GetDoctors);
            surgeryGroup.MapGet("/getonedoctor/{id}", GetOneDoctor);
            surgeryGroup.MapPost("/createdoctor", CreateDoctor);

            surgeryGroup.MapGet("/getappointment", GetAppointments);
            surgeryGroup.MapGet("/getbyidappointment/{id}", GetAppointmentsById);
            surgeryGroup.MapGet("/getbypatientappointment/{id}", GetAppointmentsByPatient);
            surgeryGroup.MapGet("/getbydoctirappointment/{id}", GetAppointmentsByDoctor);
            surgeryGroup.MapPost("/createappointment", Createappointment);
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetPatients(IRepository repository)
        {
            var results = await repository.GetPatients();

            List<Object> response = new List<object>();

            foreach (var item in results)
            {
                var resultAppointments = item.Appointments;
                List<PatientAppointmentGet> appointments = new List<PatientAppointmentGet>();
                foreach (var thing in resultAppointments)
                {
                    PatientAppointmentGet appointment = new PatientAppointmentGet()
                    {
                        Id = thing.Id,
                        Booking = thing.Booking,
                        DoctorId = thing.PatientId,
                        Doctor = new PatientDoctorGet() { Id = thing.Doctor.Id, FullName = thing.Doctor.FullName }
                    };
                    appointments.Add(appointment);
                }
                PatientGet patient = new PatientGet()
                {
                    Id = item.Id,
                    FullName = item.FullName,
                    Appointments = appointments
                };
                response.Add(patient);
            }
            return TypedResults.Ok(response);

        }
        public static async Task<IResult> GetOnePatient(IRepository repository, int id)
        {
            var result = await repository.GetOnePatient(id);

            List<PatientAppointmentGet> appointments = new List<PatientAppointmentGet>();

            foreach (var item in result.Appointments)
            {
                PatientAppointmentGet appointment = new PatientAppointmentGet()
                {
                    Id = item.Id,
                    Booking = item.Booking,
                    DoctorId = item.PatientId,
                    Doctor = new PatientDoctorGet() { Id = item.Doctor.Id, FullName = item.Doctor.FullName }
                };
                appointments.Add(appointment);

            }
            PatientGet patient = new PatientGet()
            {
                Id = result.Id,
                FullName = result.FullName,
                Appointments = appointments
            };
            

            return TypedResults.Ok(patient);

        }
        public static async Task<IResult> CreatePatient(IRepository repository, PatientPost model)
        {
            try
            {                
                Patient patient = new Patient()
                    {
                        FullName = model.FullName
                    };
                    await repository.CreatePatient(patient);

                    return TypedResults.Created($"https://localhost:7235/surgery", patient);

            }
            catch (Exception)
            {

                return TypedResults.BadRequest();
            }
        }


        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetDoctors(IRepository repository)
        {
            var results = await repository.GetDoctors();
            
            List<Object> response = new List<object>();

            foreach (var item in results)
            {
                var resultAppointments = item.Appointments;
                List<DoctorAppointmentGet> appointments = new List<DoctorAppointmentGet>();
                foreach (var thing in resultAppointments)
                {
                    DoctorAppointmentGet appointment = new DoctorAppointmentGet()
                    {
                        Id = thing.Id,
                        Booking = thing.Booking,
                        PatientId = thing.PatientId,
                        Patient = new DoctorPatientGet() { Id=thing.Patient.Id, FullName=thing.Patient.FullName}
                    };
                    appointments.Add(appointment);
                }
                DoctorGet doctor = new DoctorGet()
                {
                    Id = item.Id,
                    FullName = item.FullName,
                    Appointments = appointments
                };
                response.Add(doctor);
            }
            return TypedResults.Ok(response);
            
        }
        public static async Task<IResult> GetOneDoctor(IRepository repository, int id)
        {
            var result = await repository.GetOneDoctor(id);

            List<DoctorAppointmentGet> appointments = new List<DoctorAppointmentGet>();

            foreach (var item in result.Appointments)
            {
                DoctorAppointmentGet appointment = new DoctorAppointmentGet()
                {
                    Id = item.Id,
                    Booking = item.Booking,
                    PatientId = item.PatientId,
                    Patient = new DoctorPatientGet() { Id = item.Patient.Id, FullName = item.Patient.FullName }
                };
                appointments.Add(appointment);

            }
            DoctorGet doctor = new DoctorGet()
            {
                Id = result.Id,
                FullName = result.FullName,
                Appointments = appointments
            };


            return TypedResults.Ok(doctor);
        }
        public static async Task<IResult> CreateDoctor(IRepository repository, DoctorPost model)
        {
            try
            {

                Doctor doctor = new Doctor()
                    {
                        FullName = model.FullName   

                    };
                    await repository.CreateDoctor(doctor);

                    return TypedResults.Created($"https://localhost:7235/surgery/", doctor);

            }
            catch (Exception)
            {

                return TypedResults.BadRequest();
            }
        }
        


        public static async Task<IResult> GetAppointments(IRepository repository)
        {
            var results = await repository.GetAppointments();

            List<Object> response = new List<object>();

            foreach (var item in results)
            {
                AppointmentGet appointment = new AppointmentGet()
                {
                    Id = item.Id,
                    Booking = item.Booking,
                    DoctorId = item.DoctorId,
                    Doctor = new AppointmentDoctorGet() { Id =  item.Doctor.Id , FullName = item.Doctor.FullName},
                    PatientId = item.PatientId,
                    Patient = new AppointmentPatientGet() { Id = item.Patient.Id, FullName = item.Patient.FullName}
                };
                response.Add(appointment);
            }
            return TypedResults.Ok(response);
        }
        public static async Task<IResult> GetAppointmentsById(IRepository repository, int id)
        {
            var result = await repository.GetAppointmentById(id);

            AppointmentGet appointment = new AppointmentGet()
            {
                Id = result.Id,
                Booking = result.Booking,
                DoctorId = result.DoctorId,
                Doctor = new AppointmentDoctorGet() { Id = result.Doctor.Id, FullName = result.Doctor.FullName },
                PatientId = result.PatientId,
                Patient = new AppointmentPatientGet() { Id = result.Patient.Id, FullName = result.Patient.FullName }
            };
                
            return TypedResults.Ok(appointment);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetAppointmentsByPatient(IRepository repository, int id)
        {
            var results = await repository.GetAppointmentsByPatient(id);

            List<Object> response = new List<object>();

            foreach (var item in results)
            {
                AppointmentGet appointment = new AppointmentGet()
                {
                    Id = item.Id,
                    Booking = item.Booking,
                    DoctorId = item.DoctorId,
                    Doctor = new AppointmentDoctorGet() { Id = item.Doctor.Id, FullName = item.Doctor.FullName },
                    PatientId = item.PatientId,
                    Patient = new AppointmentPatientGet() { Id = item.Patient.Id, FullName = item.Patient.FullName }
                };
                response.Add(appointment);
            }
            return TypedResults.Ok(response);
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetAppointmentsByDoctor(IRepository repository, int id)
        {
            var results = await repository.GetAppointmentsByDoctor(id);

            List<Object> response = new List<object>();

            foreach (var item in results)
            {
                AppointmentGet appointment = new AppointmentGet()
                {
                    Id = item.Id,
                    Booking = item.Booking,
                    DoctorId = item.DoctorId,
                    Doctor = new AppointmentDoctorGet() { Id = item.Doctor.Id, FullName = item.Doctor.FullName },
                    PatientId = item.PatientId,
                    Patient = new AppointmentPatientGet() { Id = item.Patient.Id, FullName = item.Patient.FullName }
                };
                response.Add(appointment);
            }
            return TypedResults.Ok(response);
        }
        public static async Task<IResult> Createappointment(IRepository repository, AppointmentPost model)
        {
            try
            {
                Doctor doctor = await repository.GetOneDoctor(model.DoctorId);
                Patient patient = await repository.GetOnePatient(model.PatientId);
                if (doctor != null && patient != null)
                {


                    Appointment appointment = new Appointment()
                    {

                        Booking = DateTime.UtcNow,
                        DoctorId = model.DoctorId,
                        //Doctor = doctor,
                        PatientId = model.PatientId,
                        //Patient = patient
                    };
                    await repository.CreateAppointment(appointment);

                    return TypedResults.Created($"", new { Id = appointment.Id, Booking = appointment.Booking, DoctorId = appointment.DoctorId, PatientId = appointment.PatientId });
                }
                else
                {
                    return TypedResults.NotFound();
                }

            }
            catch (Exception)
            {

                return TypedResults.BadRequest();
            }
        }
        
    }
}
