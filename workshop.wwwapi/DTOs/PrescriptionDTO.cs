using workshop.wwwapi.Models;

namespace workshop.wwwapi.DTOs
{
    public class PrescriptionDTO
    {
        public PrescriptionDTO(Prescription prescription) { 
            Id = prescription.Id;
            Note = prescription.Note;
            Quantity = prescription.Quantity;
            if (prescription.Medicine != null)
            {
                Medicine = new MedicineDTO(prescription.Medicine);
            } 
            if (prescription.Appointment != null)
            {
                Appointment = new AppointmentDTO(prescription.Appointment);
            }
        }

        public int Id { get; set; }
        public MedicineDTO? Medicine { get; set; }
        public AppointmentDTO? Appointment { get; set; }
        public string Note { get; set; }
        public int Quantity { get; set; }
    }

    public class MedicineDTO
    {
        public MedicineDTO(Medicine m)
        {
            Id = m.Id;
            Name = m.Name;
        }
        public int Id { get; set; }
        public string Name { get; set; }

    }


}
