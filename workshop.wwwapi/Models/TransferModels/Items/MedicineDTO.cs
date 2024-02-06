using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using workshop.wwwapi.Models.JunctionTable;

namespace workshop.wwwapi.Models.TransferModels.Items
{
    public class MedicineDTO(int Id, string Name)
    {
        public int Id { get; set; } = Id;

        public string Name { get; set; } = Name;

    }
}
