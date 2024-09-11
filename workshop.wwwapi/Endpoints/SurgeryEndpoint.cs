using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Numerics;
using workshop.wwwapi.Models;
using workshop.wwwapi.Models.AppointmentDTOs;
using workshop.wwwapi.Models.DoctorDTOs;
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
            surgeryGroup.MapGet("/patients/{id}", GetPatient);
            surgeryGroup.MapPost("/patients", CreatePatient);
            surgeryGroup.MapGet("/doctors", GetDoctors);
            surgeryGroup.MapGet("/doctors/{id}", GetDoctor);
            surgeryGroup.MapPost("/doctors", CreateDoctor);
            surgeryGroup.MapGet("/appointments", GetAppointments);
            surgeryGroup.MapGet("/appointment/", GetAppointment);
            surgeryGroup.MapGet("/appointmentsbydoctor/{id}", GetAppointmentsByDoctor);
            surgeryGroup.MapGet("/appointmentsbypatient/{id}", GetAppointmentsByPatient);
            surgeryGroup.MapPost("/appointments/", CreateAppointment);
            surgeryGroup.MapGet("/prescriptions/", GetPrescriptions);
            surgeryGroup.MapGet("/prescriptions/{id}", GetPrescription);
            surgeryGroup.MapPost("/prescriptions/", CreatePrescription);
            surgeryGroup.MapPatch("/prescriptions/", AddMedicineToPrescription);
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetPatients(IRepository repository, IMapper mapper)
        {
            var patients = await repository.GetPatients();
            var patientDtos = mapper.Map<IEnumerable<GetPatientDTO>>(patients);

            return TypedResults.Ok(patientDtos);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> GetPatient(Guid id, IRepository repository, IMapper mapper)
        {
            Patient patient = null;

            try
            {
                patient = await repository.GetPatient(id);
            }
            catch (Exception ex)
            {
                return TypedResults.NotFound(ex.Message);
            }
            
            var patientDto = mapper.Map<GetPatientDTO>(patient);

            return TypedResults.Ok(patientDto);
        }

        public static async Task<IResult> CreatePatient(CreatePatientDTO patientDTO, IRepository repository, IMapper mapper)
        {
            Patient patient = mapper.Map<Patient>(patientDTO);
            
            var createdPatient = await repository.CreatePatient(patient);

            return TypedResults.Ok(createdPatient);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetDoctors(IRepository repository, IMapper mapper)
        {
            var doctors = await repository.GetDoctors();
            var doctorDtos = mapper.Map<IEnumerable<GetDoctorDTO>>(doctors);

            return TypedResults.Ok(doctorDtos);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> GetDoctor(Guid id, IRepository repository, IMapper mapper)
        {
            Doctor doctor = null;

            try
            {
                doctor = await repository.GetDoctor(id);
            }
            catch (Exception ex)
            {
                return TypedResults.NotFound(ex.Message);
            }

            var doctorDTO = mapper.Map<GetDoctorDTO>(doctor);

            return TypedResults.Ok(doctorDTO);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> CreateDoctor(CreateDoctorDTO doctorDTO, IRepository repository, IMapper mapper)
        {
            Doctor doctor = mapper.Map<Doctor>(doctorDTO);

            var createdDoctor = await repository.CreateDoctor(doctor);

            return TypedResults.Ok(createdDoctor);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetAppointments(IRepository repository, IMapper mapper)
        {
            var appointments = await repository.GetAppointments();
            var appointmentDTOs = mapper.Map<IEnumerable<GetAppointmentDTO>>(appointments);

            return TypedResults.Ok(appointmentDTOs);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> GetAppointment(Guid patientId, Guid doctorId, IRepository repository, IMapper mapper)
        {
            Appointment appointment = null;

            try
            {
                appointment = await repository.GetAppointment(patientId, doctorId);
            }
            catch (Exception ex)
            {
                return TypedResults.NotFound(ex.Message);
            }

            var appointmentDTO = mapper.Map<GetAppointmentDTO>(appointment);

            return TypedResults.Ok(appointmentDTO);
        }


        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetAppointmentsByDoctor(IRepository repository, IMapper mapper, Guid id)
        {
            var appointments = await repository.GetAppointmentsByDoctor(id);
            var appointmentDTOs = mapper.Map<IEnumerable<GetAppointmentDTO>>(appointments);

            return TypedResults.Ok(appointmentDTOs);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetAppointmentsByPatient(IRepository repository, IMapper mapper, Guid id)
        {
            var appointments = await repository.GetAppointmentsByPatient(id);
            var appointmentDTOs = mapper.Map<IEnumerable<GetAppointmentDTO>>(appointments);

            return TypedResults.Ok(appointmentDTOs);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> CreateAppointment(CreateAppointmentDTO appointmentDTO, IRepository repository, IMapper mapper)
        {
            var doctor = await repository.GetDoctor(appointmentDTO.DoctorId);
            var patient = await repository.GetPatient(appointmentDTO.PatientId);

            if (doctor == null || patient == null)
            {
                return TypedResults.NotFound("Doctor or Patient not found");
            }

            Appointment appointment = mapper.Map<Appointment>(appointmentDTO);

            await repository.CreateAppointment(appointment);

            var createdAppointment = await repository.GetAppointment(appointmentDTO.PatientId, appointmentDTO.DoctorId);
            var returnAppointmentDTO = mapper.Map<GetAppointmentDTO>(appointment);

            return TypedResults.Ok(returnAppointmentDTO);
        }


        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetPrescriptions(IRepository repository, IMapper mapper)
        {
            var prescriptions = await repository.GetPrescriptions();
            var prescriptionDTOs = mapper.Map<IEnumerable<GetPrescriptionDTO>>(prescriptions);

            return TypedResults.Ok(prescriptionDTOs);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> GetPrescription(IRepository repository, IMapper mapper, Guid id)
        {

            Prescription prescription = null;

            try
            {
                prescription = await repository.GetPrescription(id);
            }
            catch (Exception ex)
            {
                TypedResults.NotFound(ex.Message);
            }
            
            var prescriptionDTO = mapper.Map<GetPrescriptionDTO>(prescription);

            return TypedResults.Ok(prescriptionDTO);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> CreatePrescription(CreatePrescriptionDTO prescriptionDTO, IRepository repository, IMapper mapper)
        {

            Prescription prescription = mapper.Map<Prescription>(prescriptionDTO);

            await repository.CreatePrescription(prescription);

            return TypedResults.Ok();
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> AddMedicineToPrescription(Guid medicineId, Guid prescriptionId, IRepository repository, IMapper mapper)
        {
            var medicine = await repository.GetMedicine(medicineId);
            var prescription = await repository.GetPrescription(prescriptionId);

            if (medicine == null || prescription == null)
            {
                return TypedResults.NotFound("Medicine or prescription not found");
            }

            await repository.AddMedicineToPrescription(medicineId, prescriptionId);

            return TypedResults.Ok();
        }
    }
}
