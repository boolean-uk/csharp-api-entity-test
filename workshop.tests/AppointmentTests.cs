using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using workshop.wwwapi.Dtoes.ViewModels;

namespace workshop.tests
{
    public class AppointmentTests
    {
        [Test]
        public async Task AppointmentGetByDoctorEndpointStatus()
        {
            // Arrange
            var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
            var client = factory.CreateClient();
            int doctorid = 1;

            // Act
            var response = await client.GetAsync($"surgery/appointmentsByDoctor/{doctorid}");

            // Assert
            Assert.IsTrue(response.StatusCode == System.Net.HttpStatusCode.OK);
        }

        [Test]
        public async Task AppointmenGetStatusOK()
        {
            var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
            var client = factory.CreateClient();
            int doctorid = 1;
            int patientid = 1;

            // Act
            var response = await client.GetAsync($"surgery/appointments/{patientid}/{doctorid}");

            // Assert
            Assert.IsTrue(response.StatusCode == System.Net.HttpStatusCode.OK);
        }

        [Test]
        public async Task AppointmenGetStatusNotFound()
        {
            var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
            var client = factory.CreateClient();
            int doctorid = 1;
            int patientid = 0;

            // Act
            var response = await client.GetAsync($"surgery/appointments/{patientid}/{doctorid}");

            // Assert
            Assert.IsTrue(response.StatusCode == System.Net.HttpStatusCode.NotFound);
        }

    }
}
