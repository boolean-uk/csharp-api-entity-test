using workshop.wwwapi.Models;

namespace workshop.wwwapi.Data
{
    public class Seeder
    {
        public List<Patient> Patients = new List<Patient>()
        {
            new Patient{Id = 1, FullName = "Homer Simpson"},
            new Patient{Id = 2, FullName = "George Washington"}
        };
    }
}
