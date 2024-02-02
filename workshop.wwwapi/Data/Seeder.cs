using workshop.wwwapi.Models;

namespace workshop.wwwapi.Data
{
    public class Seeder
    {

        private List<Patient> _patients = new();



        public Seeder() 
        {
            _patients.Add(new() { Id=1, FullName="Iamin Extremepain" });
            _patients.Add(new() { Id=2, FullName="Greg Hurt"});
        }

        public List<Patient> Patients { get { return _patients; } }
    }
}
