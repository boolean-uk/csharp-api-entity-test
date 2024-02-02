using System.ComponentModel.DataAnnotations.Schema;
using workshop.wwwapi.Models.JunctionTable;
using workshop.wwwapi.Models.PureModels;

namespace workshop.wwwapi.Models.TransferInputModels
{
    public class PrescriptionInputDTO(string Name, int DoctorId, int PatientId, PrescriptionMedicine PrescriptionMedicine)
    {
        public string Name { get; set; }

        public int DoctorId { get; set; }

        public int PatientId { get; set; }

        public PrescriptionMedicine PrescriptionMedicine { get; set; } = PrescriptionMedicine;

    }
}
