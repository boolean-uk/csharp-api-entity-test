using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using workshop.wwwapi.DTO;
using workshop.wwwapi.Models;
using workshop.wwwapi.Repository;

namespace workshop.wwwapi.Endpoints;

public static class SurgeryEndpoint
{
    public static void ConfigurePatientEndpoint(this WebApplication app)
    {
        var surgeryGroup = app.MapGroup("surgery");

        surgeryGroup.MapGet("/patients", GetPatients);
        surgeryGroup.MapGet("/patients/{id}", GetPatient);
        surgeryGroup.MapGet("/doctors", GetDoctors);
        surgeryGroup.MapGet("/doctors/{id}", GetDoctor);
        
        surgeryGroup.MapPost("/patients", CreatePatient);
        surgeryGroup.MapPost("/doctors", CreateDoctor);
        surgeryGroup.MapPost("/appointments", CreateAppointment);
    }

    [ProducesResponseType(StatusCodes.Status201Created)]
    private static async Task<IResult> CreateAppointment(IRepository<Appointment> repository, IMapper mapper, [FromBody] AppointmentPost body)
    {
        var appointment = new Appointment
        {
            Type = body.Type,
            PatientId = body.PatientId,
            DoctorId = body.DoctorId,
            Booking = body.Booking
        };
        
        await repository.Create(appointment);
        
        return TypedResults.Created($"/surgery/patient/{appointment.PatientId}");
    }

    [ProducesResponseType(StatusCodes.Status201Created)]
    private static async Task<IResult> CreateDoctor(IRepository<Doctor> repository, IMapper mapper, [FromBody] DoctorPost body)
    {
        var doctor = new Doctor { FullName = body.FullName };
        await repository.Create(doctor);
        
        return TypedResults.Created($"/surgery/doctors/{doctor.Id}");
    }

    [ProducesResponseType(StatusCodes.Status201Created)]
    private static async Task<IResult> CreatePatient(IRepository<Patient> repository, IMapper mapper, [FromBody] PatientPost body)
    {
        var patient = new Patient { FullName = body.FullName };
        await repository.Create(patient);
        
        return TypedResults.Created($"/surgery/patients/{patient.Id}");
    }

    [ProducesResponseType(typeof(IEnumerable<PatientResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public static async Task<IResult> GetPatients(IRepository<Patient> repository, IMapper mapper)
    {
        var patients = await repository.GetAll();
        if (!patients.Any())
        {
            return TypedResults.NotFound();
        }
        
        var response = mapper.Map<IEnumerable<PatientResponse>>(patients);
        foreach (var patient in response)
        {
            patient.Appointments = null;
        }
        
        return TypedResults.Ok(response);
    }
    
    [ProducesResponseType(typeof(PatientResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public static async Task<IResult> GetPatient(IRepository<Patient> patientRepository, IRepository<Doctor> doctorRepository, IMapper mapper, int id)
    {
        // Include the doctor of appointments
        var patient = await patientRepository.GetWithIncludes(p => p.Id == id, include: query => query.Include(p => p.Appointments)!.ThenInclude(a => a.Doctor));
        if (patient is null)
        {
            return TypedResults.NotFound();
        }
        
        var response = mapper.Map<PatientResponse>(patient);
        
        if (patient.Appointments is not null)
        {
            response.Appointments = new List<AppointmentResponse>();
            foreach (var appointment in patient.Appointments)
            {
                var appointmentResponse = mapper.Map<AppointmentResponse>(appointment);
                appointmentResponse.Doctor = mapper.Map<DoctorResponse>(appointment.Doctor);
                appointmentResponse.Doctor.Appointments = null;
                response.Appointments.Add(appointmentResponse);
            }
        }
        
        return TypedResults.Ok(response);
    }

    [ProducesResponseType(typeof(IEnumerable<DoctorResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public static async Task<IResult> GetDoctors(IRepository<Doctor> repository, IMapper mapper)
    {
        var doctors = await repository.GetAll(d => d.Appointments);
        if (!doctors.Any())
        {
            return TypedResults.NotFound();
        }
        
        var response = mapper.Map<IEnumerable<DoctorResponse>>(doctors);
        foreach (var doctor in response)
        {
            doctor.Appointments = null;
        }
        
        return TypedResults.Ok(response);
    }
    
    [ProducesResponseType(typeof(DoctorResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public static async Task<IResult> GetDoctor(IRepository<Doctor> repository, IMapper mapper, int id)
    {
        var doctor = await repository.GetWithIncludes(d => d.Id == id, include: query => query.Include(d => d.Appointments)!.ThenInclude(a => a.Patient));
        if (doctor is null)
        {
            return TypedResults.NotFound();
        }
        
        var response = mapper.Map<DoctorResponse>(doctor);
        if (doctor.Appointments is not null)
        {
            response.Appointments = new List<AppointmentResponse>();
            foreach (var appointment in doctor.Appointments)
            {
                var appointmentResponse = mapper.Map<AppointmentResponse>(appointment);
                appointmentResponse.Patient = mapper.Map<PatientResponse>(appointment.Patient);
                appointmentResponse.Patient.Appointments = null;
                response.Appointments.Add(appointmentResponse);
            }
        }
        
        return TypedResults.Ok(response);
    }
}