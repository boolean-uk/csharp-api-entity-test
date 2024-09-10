using workshop.wwwapi.Models;

namespace workshop.wwwapi.ViewModel
{
    public class DoctorDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<DetailsDTO> patientAppointments { get; set; } = new List<DetailsDTO>();

        public DoctorDTO(Doctor doctor, List<Appointment> appointments, List<Patient> patients)
        {
            this.Id = doctor.Id;
            this.Name = doctor.FullName;
            if (appointments.Count > 0)
            {
                foreach (Appointment appointment in appointments) 
                {
                    var patient = patients.Where(p => p.Id == appointment.PatientId).FirstOrDefault();
                    if(patient != null && appointment.DoctorId == doctor.Id)
                    {
                        this.patientAppointments.Add(new DetailsDTO(patient.Id, patient.FullName, appointment.Booking));
                    }
                }
            }
        }
    }
}
