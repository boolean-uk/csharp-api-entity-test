using workshop.wwwapi.Models;

namespace workshop.wwwapi.Services
{
    public static class PrescriptionDtoManager
    {
        public static OutputPrescription Convert(Prescription prescription)
        {
            if (prescription == null)
                return null;

            return new OutputPrescription
            {
                Id = prescription.Id,
                Medicines = MedicineDtoManager.ConvertRemovePrescription(prescription.Medicines),
                Appointment = AppointmentDtoManager.ConvertRemovePrescription(prescription.Appointment)
            };
        }

        public static IEnumerable<OutputPrescription> Convert(IEnumerable<Prescription> prescription)
        {
            return prescription.Select(prescription => Convert(prescription));
        }

        public static PrescriptionWhitoutAppointment ConvertRemoveAppointment(Prescription prescription)
        {
            if (prescription == null)
                return null;

            return new PrescriptionWhitoutAppointment
            {
                Id = prescription.Id,
                Medicines = MedicineDtoManager.ConvertRemovePrescription(prescription.Medicines),
            };
        }
    }
}
