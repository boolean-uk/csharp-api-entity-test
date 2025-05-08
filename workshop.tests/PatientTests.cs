using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using Moq;
using workshop.wwwapi.Endpoints;
using workshop.wwwapi.Models.Responses;
using workshop.wwwapi.Models;
using workshop.wwwapi.Repository;
using workshop.wwwapi.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Net;
using workshop.wwwapi.Repository.SpecificRepositories;
using Microsoft.Extensions.Hosting;

namespace workshop.tests
{

    public class PatientTests
    {

        private Mock<IPatientRepository> _mockRepo;

        [SetUp]
        public void Setup()
        {
            _mockRepo = new Mock<IPatientRepository>();
        }



        [Test]
        public async Task PatientEndpointStatus()
        {
            // Arrange
            WebApplicationFactory<Program> _factory = new WebApplicationFactory<Program>()
            .WithWebHostBuilder(builder =>
            {
                builder.ConfigureServices(services =>
                {
                    services.AddScoped<IPatientRepository>(_ => _mockRepo.Object);
                });
            });

            HttpClient _client = _factory.CreateClient();

            var patientExamples = new List<Patient>
            {
                new Patient { Id = 1, FullName = "John Doe" },
                new Patient { Id = 2, FullName = "Jane Smith" }
            };

            _mockRepo.Setup(repo => repo.GetAllAsync()).ReturnsAsync(patientExamples);

            // Act
            var response = await _client.GetAsync("/patients");

            Console.WriteLine($"Response Status: {response.StatusCode}");

            // Assert
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);  // Ensure status is OK

            var responseBody = await response.Content.ReadAsStringAsync();

            // Directly assert JSON deserializationa
            var patients = JsonConvert.DeserializeObject<List<PatientDTO>>(responseBody);

            // Basic assertions
            Assert.IsNotNull(patients);
            Assert.IsTrue(patients.Count > 0);  // Ensure there's at least one patient
        }

        [Test]
        public async Task GetPatients_ReturnsListOfPatients()
        {
            // Arrange: Seed test data
            var patients = new List<Patient>
            {
                new Patient { Id = 1, FullName = "John Doe", Appointments = new List<Appointment>() },
                new Patient { Id = 2, FullName = "Jane Smith", Appointments = new List<Appointment>() }
            };

            _mockRepo.Setup(repo => repo.GetAllAsync()).ReturnsAsync(patients);

            // Act: Call the endpoint method
            var result = await PatientEndpoints.GetPatients(_mockRepo.Object) as Ok<List<PatientDTO>>;

            // Debugging: Print the result
            Console.WriteLine($"Test Result Type: {result?.GetType()}");

            // Ensure response is JSON and contains expected data
            Assert.IsNotNull(result, "The result should not be null.");
            Assert.AreEqual(StatusCodes.Status200OK, result.StatusCode, "Expected status code 200 OK.");
            Assert.IsNotNull(result.Value, "The response value should not be null.");
            Assert.AreEqual(2, result.Value.Count, "The number of returned patients does not match.");
        }



        [Test]
        public async Task CreatePatient_ValidPatient_ReturnsCreatedResult()
        {
            // Arrange: New patient data
            var newPatient = new Patient { Id = 3, FullName = "Alice Johnson" };
            _mockRepo.Setup(repo => repo.AddAsync(It.IsAny<Patient>())).ReturnsAsync(newPatient);

            // Act
            var result = await PatientEndpoints.CreatePatient(_mockRepo.Object, newPatient) as Created<Patient>;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(StatusCodes.Status201Created, result.StatusCode);
            Assert.AreEqual(newPatient.FullName, result.Value.FullName);
        }
    }
}
