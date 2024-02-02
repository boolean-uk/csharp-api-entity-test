using Microsoft.AspNetCore.Mvc.Testing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace workshop.tests
{
    public  class DoctorTests
    {
        [Test]
        public async Task GetDoctors()
        {
            // Arrange
            var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
            var client = factory.CreateClient();

            // Act
            var response = await client.GetAsync("/doctors");

            // Assert
            Assert.IsTrue(response.StatusCode == System.Net.HttpStatusCode.OK);
        }

        [Test]
        public async Task GetDoctorById()
        {
            // Arrange
            var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
            var client = factory.CreateClient();

            // Act
            var response = await client.GetAsync("/doctors/2");

            // Assert
            Assert.IsTrue(response.StatusCode == System.Net.HttpStatusCode.OK);
        }

        [Test]
        public async Task GetDoctorById2()
        {
            // Arrange
            var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
            var client = factory.CreateClient();

            // Act
            var response = await client.GetAsync("/doctors/100");

            // Assert
            Assert.IsTrue(response.StatusCode == System.Net.HttpStatusCode.NotFound);
        }
    }
}
