using AutoMapper;
using workshop.wwwapi.DTOs;
using Microsoft.AspNetCore.Mvc;
using workshop.wwwapi.Repository;
using workshop.wwwapi.Models;
using System.Numerics;

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
            surgeryGroup.MapGet("/doctors", GetDoctors);
            surgeryGroup.MapGet("/doctors/{id}", GetDoctor);
            surgeryGroup.MapGet("/appointmentsbydoctor/{id}", GetAppointmentsByDoctor);
        }


        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetPatients(IRepository repository, IMapper mapper)
        {
            var patients = await repository.GetPatients();

            var response = mapper.Map<List<PatientDTO>>(patients);

            // Porbably a very subpar solution for this(??)
            foreach (var patient in response)
            {
                foreach (var appointment in patient.Appointments)
                {
                    appointment.PatientFullName = patient.FullName;
                    appointment.DoctorFullName = repository.GetDoctorById(appointment.DoctorId).Result.FullName;
                }
            }

            return TypedResults.Ok(response);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetPatient(IRepository repository, IMapper mapper, int id)
        {
            var patient = await repository.GetPatientById(id);

            var response = mapper.Map<PatientDTO>(patient);

            response.Appointments = from p in patient.Appointments
                                    select new AppointmentDTO()
                                    {
                                        PatientId = p.PatientId,
                                        DoctorId = p.DoctorId,
                                        PatientFullName = patient.FullName,
                                        DoctorFullName = repository.GetDoctorById(p.DoctorId).Result.FullName
                                    };

            return TypedResults.Ok(response);
        }


        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetDoctors(IRepository repository, IMapper mapper)
        {
            var doctors = await repository.GetDoctors();

            var response = mapper.Map<List<DoctorDTO>>(doctors);

            foreach (var doctor in response)
            {
                foreach (var appointment in doctor.Appointments)
                {
                    appointment.PatientFullName = repository.GetPatientById(appointment.DoctorId).Result.FullName;
                    appointment.DoctorFullName = doctor.FullName;
                }
            }

            return TypedResults.Ok(response);
        }


        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetDoctor(IRepository repository,IMapper mapper, int id)
        {
            var doctor = await repository.GetDoctorById(id);

            var response = mapper.Map<DoctorDTO>(doctor);

            response.Appointments = from d in doctor.Appointments
                                    select new AppointmentDTO()
                                    {
                                        PatientId = d.PatientId,
                                        DoctorId = d.DoctorId,
                                        PatientFullName = repository.GetPatientById(d.PatientId).Result.FullName,
                                        DoctorFullName = doctor.FullName
                                    };

            return TypedResults.Ok(response);
        }





        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetAppointmentsByDoctor(IRepository repository, int id)
        {
            var response = await repository.GetAppointmentsByDoctor(id);

            var payload = from a in response
                          select new  AppointmentDTO()
                          {
                              PatientId = a.PatientId,
                              DoctorId = a.DoctorId,
                              PatientFullName = repository.GetPatientById(a.DoctorId).Result.FullName,
                              DoctorFullName = repository.GetDoctorById(a.DoctorId).Result.FullName
                          };
           
            return TypedResults.Ok(payload);
        }

    }
}
