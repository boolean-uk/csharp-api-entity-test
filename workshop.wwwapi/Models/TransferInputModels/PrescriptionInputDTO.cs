using System.ComponentModel.DataAnnotations.Schema;
using workshop.wwwapi.Models.JunctionTable;
using workshop.wwwapi.Models.PureModels;
using workshop.wwwapi.Models.TransferModels.Items;

namespace workshop.wwwapi.Models.TransferInputModels
{
    public class PrescriptionInputDTO(string Name, int DoctorId, int PatientId, IEnumerable<PrescriptionMedisinSetMedisinInputDTO> prescriptionMedicine)
    {
        public string Name { get; set; } = Name;

        public int DoctorId { get; set; } = DoctorId;

        public int PatientId { get; set; } = PatientId;

        public IEnumerable<PrescriptionMedisinSetMedisinInputDTO> prescriptionMedicine { get; set; } = prescriptionMedicine;
        // public PrescriptionMedicine PrescriptionMedicine { get; set; } = PrescriptionMedicine;

    }
}
