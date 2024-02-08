using workshop.wwwapi.DTO;
using workshop.wwwapi.Models;

namespace workshop.wwwapi.Service
{
    public static class Service
    {
        public static Patient toPatient(PatientDto patientDto)
        {
            return new Patient() { FullName = patientDto.FullName };
        }

        public static List<PatientDto> toPatientDto(List<Patient> patients)
        {
            List<PatientDto> patientDtos = new List<PatientDto>();
            foreach (Patient patient in patients)
            {
                patientDtos.Add(toPatientDto(patient));
            }
            return patientDtos;
        }
        public static PatientDto toPatientDto(Patient patient)
        {
            PatientDto patientDto = new PatientDto() { FullName = patient.FullName };
            if (patient.Appointments != null)
            {
                foreach (var appointment in patient.Appointments)
                {
                    PatientAppointement appointmentDto = new PatientAppointement()
                    {
                        time = appointment.DateTime,
                        Doctor = new PatientDoctor() { Name = appointment.Doctor.FullName }
                    };

                    appointmentDto.Medicines = appointment.Prescriptions.
                        SelectMany(p => p.Medicines).ToList().Select(pm =>
                        new PatientMedicine
                        {
                            Name = pm.Medicine.Name,
                            Instruction = pm.Medicine.Instructions
                        }
                    ).ToList();

                    patientDto.Appointements.Add(appointmentDto);
                }
            }
            return patientDto;
        }

        public static Doctor toDoctor(DoctorDto doctorDto)
        {
            return new Doctor() { FullName = doctorDto.FullName };
        }
        public static List<DoctorDto> toDoctorDto(List<Doctor> doctors)
        {
            List<DoctorDto> doctorDtos = new List<DoctorDto>();
            foreach ( Doctor doctor in doctors)
            {
                doctorDtos.Add(toDoctorDto(doctor));
            }
            return doctorDtos;
        }

        public static DoctorDto toDoctorDto(Doctor doctor)
        {
            DoctorDto doctorDto = new DoctorDto() { FullName = doctor.FullName };
            if (doctor.Appointments != null)
            {
                foreach (Appointment appointment in doctor.Appointments)
                {
                    DoctorAppointement appointemntDto = new DoctorAppointement()
                    {
                        time = appointment.DateTime,
                        Patient = new DoctorPatient() { Name = appointment.Patient.FullName }
                    };
                    appointemntDto.Medicines = appointment.Prescriptions.
                        SelectMany(p => p.Medicines).ToList().Select(pm => 
                        new DoctorMedicine { Name = pm.Medicine.Name, 
                            Instruction = pm.Medicine.Instructions}).ToList();
                    doctorDto.Appointements.Add(appointemntDto);
                }
            }
            return doctorDto;
        }

        public static Appointment toAppointment(AppointmentPost appointmentPost)
        {
            return new Appointment()
            {
                DateTime = appointmentPost.dateTime,
                PatientId = appointmentPost.patientID, 
                DoctorId = appointmentPost.doctorID
            };
        }
        public static List<AppointmentDto> toAppointmentDto(List<Appointment> appointments)
        {
            List<AppointmentDto> appointmentDtos = new List<AppointmentDto>();
            foreach( var appointment in appointments )
            {
                appointmentDtos.Add(toAppointmentDto(appointment));
            }
            return appointmentDtos;
        }

        public static AppointmentDto toAppointmentDto(Appointment appointment)
        {
            AppointmentDto appointmentDto = new AppointmentDto() { 
                dateTime = appointment.DateTime, Doctor = new AppointmentDoctor() { FullName = appointment.Doctor.FullName }, 
                Patient = new AppointmentPatient() { FullName = appointment.Patient.FullName}, 
            };
            appointmentDto.Medicines = appointment.Prescriptions.
                SelectMany(p => p.Medicines).ToList().Select(pm =>
                new AppointmentMedicine
                {
                    Name = pm.Medicine.Name, 
                    Instruction = pm.Medicine.Instructions
                }
            ).ToList();

            return appointmentDto;
        }

        //              prescriptions
        public static Prescription toPrescription(PrescriptionPost prescriptionDto)
        {
            return new Prescription()
            {
                DoctorId = prescriptionDto.DoctorId,
                PatientId = prescriptionDto.PatientId
            };
        }
        public static Prescription toPrescription(Prescription prescription, PrescriptionPost prescriptionDto)
        {
            prescription.DoctorId = prescriptionDto.DoctorId;
            prescription.PatientId = prescriptionDto.PatientId;
            return prescription;
        }

        public static List<PrescriptionDto> toPrescriptionDto(IEnumerable<Prescription> prescriptions)
        {
            List<PrescriptionDto> prescriptionDtos = new List<PrescriptionDto>();
            foreach (Prescription prescription in  prescriptions)
            {
                prescriptionDtos.Add(toPrescriptionDto(prescription));
            }
            return prescriptionDtos;
        }

        public static PrescriptionDto toPrescriptionDto(Prescription prescription)
        {
            PrescriptionDto prescriptionDto = new PrescriptionDto();
            prescriptionDto.Medicines = prescription.Medicines.Select(m => new PrescriptionMedicineDto
            {
                Name = m.Medicine.Name, 
                Instructions = m.Medicine.Instructions
            });
            prescriptionDto.Appointment = new PrescriptionAppointment()
            {
                Doctor = new PrescriptionDoctor() { FullName = prescription.Appointment.Doctor.FullName },
                Patient = new PrescriptionPatient() { FullName = prescription.Appointment.Patient.FullName }, 
                DateTime = prescription.Appointment.DateTime
            };

            return prescriptionDto;
        }

        public static PrescriptionMedicine toPrescriptionMedicine(int prescriptionId, int medicineId)
        {
            return new PrescriptionMedicine()
            {
                PrescriptionId = prescriptionId,
                MedicineId = medicineId
            };
        }
    }
}
