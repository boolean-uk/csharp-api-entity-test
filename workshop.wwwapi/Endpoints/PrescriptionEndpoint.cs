using Microsoft.AspNetCore.Mvc;
using workshop.wwwapi.DTO.PrescriptionDTOs;
using workshop.wwwapi.Repository;
using workshop.wwwapi.ViewModels;
using workshop.wwwapi.Models;

namespace workshop.wwwapi.Endpoints
{
    public static class PrescriptionEndpoint
    {
        public static void ConfigurePrescriptionEndpoint(this WebApplication app)
        {
            var medicineGroup = app.MapGroup("medication");

            medicineGroup.MapGet("/prescriptions", GetPrescriptions);
            medicineGroup.MapPost("/prescriptions", CreatePrescription);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> GetPrescriptions(IRepository repository)
        {
            var found = await repository.GetPrescriptions();
            if (found != null)
            {
                GetPrescriptionsResponse response = new GetPrescriptionsResponse();
                foreach (var p in found)
                {
                    GetPrescriptionDTO prescription = new GetPrescriptionDTO();
                    var doctor = await repository.GetDoctorById(p.DoctorId);
                    var patient = await repository.GetPatientById(p.PatientId);

                    prescription.DoctorName = doctor.Name;
                    prescription.PatientName = patient.Name;
                    List<PrescribedMedicineDTO> medList = new List<PrescribedMedicineDTO>();
                    foreach (var med in p.PrescribedMedicineList)
                    {
                        medList.Add(new PrescribedMedicineDTO() {MedicineName = med.MedicineName, Amount = med.Amount, Instruction = med.Instructions });
                    }
                    prescription.prescribedMedicines = medList;
                    response.Prescriptions.Add(prescription);
                }
                return TypedResults.Ok(response);
            }
            else
            {
                return TypedResults.NotFound("No prescriptions found");
            }
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public static async Task<IResult> CreatePrescription(IRepository repository, PrescriptionPostModel pmodel)
        {
            List<PrescribedMedicine> prescribedmeds = new List<PrescribedMedicine>();
            foreach(var item in pmodel.PrescribedMedicineList)
            {
                if (await repository.GetMedicineByName(item.MedicineName))
                {
                    prescribedmeds.Add(new PrescribedMedicine() { Instructions = item.Instructions, Amount = item.Amount, MedicineName = item.MedicineName });
                }
                else
                {
                    return TypedResults.BadRequest($"{item.MedicineName} is not a valid medicine");
                }
            }
            var newprescription = await repository.CreatePrescription(new Prescription() { DoctorId = pmodel.DoctorId, PatientId = pmodel.PatientId, PrescribedMedicineList = prescribedmeds});

            CreatePrescriptionDTO thisone = new CreatePrescriptionDTO();
            List<PrescribedMedicineDTO> newprescriptionDTO = new List<PrescribedMedicineDTO>();
            thisone.DoctorId = pmodel.DoctorId;
            thisone.PatientId = pmodel.PatientId;
            foreach (var item in prescribedmeds)
            {
                newprescriptionDTO.Add(new PrescribedMedicineDTO() { Instruction = item.Instructions, Amount = item.Amount, MedicineName = item.MedicineName });
            }
            thisone.PrescribedMedicines = newprescriptionDTO;
            return TypedResults.Ok(thisone);
        }
    }
}
