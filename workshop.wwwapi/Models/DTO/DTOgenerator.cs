namespace workshop.wwwapi.Models.DTO
{
    public static class DTOgenerator
    {

        public static AppointmentDTO GenerateAppointmentDTO()
        {
            return null;
        }

        public static PatientDTO GeneratePatientDTO(Patient p)
        {
            List<AppointmentDTO> aDTOs = new List<AppointmentDTO>();
            if (p.Appointments != null)
            {
                foreach (var apt in p.Appointments)
                {
                    AppointmentDTO aDTO = new AppointmentDTO(apt.Doctor.FullName, p.FullName, apt.Booking);
                    aDTOs.Add(aDTO);
                }
            }
            PatientDTO pDTO = new PatientDTO(p.Id, p.FullName, aDTOs);
            return pDTO;
        }

        public static DoctorDTO GenerateDoctorDTO(Doctor d)
        {
            List<AppointmentDTO> aDTOs = new List<AppointmentDTO>();
            if(d.Appointments != null) 
            { 
                foreach(var apt in d.Appointments)
                {
                    AppointmentDTO aDTO = new AppointmentDTO(d.FullName, apt.Patient.FullName, apt.Booking);
                    aDTOs.Add(aDTO);
                }
            }
            DoctorDTO dDTO = new DoctorDTO(d.Id, d.FullName, aDTOs);
            return dDTO;
        }

        public static AppointmentDTO GenerateAppointmentDTO(Appointment a)
        {
            AppointmentDTO aDTO = new AppointmentDTO(a.Doctor.FullName, a.Patient.FullName, a.Booking);

            return aDTO;
        }
    }
}
