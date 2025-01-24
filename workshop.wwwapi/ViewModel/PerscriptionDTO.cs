using workshop.wwwapi.Models;

namespace workshop.wwwapi.ViewModel
{
    public class PerscriptionDTO
    {
        public int Id { get; set; }
        public List<MedicineDTO> Medicines { get; set; } = new List<MedicineDTO>();

        public PerscriptionDTO(Perscription perscription, List<PerscriptionMedicine> perscriptionMedicines)
        {
            this.Id = perscription.Id;

            foreach (var item in perscriptionMedicines)
            {
                if (item.PerscriptionId == perscription.Id)
                {
                    if (item.Medicine != null)
                    {
                        this.Medicines.Add(new MedicineDTO(item.Medicine));
                    }
                }
            }
        }
    }
}
