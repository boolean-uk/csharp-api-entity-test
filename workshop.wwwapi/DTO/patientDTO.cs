using workshop.wwwapi.Models;

namespace workshop.wwwapi.DTO
{
    public class patientDTO
    {
        public int id {  get; set; }
        public string name { get; set; }

        public List<PAppointmentDTO> pAppointmentDTOs { get; set; }
        public patientDTO(Patient patient) 
        {
            id = patient.Id;
            name = patient.FullName;

            //more later

            pAppointmentDTOs = new List<PAppointmentDTO>();

            var list = patient.Appointments;
            foreach (var item in list)
            {
                PAppointmentDTO pAppointmentDTO = new PAppointmentDTO(item);
                pAppointmentDTOs.Add(pAppointmentDTO);
            }

            

        }
    }
}
