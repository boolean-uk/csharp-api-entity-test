using workshop.wwwapi.Models;

namespace workshop.wwwapi.Services
{
    public static class AppointmentDtoManager
    {
        public static OutputAppointment Convert(Appointment appointment)
        {
            return new OutputAppointment
            {
                Id = appointment.Id,
                Booking = appointment.Booking,
                Doctor = new DoctorWhithoutAppointment
                {
                    Id = appointment.Doctor.Id,
                    FullName = appointment.Doctor.FullName
                },
                Patient = new PatientWhithoutAppointment
                {
                    Id = appointment.Patient.Id,
                    FullName = appointment.Patient.FullName
                },
                Prescription = appointment.Prescription != null ? new PrescriptionWhitoutAppointment
                {
                    Id = appointment.Prescription.Id,
                    Medicines = appointment.Prescription.Medicines.Select(medicine => new MedicineWhitoutPrescription
                    {
                        Id = medicine.Id,
                        Name = medicine.Name,
                        Quantity = medicine.Quantity,
                        Notes = medicine.Notes
                    }).ToList()
                } : null
            };
        }

        public static IEnumerable<OutputAppointment> Convert(IEnumerable<Appointment> appointments)
        {
            return appointments.Select(appointment => Convert(appointment));
        }

        public static AppointmentWhitoutPrescription ConvertRemovePrescription(Appointment appointment)
        {
            return new AppointmentWhitoutPrescription
            {
                Id = appointment.Id,
                Booking = appointment.Booking,
                Doctor = new DoctorWhithoutAppointment
                {
                    Id = appointment.Doctor.Id,
                    FullName = appointment.Doctor.FullName
                },
                Patient = new PatientWhithoutAppointment
                {
                    Id = appointment.Patient.Id,
                    FullName = appointment.Patient.FullName
                }
            };
        }
    }
}
