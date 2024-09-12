using Microsoft.AspNetCore.Mvc;
using workshop.wwwapi.DTO.PrescriptionDTOs;
using workshop.wwwapi.Repository;

namespace workshop.wwwapi.Endpoints
{
    public static class PrescriptionEndpoint
    {
        public static void ConfigurePrescriptionEndpoint(this WebApplication app)
        {
            var medicineGroup = app.MapGroup("medication");

            medicineGroup.MapGet("/prescriptions", GetPrescriptions);
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
                        medList.Add(new PrescribedMedicineDTO() {Id = med.Id, Name = med.MedicineName, Amount = med.Amount, Instruction = med.Instructions });
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
    }
}
