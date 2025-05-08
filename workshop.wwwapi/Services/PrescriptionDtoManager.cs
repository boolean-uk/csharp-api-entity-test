using workshop.wwwapi.Models;

namespace workshop.wwwapi.Services
{
    public static class PrescriptionDtoManager
    {
        public static OutputPrescription Convert(Prescription prescription)
        {
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

        public static PrescriptionWhitoutMedicine ConvertRemoveMedicine(Prescription prescription)
        {
            if (prescription == null)
                return null;

            return new PrescriptionWhitoutMedicine
            {
                Id = prescription.Id,
                Appointment = AppointmentDtoManager.ConvertRemovePrescription(prescription.Appointment)
            };
        }

        public static IEnumerable<PrescriptionWhitoutMedicine> ConvertRemoveMedicine(IEnumerable<Prescription> prescriptions)
        {
            return prescriptions.Select(prescription => ConvertRemoveMedicine(prescription));
        }
    }
}
