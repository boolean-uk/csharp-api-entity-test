using System.Text.Json.Serialization;
using workshop.wwwapi.Models;

namespace workshop.wwwapi.DTO
{
    public class patientDTO
    {
        public int id {  get; set; }
        public string name { get; set; }

        public List<PatientAppointmentDTO> pAppointmentDTOs { get; set; }
        public patientDTO(Patient patient) 
        {
            id = patient.Id;
            name = patient.FullName;

            //more later

            pAppointmentDTOs = new List<PatientAppointmentDTO>();

            var list = patient.Appointments;

            if(list != null)
            {

                foreach (var item in list)
                {
                    PatientAppointmentDTO pAppointmentDTO = new PatientAppointmentDTO(item);
                    pAppointmentDTOs.Add(pAppointmentDTO);
                }
            }
            
            

            

        }
        [JsonConstructor]
        public patientDTO()
        {

        }
        
        
    }
}
