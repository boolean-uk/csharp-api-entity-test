using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using workshop.wwwapi.Models;

namespace workshop.tests;

public class Tests
{

    [Test]
    public async Task PatientEndpointStatus()
    {
        // Arrange
        var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
        var client = factory.CreateClient();
        var expectedData = new List<Patient>
            {
                new Patient { Id = 1, FullName = "Elias Soprani" },
                new Patient { Id = 2, FullName = "Olga Alm" },
                new Patient { Id = 3, FullName = "Oskar Damkilde" },
                new Patient { Id = 4, FullName = "Gabriel Letell" },
                new Patient { Id = 5, FullName = "Samuel Vacha" },
                new Patient { Id = 6, FullName = "Theodor Johansson" }
            };
        // Act
        var response = await client.GetAsync("/patients");

        // Assert
        Assert.IsTrue(response.StatusCode == System.Net.HttpStatusCode.OK);
         for (int i = 0; i < expectedData.Count; i++)
            {
                Assert.That(expectedData[i], Is.EqualTo(response[i], new PatientEqualityComparer()));
            }
        
    }

       public class PatientEqualityComparer : IEqualityComparer<Patient>
    {
        public bool Equals(Patient x, Patient y)
        {
            return x.Id == y.Id && x.FullName == y.FullName;
        }

        public int GetHashCode(Patient obj)
        {
            return (obj.Id, obj.FullName).GetHashCode();
        }
    }
}