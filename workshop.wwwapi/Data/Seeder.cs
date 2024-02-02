using workshop.wwwapi.Models;

namespace workshop.wwwapi.Data
{
    public class Seeder
    {
        private List<Patient> _patients = new List<Patient>();
        public Seeder() 
        {
            Patient patient = new Patient() { Id = 1, FirstName = "Øystein", LastName = "Haugen" };
            Patient patient2 = new Patient() { Id = 2, FirstName = "Bøystein", LastName = "Baugen" };
            _patients.Add(patient);
            _patients.Add(patient2);
        }

        public List<Patient> Patients { get {  return _patients; } }
    }
}
