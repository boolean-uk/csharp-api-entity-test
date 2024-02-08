using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using workshop.wwwapi.DTO;
using workshop.wwwapi.Models;
using workshop.wwwapi.Repository.PrescriptionRepo;

namespace workshop.wwwapi.Endpoints
{
    public static class PrescriptionApi
    {

        public static void ConfigurePrescriptionApi(this WebApplication app) {
            var prescripGroup = app.MapGroup("surgery/prescription");

            prescripGroup.MapGet("/", GetAllPrescriptions);
            //prescripGroup.MapPost("/", CreatePrescription);
        }


        private static async Task<IResult> GetAllPrescriptions(IPrescriptionRepository prescriptionRepository) {
            var result = await prescriptionRepository.getAllPrescriptions();
            var prescriptionDTO = new List<PrescriptionDTO>();
            foreach (var prescription in result) { 
                prescriptionDTO.Add(new PrescriptionDTO(prescription));
            }
            return TypedResults.Ok(prescriptionDTO);

        }

        /*
          var patients = await repository.GetPatients();
            var patientOnlyDTO = new List<PatientOnlyDTO>();
            foreach (var patient in patients)
            {
                patientOnlyDTO.Add(new PatientOnlyDTO(patient));
            }
            return TypedResults.Ok(patientOnlyDTO);*/
    }
}