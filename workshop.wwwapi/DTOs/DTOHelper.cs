using System.Linq;
using workshop.wwwapi.DTOs.Core;
using workshop.wwwapi.DTOs.Extension;
using workshop.wwwapi.Models;
using workshop.wwwapi.Models.Post;

namespace workshop.wwwapi.DTOs
{
    public static class DTOHelper
    {
        public static PatientDTO_L2 CreatePatientDTO(Patient patient)
        {
            return new PatientDTO_L2
            {
                FullName = patient.FullName,
                Appointments = patient.Appointments.Select(a => new AppointmentDTO_P1
                {
                    Doctor = new DoctorDTO_L1
                    {
                        Id = a.Doctor.Id,
                        FullName = a.Doctor.FullName
                    },
                    Booking = a.Booking
                }).ToList()
            };
        }

        public static DoctorDTO_L2 CreateDoctortDTO(Doctor doctor)
        {
            return new DoctorDTO_L2
            {
                FullName = doctor.FullName,
                Appointments = doctor.Appointments.Select(a => new AppointmentDTO_D1
                {
                    Patient = new PatientDTO_L1
                    {
                        Id = a.Patient.Id,
                        FullName = a.Patient.FullName
                    },
                    Booking = a.Booking
                }).ToList()
            };
        }

        public static List<AppointmentDTO> AppointmentDTOListReturner(IEnumerable<Appointment> appointments)
        {
            List<AppointmentDTO> appointmentDTOs = new List<AppointmentDTO>();

            foreach (var appointment in appointments)
            {
                var appointmentDTO = CreateAppointmentDTO(appointment);
                appointmentDTOs.Add(appointmentDTO);
            }

            return appointmentDTOs;
        }

        public static AppointmentDTO CreateAppointmentDTO(Appointment appointment)
        {
            if (appointment == null)
                return null; // Return null or handle the situation appropriately

            var doctorDTO = appointment.Doctor != null ? new DoctorDTO_L1
            {
                Id = appointment.Doctor.Id,
                FullName = appointment.Doctor.FullName
            } : null;

            var patientDTO = appointment.Patient != null ? new PatientDTO_L1
            {
                Id = appointment.Patient.Id,
                FullName = appointment.Patient.FullName
            } : null;

            return new AppointmentDTO
            {
                Id = appointment.Id,
                DoctorId = appointment.DoctorId,
                Doctor = doctorDTO,
                PatientId = appointment.PatientId,
                Patient = patientDTO,
                AppointmentType = appointment.AppointmentType.ToString(),
                Booking = appointment.Booking
            };
        }


        public static List<MedicinePrescriptionDTO> MedicinePrescriptionDTOListReturner(IEnumerable<MedicinePrescription> mps)
        {
            List<MedicinePrescriptionDTO> mpDTOs = new List<MedicinePrescriptionDTO>();

            foreach (var mp in mps)
            {
                var mpDTO = CreateMedicinePrescriptionDTO(mp);
                mpDTOs.Add(mpDTO);
            }
            return mpDTOs;
        }

        public static MedicinePrescriptionDTO CreateMedicinePrescriptionDTO(MedicinePrescription mp)
        {
            return new MedicinePrescriptionDTO
            {
                Id = mp.Id,
                MedicineId = mp.MedicineId,
                Medicine = new MedicineDTO_L1
                {
                    Id = mp.Medicine.Id,
                    Name = mp.Medicine.Name,
                    Quantity = mp.Medicine.Quantity,
                    Instruction = mp.Medicine.Instruction
                },
                /*
                PrescriptionId = mp.PrescriptionId,
                Prescription = new PrescriptionDTO_L1
                {
                    Id = mp.Prescription.Id,
                    DoctorsNote = mp.Prescription.DoctorsNote,
                    AppointmentId = mp.Prescription.AppointmentId,
                    Appointment = CreateAppointmentDTO(mp.Prescription.Appointment)
                },
                */
            };
        }

        public static PrescriptionDTO_L2 CreatePrescriptionDTO(Prescription prescription)
        {
            var prescriptionDTO = new PrescriptionDTO_L2
            {
                Id = prescription.Id,
                DoctorsNote = prescription.DoctorsNote,
                AppointmentId = prescription.AppointmentId,
                Appointment = CreateAppointmentDTO(prescription.Appointment),
            };

            foreach (var mp in prescription.MedicinePrescriptions)
            {
                prescriptionDTO.MedicinePrescriptions.Add(CreateMedicinePrescriptionDTO(mp));
            }
            return prescriptionDTO;
        }
    }
}
