using Microsoft.AspNetCore.Mvc.Testing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace workshop.tests
{
    public class AppointmentTests
    {
        [Test]
        public async Task GetAppointments()
        {
            // Arrange
            var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
            var client = factory.CreateClient();

            // Act
            var response = await client.GetAsync("/appointments");

            // Assert
            Assert.IsTrue(response.StatusCode == System.Net.HttpStatusCode.OK);
        }

        [Test]
        public async Task GetAppointmentById()
        {
            // Arrange
            var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
            var client = factory.CreateClient();

            // Act
            var response = await client.GetAsync("/appointments/2&1");

            // Assert
            Assert.IsTrue(response.StatusCode == System.Net.HttpStatusCode.OK);
        }

        [Test]
        public async Task GetAppointmentById2()
        {
            // Arrange
            var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
            var client = factory.CreateClient();

            // Act
            var response = await client.GetAsync("/appointments/100&200");

            // Assert
            Assert.IsTrue(response.StatusCode == System.Net.HttpStatusCode.NotFound);
        }

        [Test]
        public async Task GetAppointmentByDoctorId()
        {
            // Arrange
            var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
            var client = factory.CreateClient();

            // Act
            var response = await client.GetAsync("/appointments/bydoctor/2");

            // Assert
            Assert.IsTrue(response.StatusCode == System.Net.HttpStatusCode.OK);
        }


        [Test]
        public async Task GetAppointmentByDoctorId2()
        {
            // Arrange
            var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
            var client = factory.CreateClient();

            // Act
            var response = await client.GetAsync("/appointments/bydoctor/200");

            // Assert
            Assert.IsTrue(response.StatusCode == System.Net.HttpStatusCode.NotFound);
        }

        [Test]
        public async Task GetAppointmentByPatientId()
        {
            // Arrange
            var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
            var client = factory.CreateClient();

            // Act
            var response = await client.GetAsync("/appointments/bypatient/2");

            // Assert
            Assert.IsTrue(response.StatusCode == System.Net.HttpStatusCode.OK);
        }


        [Test]
        public async Task GetAppointmentByPatientId2()
        {
            // Arrange
            var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
            var client = factory.CreateClient();

            // Act
            var response = await client.GetAsync("/appointments/bypatient/200");

            // Assert
            Assert.IsTrue(response.StatusCode == System.Net.HttpStatusCode.NotFound);
        }


    }
}
