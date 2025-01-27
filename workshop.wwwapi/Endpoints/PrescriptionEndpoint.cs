
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using workshop.wwwapi.Models;
using workshop.wwwapi.Repository;

namespace workshop.wwwapi.Endpoints
{
    public static class PrescriptionEndpoint
    {
        public static void ConfigurePrescriptionEndpoint(this WebApplication app)
        {
            var prescriptions = app.MapGroup("/prescriptions");
            prescriptions.MapGet("/", GetPrescriptions);
            prescriptions.MapPost("/", CreatePrescription);
        }        
        
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        private static async Task<IResult> GetPrescriptions(
            HttpContext context, 
            IRepository<Prescription> repo,
            IRepository<Doctor> d_repo,
            IRepository<Patient> p_repo,
            int? patient_id,
            int? doctor_id,
            int? prescription_id
            )
        {
            if (prescription_id != null) return await _GetPrescription(context, repo, prescription_id.Value);
            else if (patient_id == null && doctor_id == null) return await _GetPrescriptions(context, repo);
            else if (patient_id != null && doctor_id == null) return await _GetPatientPrescriptions(context, p_repo, patient_id.Value);
            else if (patient_id == null && doctor_id != null) return await _GetDoctorPrescriptions(context, d_repo, doctor_id.Value);
            else
                return await _GetPrescription(context, repo, patient_id.Value, doctor_id.Value);
        }
        private static async Task<IResult> _GetPrescription(HttpContext context, IRepository<Prescription> repo, int patient_id, int doctor_id)
        {
            try
            {
                var b = await repo.GetEntries(x => 
                    x.Where(x => x.PatientId == patient_id && x.DoctorId == doctor_id),
                    x => x.Include(x => x.Patient).
                    Include(x => x.Doctor).
                    Include(x => x.MedicinesInPrescription)
                    .ThenInclude(x => x.Medicine)

                    );
                var a = DTO.Response.Prescription.Get.ToDTOs<Prescription, DTO.Response.Prescription.Get>(b ).ToList();
                if (a == null) return TypedResults.NotFound($"Prescription with id[{doctor_id},{patient_id}] was not found");
                return TypedResults.Ok(a);
            }
            catch(Exception e )
            {
                return TypedResults.NotFound($"Prescription with id[{doctor_id},{patient_id}] was not found");
            }
        }
        private static async Task<IResult> _GetPrescription(HttpContext context, IRepository<Prescription> repo, int prescription_id)
        {
            try
            {
                var a = await DTO.Response.Prescription.Get.DTO(repo,  prescription_id );
                if (a == null) return TypedResults.NotFound($"Prescription with id[{prescription_id}] was not found");
                return TypedResults.Ok(a);
            }
            catch(Exception e )
            {
                return TypedResults.NotFound($"Prescription with id[{prescription_id}] was not found");
            }
        }
        private static async Task<IResult> _GetPrescriptions(HttpContext context, IRepository<Prescription> repo)
        {
            var a = await DTO.Response.Prescription.Get.DTO(repo);
            if (a.Count() == 0) return TypedResults.NotFound($"No prescriptions was found");
            return TypedResults.Ok(a);
        }
        private static async Task<IResult> _GetDoctorPrescriptions(HttpContext context, IRepository<Doctor> repo, int id)
        {
            var a = await DTO.Response.Prescription.GetDoctors.DTO(repo, id);
            if (a == null) return TypedResults.NotFound($"Doctor with id[{id}] was not found");

            return TypedResults.Ok(a);
        }
        private static async Task<IResult> _GetPatientPrescriptions(HttpContext context, IRepository<Patient> repo, int id)
        {
            var p = await DTO.Response.Prescription.GetPatients.DTO(repo,id);
            if (p == null) return TypedResults.NotFound($"Patient with id[{id}] was not found");

            return TypedResults.Ok(p);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        private static async Task<IResult> CreatePrescription(HttpContext context, IRepository<Prescription> repo, IRepository<Appointment> a_repo, IRepository<Medicine> m_repo, IRepository<Patient> p_repo, IRepository<Doctor> d_repo, DTO.Request.Prescription.Create dto)
        {
            Prescription prescriptions = new()
            {
                DoctorId = dto.DoctorId,
                PatientId = dto.PatientId,
                
            };
            if(prescriptions.Doctor != null && prescriptions.Patient != null)
            {
                var app = await a_repo.GetEntry(x => 
                    x.Where(x => x.PatientId == dto.PatientId && x.DoctorId == dto.DoctorId),
                    x => x.Include(x => x.Patient).
                    Include(x => x.Doctor)
                    
                    );
                if (app == null) return TypedResults.NotFound($"No appointment found for doctor_id[{dto.DoctorId}] and patient_id[{dto.PatientId}], can't create prescription");
            }

            try
            {
                prescriptions.MedicinesInPrescription = new();
                foreach (var med in dto.Medicnes)
                {
                    var m = await m_repo.GetEntry(x => x.Where(x => x.Id == med.medicinId));
                    prescriptions.MedicinesInPrescription.Add(
                        new MedicinesInPrescription
                        {
                            Medicine = m,
                            MedicineId = m.Id,
                            note = med.note,
                            quantity = med.quantity
                        }
                        );
                }
                
            }
            catch (Exception e)
            {
                if (e is KeyNotFoundException) return TypedResults.NotFound("Invalid Key for medicine, not found");
                return TypedResults.BadRequest($"Not a valid DTO");
            }

            var a = await repo.CreateEntry(prescriptions);

            if (a == null) return TypedResults.BadRequest($"Not a valid DTO");

            return TypedResults.Ok(await DTO.Response.Prescription.Get.DTO(repo, a.Id)); 
        }
    }
}
