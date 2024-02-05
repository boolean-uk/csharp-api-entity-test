using workshop.wwwapi.Models.JunctionTable;
using workshop.wwwapi.Models.PureModels;
using workshop.wwwapi.Models.TransferModels.Appointments;

namespace workshop.wwwapi.Models.TransferModels.Items
{
    public class PrescriptionDTO(int Id, string Name, Appointment app, ICollection<PrescriptionMedicine> medicines)
    {
        public int Id { get; set; } = Id;

        public string Name { get; set; } = Name;

        public AppointmentDTO appointment { get; set; } = new AppointmentDTO(app.Booking, app.PatientId, app.DoctorId, app.Doctor, app.Patient);

        public ICollection<PrescriptionMedicineGetMedicinesDTO> Medicines { get; set; } = medicines.Select(m => new PrescriptionMedicineGetMedicinesDTO(m.Amount, m.Instructions, m.Medicine)).ToList();
    }
}
