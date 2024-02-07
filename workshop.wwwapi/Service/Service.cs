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
                foreach (var appointement in patient.Appointments)
                {
                    PatientAppointement appointemntDto = new PatientAppointement()
                    {
                        time = appointement.DateTime,
                        Doctor = new PatientDoctor() { Name = appointement.Doctor.FullName }
                    };
                    patientDto.Appointements.Add(appointemntDto);
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
                foreach (var appointement in doctor.Appointments)
                {
                    DoctorAppointement appointemntDto = new DoctorAppointement()
                    {
                        time = appointement.DateTime,
                        Patient = new DoctorPatient() { Name = appointement.Patient.FullName }
                    };
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
        public static List<AppointmentDto> toAppointmentDto(List<Appointment> appointements)
        {
            List<AppointmentDto> appointementDtos = new List<AppointmentDto>();
            foreach( var appointement in appointements )
            {
                appointementDtos.Add(toAppointmentDto(appointement));
            }
            return appointementDtos;
        }

        public static AppointmentDto toAppointmentDto(Appointment appointement)
        {
            AppointmentDto appointementDto = new AppointmentDto() { 
                dateTime = appointement.DateTime, doctor = new AppointmentDoctor() { FullName = appointement.Doctor.FullName }, 
                patient = new AppointmentPatient() { FullName = appointement.Patient.FullName}
            };

            return appointementDto;
        }
    }
}
