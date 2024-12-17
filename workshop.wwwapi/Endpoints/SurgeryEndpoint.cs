using Microsoft.AspNetCore.Mvc;
using workshop.wwwapi.Dtoes.AppointmentDtos;
using workshop.wwwapi.Dtoes.DoctorDtos;
using workshop.wwwapi.Dtoes.PatientDtos;
using workshop.wwwapi.Dtoes.ViewModels;
using workshop.wwwapi.Models;
using workshop.wwwapi.Repository;

namespace workshop.wwwapi.Endpoints
{
    public static class SurgeryEndpoint
    {
        public static string error404 = "Does not exist";
        public static string error400 = "Bad request";
        //TODO:  add additional endpoints in here according to the requirements in the README.md 
        public static void ConfigurePatientEndpoint(this WebApplication app)
        {
            var surgeryGroup = app.MapGroup("surgery");

            surgeryGroup.MapGet("/patients", GetPatients);
            surgeryGroup.MapGet("/patients/{id:int}", GetSinglePatient);
            surgeryGroup.MapPost("/patients", CreatePatient);

            surgeryGroup.MapGet("/doctors", GetDoctors);
            surgeryGroup.MapGet("/doctors/{id:int}", GetSingleDoctor);
            surgeryGroup.MapPost("/doctors", CreateDoctor);

            surgeryGroup.MapGet("/appointmentsByDoctor/{doctorid:int}", GetAppointmentsByDoctor);
            surgeryGroup.MapGet("/appointmentsByPatient/{patientid:int}", GetAppointmentsByPatient);
            surgeryGroup.MapGet("/appointments/{patientid:int}/{doctorid:int}", GetSingleAppointment);
            surgeryGroup.MapPost("/appointments", CreateAppointment);
            surgeryGroup.MapPost("/appointments/prescription/{patientId:int}/{doctorId:int}/{prescriptionid:int}", AttachPrescriptionToAppointment);
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetPatients(IRepository repository)
        {
            var patients = await repository.GetPatients();
            List<PatientDto> patientDtos = new List<PatientDto>();
            foreach(Patient p in patients)
            {
                patientDtos.Add(new PatientDto(p));
            }
            return TypedResults.Ok(patientDtos);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public static async Task<IResult> GetSinglePatient(IRepository repository, int id)
        {
            Patient patient = await repository.GetSinglePatient(id);
            if(patient == null)
            {
                return TypedResults.NotFound(error404);
            }

            PatientDto patientDto = new PatientDto(patient);
            return TypedResults.Ok(patientDto);
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        public static async Task<IResult> CreatePatient(IRepository repository, PatientPostModel model)
        {
            Patient patient = new Patient();
            patient.FirstName = model.FirstName;
            patient.LastName = model.LastName;
            await repository.CreatePatient(patient);
            return TypedResults.Created("", patient);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetDoctors(IRepository repository)
        {
            var doctors = await repository.GetDoctors();
            List<DoctorDto> doctorDtos = new List<DoctorDto>();
            foreach(Doctor d in doctors)
            {
                doctorDtos.Add(new DoctorDto(d));
            }
            return TypedResults.Ok(doctorDtos);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> GetSingleDoctor(IRepository repository, int id)
        {
            Doctor doctor = await repository.GetSingleDoctor(id);
            if(doctor == null)
            {
                return TypedResults.NotFound(error404);
            }
            DoctorDto doctorDto = new DoctorDto(doctor);
            return TypedResults.Ok(doctorDto);
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public static async Task<IResult> CreateDoctor(IRepository repository, DoctorPostModel model)
        {
            try
            {
                Doctor doctor = new Doctor();
                doctor.FullName = model.Fullname;
                doctor = await repository.CreateDoctor(doctor);

                DoctorDto doctorDto = new DoctorDto(doctor);
                return TypedResults.Created("", doctorDto);
            }
            catch
            {
                return TypedResults.BadRequest(error400);
            }
        }
        [ProducesResponseType(StatusCodes.Status200OK)]

        public static async Task<IResult> GetAppointmentsByDoctor(IRepository repository, int doctorid)
        {
            var appointments = await repository.GetAppointmentsByDoctor(doctorid);
            List<AppointmentDto> appointmentDtos = new List<AppointmentDto>();

            foreach(Appointment a in appointments)
            {
                AppointmentDto appointmentDto = new AppointmentDto(a);
                appointmentDto.PatientName = a.Patient.FirstName + " " + a.Patient.LastName;
                appointmentDto.DoctorName = a.Doctor.FullName;
                appointmentDto.PrescriptionId = a.PrescriptionId;
                appointmentDtos.Add(appointmentDto);
            }
            return TypedResults.Ok(appointmentDtos);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]

        public static async Task<IResult> GetAppointmentsByPatient(IRepository repository, int patientid)
        {
            var appointments = await repository.GetAppointmentsByPatient(patientid);
            List<AppointmentDto> appointmentDtos = new List<AppointmentDto>();
            foreach(Appointment a in appointments)
            {
                AppointmentDto appointmentDto = new AppointmentDto(a);
                appointmentDto.PatientName = a.Patient.FirstName + " " + a.Patient.LastName;
                appointmentDto.DoctorName = a.Doctor.FullName;
                appointmentDto.PrescriptionId = a.PrescriptionId;
                appointmentDtos.Add(appointmentDto);
            }
            return TypedResults.Ok(appointmentDtos);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> GetSingleAppointment(IRepository repository, int patientid, int doctorid)
        {
            Appointment appointment = await repository.GetSingleAppointment(doctorid, patientid);
            if (appointment == null)
            {
                return TypedResults.NotFound(error404);
            }

            AppointmentDto appointmentDto = new AppointmentDto(appointment);
            return TypedResults.Ok(appointmentDto);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public static async Task<IResult> CreateAppointment(IRepository repository, int patientId, int doctorId)
        {
            try
            {
                Appointment appointment = new Appointment();
                Doctor doctor = await repository.GetSingleDoctor(doctorId);
                Patient patient = await repository.GetSinglePatient(patientId);
                if(doctor == null || patient == null)
                {
                    return TypedResults.NotFound(error404);
                }

                appointment.Booking = DateTime.UtcNow;
                appointment.DoctorId = doctorId;
                appointment.PatientId = patientId;

                appointment = await repository.CreateAppointment(appointment);
                AppointmentDto appointmentDto = new AppointmentDto(appointment);
                appointmentDto.PatientName = appointment.Patient.FirstName + " " + appointment.Patient.LastName;
                appointmentDto.DoctorName = appointment.Doctor.FullName;

                return TypedResults.Ok(appointmentDto);
            }
            catch(Exception ex)
            {
                return TypedResults.BadRequest(ex.Message);
            }
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public static async Task<IResult> AttachPrescriptionToAppointment(IRepository repository, int doctorId, int patientId, int prescriptionId)
        {
            try
            {
                Appointment appointment = await repository.GetSingleAppointment(doctorId, patientId);
                if(appointment == null)
                {
                    return TypedResults.NotFound(error404);
                }
                appointment.PrescriptionId = prescriptionId;
                await repository.UpdateAppointment(appointment);

                AppointmentDto appointmentDto = new AppointmentDto(appointment);
                appointmentDto.PatientName = appointment.Patient.FirstName + " " + appointment.Patient.LastName;
                appointmentDto.DoctorName = appointment.Doctor.FullName;
                appointmentDto.PrescriptionId = appointment.PrescriptionId;

                return TypedResults.Ok(appointmentDto);
            }
            catch(Exception ex)
            {
                return TypedResults.BadRequest(ex.Message);
            }
            

        }
    }
}
