using System.Linq;
using workshop.wwwapi.Models;

namespace workshop.wwwapi.DTO.Request.Prescription
{
    public class Create
    {
        public Create() { }
        public Create(Models.Prescription p)
        {
            this.DoctorId = p.DoctorId;
            this.PatientId = p.PatientId;
            this.Medicnes = p.MedicinesInPrescription.Select(w => new DTO.Request.MedicinesInPrescription.Create(w)).ToList();
        }
        public int DoctorId { get; set; }
        public int PatientId { get; set; }
        public List<DTO.Request.MedicinesInPrescription.Create> Medicnes { get; set; }

    }
}
