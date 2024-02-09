using Microsoft.AspNetCore.Mvc;
using System.Numerics;
using workshop.wwwapi.Models.AppointmentModels;
using workshop.wwwapi.Models.AppointmentModels.DTO;
using workshop.wwwapi.Models.DoctorModels;
using workshop.wwwapi.Models.DoctorModels.DTO;
using workshop.wwwapi.Models.PatientModels;
using workshop.wwwapi.Models.PatientModels.DTO;
using workshop.wwwapi.Repository.ExtensionRepository;
using workshop.wwwapi.Repository.GenericRepository;

namespace workshop.wwwapi.Endpoints
{
    public static class SurgeryEndpoint
    {
        public static void ConfigureSurgeryEndpoint(this WebApplication app)
        {
            var surgeryGroup = app.MapGroup("surgery");

            surgeryGroup.MapGet("/patients", GetPatients);
            surgeryGroup.MapGet("/doctors", GetDoctors);
            surgeryGroup.MapGet("/appointments", GetAppointments);
            surgeryGroup.MapGet("/appointments/{id}", GetAppointmentsByDoctor);
        }

        private static async Task<IResult> GetAppointments(IRepository<Appointment> repo)
        {
            var appointments = await repo.Get();
            var appointmentDtos = appointments.Select(CreateAppointmentAppointmentDto);
            return TypedResults.Ok(appointmentDtos);

           
        }

        private static AppointmentAppointmentDto CreateAppointmentAppointmentDto(Appointment appointment)
        {
            return new AppointmentAppointmentDto()
            {
                Booking = appointment.Booking,
                Doctor = CreateDoctorAppointmentDto(appointment.Doctor),
                Patient = CreatePatientAppointmentDto(appointment.Patient)
            };
        }

        private static PatientAppointmentDto CreatePatientAppointmentDto(Patient patient)
        {
            return new PatientAppointmentDto()
            {
                PatientId = patient.Id,
                Name = patient.FullName,
            };
        }

        private static DoctorAppointmentDto CreateDoctorAppointmentDto(Doctor doctor)
        {
            return new DoctorAppointmentDto()
            {
                DoctorId = doctor.Id,
                Name = doctor.FullName,
            };
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetPatients(IRepository<Patient> repository)
        {
            var patients = await repository.Get();
            var patientDtos = patients.Select(CreatePatientPatientDto);
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
                doctorDtos.Add(CreateDoctorDoctorDto(doctor));
            }
            return TypedResults.Ok(doctorDtos);
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetAppointmentsByDoctor(IRepository<Doctor> repository, int id)
        {
            var doctor = await repository.GetById(id);
            var doctorDto = CreateDoctorDoctorDto(doctor);
            return TypedResults.Ok(doctorDto);
        }
        private static PatientDoctorDto CreatePatientDoctorDto(Patient patient)
        {
            return new PatientDoctorDto() 
            { 
                PatientId = patient.Id, 
                Name = patient.FullName 
            };
        }
        private static AppointmentDoctorDto CreateAppointmentDoctorDto(Appointment appointment)
        {
            return new AppointmentDoctorDto()
            {
                Booking = appointment.Booking,
                Patient = CreatePatientDoctorDto(appointment.Patient)
            };
        }
        private static DoctorDoctorDto CreateDoctorDoctorDto(Doctor doctor)
        {
            return new DoctorDoctorDto()
            {
                DoctorId = doctor.Id,
                Name = doctor.FullName,
                Appointments = doctor.Appointments.Select(CreateAppointmentDoctorDto).ToList()
            };
        }

        private static PatientPatientDto CreatePatientPatientDto(Patient patient)
        {
            return new PatientPatientDto()
            {
                PatientId = patient.Id,
                Name = patient.FullName,
                Appointments = patient.Appointments.Select(CreateAppointmentPatientDto).ToList()

            };
        }

        private static AppointmentPatientDto CreateAppointmentPatientDto(Appointment appointment)
        {
            return new AppointmentPatientDto()
            {
                Booking = appointment.Booking,
                Doctor = CreateDoctorPatientDto(appointment.Doctor)
            };
        }

        private static DoctorPatientDto CreateDoctorPatientDto(Doctor doctor)
        {
            return new DoctorPatientDto()
            {
                DoctorId = doctor.Id,
                Name = doctor.FullName
            };
        }
    }
}
