using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using Newtonsoft.Json;
using workshop.wwwapi.DTO;
using System.Text;
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

        // Act
        var response = await client.GetAsync("/surgery/patients");

        // Assert
        Assert.IsTrue(response.StatusCode == System.Net.HttpStatusCode.OK);
    }
    [Test]
    public async Task PostPatientEndpointStatus()
    {
        //Arrange
        var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
        var client = factory.CreateClient();

        DTOPatientNoId input = new DTOPatientNoId() 
        {
            Name = "TestSubject112"
        };

        var json = new StringContent(JsonConvert.SerializeObject(input),UTF8Encoding.UTF8, "application/json");

        //Act
        var response = await client.PostAsync("/surgery/patients/", json);

        //Assert
        Assert.IsTrue(response.StatusCode == System.Net.HttpStatusCode.Created);
    }
    [Test]
    public async Task DoctorCheck()
    {
        //Arrange
        var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
        var client = factory.CreateClient();


        //Act
        var response = await client.GetAsync("/surgery/doctors");
        var json = await response.Content.ReadAsStringAsync();
        var doctors = JsonConvert.DeserializeObject<GetDoctorResponce>(json);
        var doctor = doctors.DoctorNoId.First();


        //Assert
        Assert.That(doctor.Name, Is.EqualTo("Doctor Coleman"));
    }
}