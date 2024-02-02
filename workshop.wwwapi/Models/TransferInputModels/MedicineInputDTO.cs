using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using workshop.wwwapi.Models.JunctionTable;

namespace workshop.wwwapi.Models.TransferInputModels
{
    public class MedicineInputDTO(int id, string Name)
    {
        public int Id { get; set; } = id;
        public string Name { get; set; } = Name;

    }
}
