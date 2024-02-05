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

        public static AppointmentWhithoutPrescription ConvertRemovePrescription(Appointment appointment)
        {
            return new AppointmentWhithoutPrescription
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

        public static AppointmentWhithoutPatient ConvertRemovePatient(Appointment appointment)
        {
            return new AppointmentWhithoutPatient
            {
                Booking = appointment.Booking,
                Doctor = new DoctorWhithoutAppointment
                {
                    Id = appointment.Doctor.Id,
                    FullName = appointment.Doctor.FullName
                },
                Prescription = PrescriptionDtoManager.ConvertRemoveAppointment(appointment.Prescription)
            };
        }

        public static IEnumerable<AppointmentWhithoutPatient> ConvertRemovePatient(IEnumerable<Appointment> appointments)
        {
            return appointments.Select(appointment => ConvertRemovePatient(appointment));
        }

        public static AppointmentWhithoutDoctor ConvertRemoveDoctor(Appointment appointment)
        {
            return new AppointmentWhithoutDoctor
            {
                Booking = appointment.Booking,
                Patient = new PatientWhithoutAppointment
                {
                    Id = appointment.Patient.Id,
                    FullName = appointment.Patient.FullName
                },
                Prescription = PrescriptionDtoManager.ConvertRemoveAppointment(appointment.Prescription)
            };
        }

        public static IEnumerable<AppointmentWhithoutDoctor> ConvertRemoveDoctor(IEnumerable<Appointment> appointments)
        {
            return appointments.Select(appointment => ConvertRemoveDoctor(appointment));
        }
    }
}
