using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using workshop.wwwapi.DTO;
using workshop.wwwapi.Models;
using workshop.wwwapi.Repository;

namespace workshop.wwwapi.Endpoints;

public static class PrescriptionEndpoint
{
    public static void ConfigurePrescriptionEndpoint(this WebApplication app)
    {
        var prescriptionGroup = app.MapGroup("prescriptions");

        prescriptionGroup.MapGet("/", GetPrescriptions);
        prescriptionGroup.MapGet("/{id}", GetPrescription);
        prescriptionGroup.MapGet("/appointment/{id}", GetPrescriptionByAppointment);
        
        prescriptionGroup.MapPost("/", CreatePrescription);
        prescriptionGroup.MapPut("/{id}", UpdatePrescriptionAppointment);
    }
    
    private static async Task<IResult> CreatePrescription(IRepository<Prescription> repository, IMapper mapper, [FromBody] PrescriptionPost body)
    {
        var prescription = new Prescription
        {
            AppointmentId = body.AppointmentId,
            Lines = body.Lines.Select(l => new PrescriptionLine
            {
                MedicineId = l.MedicineId,
                Quantity = l.Quantity,
                Instructions = l.Instructions
            }).ToList()
        };
        
        await repository.Create(prescription);
        
        return TypedResults.Created($"/prescriptions/{prescription.Id}");
    }

    private static async Task<IResult> GetPrescriptions(IRepository<Prescription> repository, IMapper mapper)
    {
        var prescriptions = await repository.GetAllWithIncludes(
            query => query.Include(p => p.Lines).ThenInclude(l => l.Medicine));
        var response = mapper.Map<IEnumerable<PrescriptionResponse>>(prescriptions);

        return TypedResults.Ok(response);
    }
    
    private static async Task<IResult> GetPrescription(IRepository<Prescription> repository, IMapper mapper, int id)
    {
        var prescription = await repository.GetWithIncludes(
            p => p.Id == id,
            query => query.Include(p => p.Lines).ThenInclude(l => l.Medicine));
        if (prescription == null) return TypedResults.NotFound();
        
        var response = mapper.Map<PrescriptionResponse>(prescription);
        return TypedResults.Ok(response);
    }
    
    private static async Task<IResult> GetPrescriptionByAppointment(IRepository<Prescription> repository, IMapper mapper, int id)
    {
        var prescription = await repository.GetWithIncludes(
            p => p.AppointmentId == id,
            query => query.Include(p => p.Lines).ThenInclude(l => l.Medicine));
        if (prescription == null) return TypedResults.NotFound();
        
        var response = mapper.Map<PrescriptionResponse>(prescription);
        return TypedResults.Ok(response);
    }
    
    private static async Task<IResult> UpdatePrescriptionAppointment(IRepository<Prescription> repository, IMapper mapper, int id, [FromBody] PrescriptionPut body)
    {
        var prescription = await repository.Get(p => p.Id == id);
        if (prescription == null) return TypedResults.NotFound();
        
        prescription.AppointmentId = body.AppointmentId;
        await repository.Update(prescription);
        
        return TypedResults.NoContent();
    }
}