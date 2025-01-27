using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using workshop.wwwapi.Data;
using workshop.wwwapi.Models;
using workshop.wwwapi.Repository;

namespace workshop.tests
{
    public class Tests
    {


        private Mock<IRepository> mockRepository;
        private WebApplicationFactory<Program> factory;

        [SetUp]
        public void Setup()
        {
            mockRepository = new Mock<IRepository>();
            factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
        }

        [TearDown]
        public void TearDown()
        {
            factory?.Dispose();
        }

        [Test]
        public async Task PatientEndpointStatus()
        {
            var client = factory.CreateClient();
            mockRepository
                .Setup(repo => repo.GetPatients())
                .ReturnsAsync(new List<Patient>
                {
                    new Patient { Id = 1, FullName = "John Doe" },
                    new Patient { Id = 2, FullName = "Jane Smith" }
                });



            var response = await client.GetAsync("surgery/patients");

             Assert.That(response.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.OK));

        }

        [Test]
        public async Task GetPatientsReturnsCorrectData()
        {

            mockRepository
                .Setup(repo => repo.GetPatients())
                .ReturnsAsync(new List<Patient>
                {
                    new Patient { Id = 1, FullName = "John Doe" },
                    new Patient { Id = 2, FullName = "Nigelino Sibbertini" }
                });

            var client = factory.CreateClient();


            var response = await client.GetAsync("surgery/patients");
            var content = await response.Content.ReadAsStringAsync();


            Assert.That(response.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.OK));
            Assert.That(content, Does.Contain("John Doe"));
            Assert.That(content, Does.Contain("Nigelino Sibbertini"));

        }

        [Test]
        public async Task GetSinglePatientsReturnsCorrectData()
        {

            mockRepository
                .Setup(repo => repo.GetPatients())
                .ReturnsAsync(new List<Patient>
                {
                    new Patient { Id = 1, FullName = "John Doe" },
                    new Patient { Id = 2, FullName = "Nigelino Sibbertini" }
                });

            var client = factory.CreateClient();


            var response = await client.GetAsync("surgery/patients/1");
            var content = await response.Content.ReadAsStringAsync();


            Assert.That(response.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.OK));
            Assert.That(content, Does.Contain("John Doe"));

        }
    }
}
