using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using workshop.wwwapi.DTO;
using workshop.wwwapi.Models;
using workshop.wwwapi.Models.Payloads;
using workshop.wwwapi.Repository;
using workshop.wwwapi.Repository.PrescriptionRepo;

namespace workshop.wwwapi.Endpoints
{
    public static class PrescriptionApi
    {

        public static void ConfigurePrescriptionApi(this WebApplication app) {
            var prescripGroup = app.MapGroup("surgery/prescription");

            prescripGroup.MapGet("/", GetAllPrescriptions);
            prescripGroup.MapPost("/", CreatePrescription);
            prescripGroup.MapPut("/{id}/addMedicine/{medicine_id}", AddMedicineToPrescription);

            prescripGroup.MapGet("/medicine", GetAllMedicine);
        }


        private static async Task<IResult> GetAllPrescriptions(IPrescriptionRepository prescriptionRepository) {
            var result = await prescriptionRepository.getAllPrescriptions();
            var prescriptionDTO = new List<PrescriptionDTO>();
            foreach (var prescription in result) { 
                prescriptionDTO.Add(new PrescriptionDTO(prescription));
            }
            return TypedResults.Ok(prescriptionDTO);
        }

        private static async Task<IResult> CreatePrescription(IPrescriptionRepository prescriptionRepository, IRepository repository, PrescriptionPostPayload payload)
        {
            var isAppointment = await repository.GetAppointmentWithDetailsById(payload.appointment_id);
            if (isAppointment == null)
            {
                return TypedResults.BadRequest($"There is no appointment with id {payload.appointment_id} so can not create a prescription");
            }
            var result = await prescriptionRepository.createPrescription(payload.note, payload.appointment_id);
            if (result == null)
            {
                return TypedResults.NotFound("No such appointmnt");
            }
            return TypedResults.Created("/surgery/prescription", new PrescriptionDTO(result));

        }

        private static async Task<IResult> GetAllMedicine(IPrescriptionRepository prescriptionRepository)
        {
            var result = await prescriptionRepository.getAllMedicine();
            if (result == null)
            {
                return TypedResults.BadRequest("No medicine in the database");
            }
            var medicineDTO = new List<MedicineDTO>();
            foreach (var medicine in result)
            {
                medicineDTO.Add(new MedicineDTO(medicine));
            }

            return TypedResults.Ok(medicineDTO);
            
        }

        private static async Task<IResult> AddMedicineToPrescription(int id, int medicine_id, IPrescriptionRepository prescriptionRepository, PrescriptionMedicinePostPayload payload)
        {
            var isPrescription = await prescriptionRepository.getPrescriptionById(id);
            if (isPrescription == null)
            {
                return TypedResults.BadRequest($"No such Prescription {id}");
            }
            var isMedicine = await prescriptionRepository.getMedicineById(medicine_id);
            if (isMedicine == null)
            {
                return TypedResults.BadRequest($"There is no such medicine {medicine_id}");
            }
            var result = await prescriptionRepository.addMedicine(id, medicine_id, payload.quantity, payload.note);
            if (!result)
            {
                return TypedResults.BadRequest("Something happened whilest doing the opperation");
            }

            return TypedResults.Created($"/{id}/addMedicine/{medicine_id}", "true");
           
        }

        


        
    }
}