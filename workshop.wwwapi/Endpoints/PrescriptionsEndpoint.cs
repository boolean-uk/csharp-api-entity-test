using System.Numerics;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using workshop.wwwapi.DTO;
using workshop.wwwapi.Exceptions;
using workshop.wwwapi.Models;
using workshop.wwwapi.Repository;
using workshop.wwwapi.ViewModel;

namespace workshop.wwwapi.Endpoints
{
    public static class PrescriptionsEndpoint
    {
        //TODO:  add additional endpoints in here according to the requirements in the README.md 
        public static void ConfigurePrescriptionsEndpoint(this WebApplication app)
        {
            var group = app.MapGroup("prescriptions");

            group.MapGet("/", GetPrescriptions);
            group.MapPost("/", CreatePrescriptions);

        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public static async Task<IResult> GetPrescriptions(IRepository<Prescription> repository, IMapper mapper)
        {
            try
            {
                var prescriptions = await repository.GetAllWithCustomQuery(query => query.Include(p => p.Appointment).ThenInclude(a => a.Doctor).Include(p => p.Appointment).ThenInclude(a => a.Patient).Include(p => p.MedicinePrescriptions).ThenInclude(mp => mp.Medicine));

                if (!prescriptions.Any()) return TypedResults.NotFound();

                return TypedResults.Ok(mapper.Map<IEnumerable<PrescriptionDTO>>(prescriptions));
            }
            catch (Exception ex) 
            {
                var errorResponse = new ErrorResponse
                {
                    Message = "An unexpected error occurred while processing the request.",
                    Detail = ex.Message
                };

                return TypedResults.InternalServerError(errorResponse);
            }
           
        }


        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public static async Task<IResult> CreatePrescriptions(IRepository<Prescription> repository, IRepository<Appointment> repositoryAppointments, IMapper mapper, CreatePrescription entity)
        {
            try
            {
                var appointment = await repositoryAppointments.Get(a => a.PatientId == entity.PatientId && a.DoctorId == entity.DoctorId, a => a.Patient, a => a.Doctor);
                if (appointment == null) return TypedResults.NotFound("Appointment not found for the specified doctor and patient.");

                Prescription newPrescription = new Prescription
                {
                    DoctorId = entity.DoctorId,
                    PatientId = entity.PatientId,
                    IssueDate = entity.IssueDate,
                    Appointment = appointment,
                };

                var prescription = await repository.Add(newPrescription);

                var prescriptionWithIncludes = await repository.GetWithCustomQuery(p => p.PatientId == entity.PatientId && p.DoctorId == entity.DoctorId && p.IssueDate.Equals(entity.IssueDate) ,query => query.Include(p => p.Appointment).ThenInclude(a => a.Doctor).Include(p => p.Appointment).ThenInclude(a => a.Patient).Include(p => p.MedicinePrescriptions).ThenInclude(mp => mp.Medicine));

                return TypedResults.Created($"https://localhost:7235/prescriptions/", mapper.Map<PrescriptionDTO>(prescriptionWithIncludes));
            }
            catch (Exception ex)
            {
                var errorResponse = new ErrorResponse
                {
                    Message = "An unexpected error occurred while processing the request.",
                    Detail = ex.Message
                };

                return TypedResults.InternalServerError(errorResponse);
            }

        }

    }
}
