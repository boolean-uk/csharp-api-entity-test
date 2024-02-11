using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using System.Text;
using workshop.wwwapi.Models;

namespace workshop.tests
{
    public class Tests
    {
        private readonly WebApplicationFactory<Program> _factory;
        private readonly HttpClient _client;

        public Tests()
        {
            _factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
            _client = _factory.CreateClient();
        }

        [Test]
        public async Task GetPatients()
        {
            var response = await _client.GetAsync("/surgery/patients");
            Assert.IsTrue(response.StatusCode == System.Net.HttpStatusCode.OK);
        }

        [Test]
        public async Task CreatePatient()
        {
            var patientDto = new PatientDto { FullName = "Test Patient" };
            var content = new StringContent(JsonConvert.SerializeObject(patientDto) , Encoding.UTF8 , "application/json");
            var response = await _client.PostAsync("/surgery/patients" , content);
            Assert.IsTrue(response.StatusCode == System.Net.HttpStatusCode.Created);
        }

        [Test]
        public async Task GetDoctors()
        {
            var response = await _client.GetAsync("/surgery/doctors");
            Assert.IsTrue(response.StatusCode == System.Net.HttpStatusCode.OK);
        }

        [Test]
        public async Task CreateDoctor()
        {
            var doctorDto = new DoctorDto { FullName = "Test Doctor" };
            var content = new StringContent(JsonConvert.SerializeObject(doctorDto) , Encoding.UTF8 , "application/json");
            var response = await _client.PostAsync("/surgery/doctors" , content);
            Assert.IsTrue(response.StatusCode == System.Net.HttpStatusCode.Created);
        }

        [Test]
        public async Task GetAppointments()
        {
            var response = await _client.GetAsync("/surgery/appointments");
            Assert.IsTrue(response.StatusCode == System.Net.HttpStatusCode.OK);
        }

        [Test]
        public async Task CreateAppointment()
        {
            var appointmentDto = new AppointmentDto
            {
                Booking = DateTime.UtcNow ,
                DoctorId = 1 ,
                DoctorName = "Test Doctor" ,
                PatientId = 1 ,
                PatientName = "Test Patient"
            };
            var content = new StringContent(JsonConvert.SerializeObject(appointmentDto) , Encoding.UTF8 , "application/json");
            var response = await _client.PostAsync("/surgery/appointment" , content);
            Assert.IsFalse(response.StatusCode == System.Net.HttpStatusCode.Created);
        }
    }
}
