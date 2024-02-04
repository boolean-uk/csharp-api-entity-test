using Microsoft.AspNetCore.Mvc;
using workshop.wwwapi.DTOs;
using workshop.wwwapi.Models;
using workshop.wwwapi.Repository;

namespace workshop.wwwapi.Endpoints
{
    public static class DoctorEndpoint
    {

        public static void ConfigureDoctorEndpoint(this WebApplication app)
        {
            var doctorGroup = app.MapGroup("doctor");

            doctorGroup.MapGet("/", GetAllDoctors);
            doctorGroup.MapGet("/{id}", GetADoctor);
            doctorGroup.MapPost("/", AddDoctor);

        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetAllDoctors(IRepository repository)
        {

            //Soruce:
            var source = await repository.GetDoctors();
            //Target & Transferring:
            List<OutDoctorDTO> doctors = new List<OutDoctorDTO>();

            foreach (Doctor doctor in source)
            {
                OutDoctorDTO outDoctor = new OutDoctorDTO
                {
                    FullName = doctor.FullName,
                    Id = doctor.Id,
                    Appointments = doctor.Appointments.Select(a => new OutAppointmentDTO { DoctorId = a.DoctorId, Booking = a.Booking, PatientId = a.PatientId,Appointmenttype = a.Appointmenttype }).ToList()
                };

                doctors.Add(outDoctor);
            }

            /*List<OutDoctorDTO> doctors = source.Select(doctor => new OutDoctorDTO
            {
                FullName = doctor.FullName,
                Id = doctor.Id,
                Appointments = doctor.Appointments
        .Select(a => new OutAppointmentDTO
        {
            DoctorId = a.DoctorId,
            Booking = a.Booking,
            PatientId = a.PatientId
        })
        .ToList()
            }).ToList();*/


            return TypedResults.Ok(doctors);
        }



        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> GetADoctor(IRepository repository, int? id)
        {
            try
            {   //Source
                var source = await repository.GetADoctor(id);
                //Target and transferring:
                OutDoctorDTO doctor = new OutDoctorDTO
                {
                    FullName = source.FullName,
                    Id = source.Id,
                    Appointments = source.Appointments.Select(a => new OutAppointmentDTO { DoctorId = a.DoctorId, Booking = a.Booking, PatientId = a.PatientId, Appointmenttype = a.Appointmenttype }).ToList()
                };
                return TypedResults.Ok(doctor);
            }

            catch (ArgumentException ex) { return TypedResults.NotFound(ex.Message); }

        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public static async Task<IResult> AddDoctor(IRepository repository, [FromBody] InnDoctorDTO newDoctor)
        {
            try
            {
                //Soruce:
                await repository.AddDoctor(newDoctor);

                return TypedResults.Created(nameof(AddDoctor), newDoctor);
            }
            catch (ArgumentException ex) { return TypedResults.BadRequest(ex.Message); }
            catch (BadHttpRequestException ex) { return TypedResults.BadRequest(ex.Message); }

        }
    }
}