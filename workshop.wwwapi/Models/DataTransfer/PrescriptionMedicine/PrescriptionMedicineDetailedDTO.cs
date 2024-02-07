using workshop.wwwapi.Models.DataTransfer.Doctor;
using workshop.wwwapi.Models.DataTransfer.Medicine;
using workshop.wwwapi.Models.DataTransfer.Patient;

namespace workshop.wwwapi.Models.DataTransfer.PrescriptionMedicine
{
    public class PrescriptionMedicineDetailedDTO
    {
        public PrescriptionMedicineDetailedDTO(Domain.Junctions.PrescriptionMedicine prescriptionMedicine)
        {
            this.Medicine = new MedicineDTO(prescriptionMedicine.Medicine);
            this.Quantity = prescriptionMedicine.Quantity;
            this.NoteFromDoctor = prescriptionMedicine.NoteFromDoctor;
            this.Doctor = new DoctorDTO(prescriptionMedicine.Prescription.Appointment.Doctor);
            this.Patient = new PatientDTO(prescriptionMedicine.Prescription.Appointment.Patient);

        }
        public MedicineDTO Medicine { get; set; }
        public int Quantity { get; set; }
        public string NoteFromDoctor { get; set; }
        public DoctorDTO Doctor { get; set; }
        public PatientDTO Patient { get; set; }

    }
}
