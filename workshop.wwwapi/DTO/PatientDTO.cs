using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using workshop.wwwapi.Models;

namespace wwwapi.DTO
{
    public class PatientReturnDTO
    {

        public int Id { get; set; }

        public string FullName { get; set; }

        public List<AppointmentDTO> Appointments { get; set; } = new List<AppointmentDTO>();
        public PatientReturnDTO(Patient patient) {
            Id=patient.Id;
            FullName=patient.FullName;
            foreach(Appointment a in patient.Appointments)
            {
                Appointments.Add(new AppointmentDTO(a));
            }
        
        }

        static public List<PatientReturnDTO> ListOfPatients( List<Patient> patients)
        {
            List < PatientReturnDTO > patientReturnDTOs = new List < PatientReturnDTO >();
            foreach(Patient patient in patients)
            {
                patientReturnDTOs.Add(new PatientReturnDTO(patient));
            }
            return patientReturnDTOs;
        }
    }

    public class AppointmentDTO
    {

       public DateTime Booking { get; set; }
        public DoctorDTO doctor { get; set; }
        public AppointmentDTO(Appointment a)
        {
            Booking = a.Booking;
            doctor = new DoctorDTO(a.Doctor);
        }

    }

    public class DoctorDTO
    {
        public int Id { get; set; }
        public string FullName { get; set; }

        public DoctorDTO(Doctor d)
        {

            Id = d.Id;
            FullName = d.FullName;
        }
    }
}