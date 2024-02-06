using Microsoft.AspNetCore.Mvc.Testing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using workshop.wwwapi.Models.TransferModels.People;
using workshop.wwwapi.Models;
using System.Text.Json;

namespace workshop.tests
{
    public class PrescriptionTests
    {
        [Test]
        public async Task PrescriptionEndpointStatus()
        {
            // Arrange
            var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
            var client = factory.CreateClient();

            // Act
            var response = await client.GetAsync("/prescriptions/");
            var resAsString = await response.Content.ReadAsStringAsync();
            Payload<IEnumerable<PatientDTO>> deserialized = JsonSerializer.Deserialize<Payload<IEnumerable<PatientDTO>>>(resAsString);

            // Assert
            // Payload
            Assert.IsTrue(response.StatusCode == System.Net.HttpStatusCode.OK);
            Assert.That(response?.RequestMessage?.Method.Method, Is.EqualTo("GET"));
            Assert.That(deserialized.status, Is.EqualTo("Success"));
            Assert.That(deserialized.creationTime, Is.EqualTo(DateTime.Now).Within(TimeSpan.FromMilliseconds(1000)));
            // Data
            // Data is tested laster
        }

        [Test]
        [TestCase(
            1, "Preventative care", "Jan Itor", "Jimmy Bob", 
            new string[] { "One dose each morning for 3 weeks.", "2 pills each day for 2 weeks." } , 
            new int[] { 42, 28 }, 
            new string[] { "Vitalysol", "Zypherexa" }
            )]
        [TestCase(
            2, "Cure Infection", "Dr. Acula", "John Doe",
            new string[] { "5 pills each day for 2 days." },
            new int[] { 10 },
            new string[] { "Pheonixal" }
            )]
        [TestCase(
            3, "Cure cancer", "Jan Itor", "John Doe",
            new string[] { "One dose each morning for 10 days.", "2 pills each day for 2 weeks.", "5 pills each day for 2 days." },
            new int[] { 10, 28, 10 },
            new string[] { "Vitalysol", "Zypherexa", "Pheonixal" }
            )]
        [TestCase(
            4, "Cure cancer", "Jan Itor", "John Doe",
            new string[] { "One dose each morning for 10 days." },
            new int[] { 10 },
            new string[] { "Vitalysol" }
            )]
        public async Task RetrievePrescriptionByIdTest(int id, string name, string doctorName, string patientName, string[] instructions, int[] amount, string[] medicineNames) 
        {
            // Arrange
            var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
            var client = factory.CreateClient();

            // Act
            var response = await client.GetAsync($"/prescriptions/{id}");
            var resAsString = await response.Content.ReadAsStringAsync();
            Payload<PatientDTO> deserialized = JsonSerializer.Deserialize<Payload<PatientDTO>>(resAsString);

            // Assert
            // Payload
            Assert.IsTrue(response.StatusCode == System.Net.HttpStatusCode.OK);
            Assert.That(response?.RequestMessage?.Method.Method, Is.EqualTo("GET"));
            Assert.That(deserialized.status, Is.EqualTo("Success"));
            Assert.That(deserialized.creationTime, Is.EqualTo(DateTime.Now).Within(TimeSpan.FromMilliseconds(1000)));
            // Data
            Assert.IsTrue(resAsString.Contains(name)); // Prescription name
            Assert.IsTrue(resAsString.Contains($"\"doctor\":\"{doctorName}\"")); // Doctor name
            Assert.IsTrue(resAsString.Contains($"\"patient\":\"{patientName}\"")); // Patient name
            for (int i = 0; i < medicineNames.Length; i++) 
            {
                Assert.IsTrue(resAsString.Contains($"\"instructions\":\"{instructions[i]}\"")); // instructions name
                Assert.IsTrue(resAsString.Contains($"\"amount\":{amount[i]}")); // amount of medicine
                Assert.IsTrue(resAsString.Contains($"\"name\":\"{medicineNames[i]}\"")); // Medicine name
            }
            
        }
    }
}
