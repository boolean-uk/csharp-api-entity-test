using workshop.wwwapi.DTOs;
using workshop.wwwapi.DTOs.Prescriptions;
using workshop.wwwapi.Models;
using workshop.wwwapi.Repository;

namespace workshop.wwwapi.Endpoints
{
    public static class PrescriptionEndpoint
    {
        public async static Task<IResult> GetAll(PrescriptionRepository repository)
        {
            IEnumerable<Prescription> prescriptions = await repository.GetAll();
            IEnumerable<GetPrescriptionDTO> dtos = prescriptions.Select(p => new GetPrescriptionDTO()
            {
                Medicines = p.Medicines.Select(m => new GetMedicineDTO() 
                { 
                    Instruction = m.Instruction, 
                    Name = m.Name, 
                    Quantity = m.Quantity 
                }).ToList(),
            });
            return TypedResults.Ok(dtos);
        }

        public async static Task<IResult> Get(PrescriptionRepository repository, int id)
        {
            try
            {
                Prescription prescription = await repository.GetById(id);
                GetPrescriptionDTO dto = new()
                {
                    Medicines = prescription.Medicines.Select(m => new GetMedicineDTO()
                    {
                        Name = m.Name,
                        Instruction = m.Instruction,
                        Quantity = m.Quantity
                    }).ToList(),
                };
                return TypedResults.Ok(dto);
            }
            catch (Exception ex)
            {
                return TypedResults.NotFound(ex.Message);
            }
        }

        public async static Task<IResult> Add(PrescriptionRepository repository, AddMedicinePrescriptionDTO addDTO)
        {
            try
            {
                Prescription prescription = await repository.Add(addDTO);
                GetPrescriptionDTO getPrescriptionDTO = new()
                {
                    Medicines = prescription.Medicines.Select(m => new GetMedicineDTO()
                    {
                        Name = m.Name,
                        Instruction = m.Instruction,
                        Quantity = m.Quantity
                    }).ToList()
                };
                return TypedResults.Created(nameof(Add), getPrescriptionDTO);
            }
            catch (Exception ex)
            {
                return TypedResults.BadRequest(ex.Message);
            }
        }
    }
}
