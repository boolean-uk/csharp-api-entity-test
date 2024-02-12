using Microsoft.AspNetCore.Mvc;
using System.Numerics;
using workshop.wwwapi.Models.AppointmentModels;
using workshop.wwwapi.Models.AppointmentModels.DTO;
using workshop.wwwapi.Models.DoctorModels;
using workshop.wwwapi.Models.DoctorModels.DTO;
using workshop.wwwapi.Models.PatientModels;
using workshop.wwwapi.Models.PatientModels.DTO;
using workshop.wwwapi.Models.PrescriptionModels;
using workshop.wwwapi.Repository.ExtensionRepository;
using workshop.wwwapi.Repository.GenericRepository;

namespace workshop.wwwapi.Endpoints
{
    public static class SurgeryEndpoint
    {
        public static void ConfigureSurgeryEndpoint(this WebApplication app)
        {
            var surgeryGroup = app.MapGroup("surgery");
            surgeryGroup.MapGet("/prescriptions", GetPrescriptions);

            surgeryGroup.MapGet("/doctors", GetDoctors);
            surgeryGroup.MapGet("/doctors/{id}", GetDoctorById);
            surgeryGroup.MapPost("/doctors", CreateDoctor);

            surgeryGroup.MapGet("/patients", GetPatients);
            surgeryGroup.MapGet("/patients/{id}", GetPatientById);
            surgeryGroup.MapPost("/patients", CreatePatient);

            surgeryGroup.MapGet("/appointments", GetAppointments);
            surgeryGroup.MapPost("/appointments", CreateAppointment);
            surgeryGroup.MapGet("/appointments/{doctor_id, patient_id}", GetAppointmentsByPatientIdAndDoctorId);
        }

        private static async Task<IResult> GetPrescriptions(IRepository<Prescription> repo)
        {
            var prescriptions = await repo.Get();
            return TypedResults.Ok(prescriptions);
        }

        private static async Task<IResult> CreateDoctor(IRepository<Doctor> repo, PutDoctorDto putDoctor)
        {
            var doctor = new Doctor
            {
                FullName = putDoctor.Name,
            };

            doctor = await repo.Insert(doctor);
            var doctorDto = DoctorDoctorDto.Create(doctor);
            return TypedResults.Created($"/doctors/{doctorDto.DoctorId}", doctorDto);
        }
        private static async Task<IResult> CreateAppointment(IRepository<Appointment> appointmentRepo, IRepository<Doctor> doctorRepo, IRepository<Patient> patientRepo, PutAppointmentDto putAppointment)
        {
            var appointment = new Appointment
            {
                Booking = putAppointment.Booking,
                Doctor = await doctorRepo.GetById(putAppointment.DoctorId),
                Patient = await patientRepo.GetById(putAppointment.PatientId),
            };

            appointment = await appointmentRepo.Insert(appointment);
            var appointmentDto = AppointmentAppointmentDto.Create(appointment);
            return TypedResults.Created($"/appointments/{appointmentDto.Patient.PatientId}, {appointmentDto.Doctor.DoctorId}", appointmentDto);
        }

        private static async Task<IResult> CreatePatient(IRepository<Patient> repo, PutPatientDto putPatient)
        {
            var patient = new Patient
            {
                FullName = putPatient.Name
            };

            patient = await repo.Insert(patient);
            var patientDto = PatientPatientDto.Create(patient);
            return TypedResults.Created($"/patients/{patientDto.PatientId}", patientDto);
        }

        private static async Task<IResult> GetAppointments(IRepository<Appointment> repo)
        {
            var appointments = await repo.Get();
            var appointmentDtos = appointments.Select(AppointmentAppointmentDto.Create);
            return TypedResults.Ok(appointmentDtos);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetPatients(IRepository<Patient> repository)
        {
            var patients = await repository.Get();
            var patientDtos = patients.Select(PatientPatientDto.Create);
            return TypedResults.Ok(patientDtos);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetDoctors(IRepository<Doctor> doctorRepo, IRepository<Patient> patientRepo)
        {
            var doctors = await doctorRepo.Get();
            var patients = await patientRepo.Get();

            var doctorDtos = new List<DoctorDoctorDto>();
            foreach (var doctor in doctors)
            {
                doctorDtos.Add(DoctorDoctorDto.Create(doctor));
            }
            return TypedResults.Ok(doctorDtos);
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetDoctorById(IRepository<Doctor> repository, int id)
        {
            var doctor = await repository.GetById(id);
            var doctorDto = DoctorDoctorDto.Create(doctor);
            return TypedResults.Ok(doctorDto);
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetPatientById(IRepository<Patient> repository, int id)
        {
            var patient = await repository.GetById(id);
            var patientDto = PatientPatientDto.Create(patient);
            return TypedResults.Ok(patientDto);
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetAppointmentsByPatientIdAndDoctorId(IRepository<Appointment> repository, int doctor_id, int patient_id)
        {
            var appointments = await repository.GetById(doctor_id, patient_id);
            var appointmentDto = appointments.Select(AppointmentAppointmentDto.Create);
            return TypedResults.Ok(appointmentDto);
        }
    }
}
