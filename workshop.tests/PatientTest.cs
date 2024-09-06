using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using Newtonsoft.Json;
using System.Net.Http.Json;
using System.Text;
using workshop.wwwapi.DTO;
using static System.Net.WebRequestMethods;

namespace workshop.tests;

public class EndpointTests
{
    
    [Test]
    public async Task PatientEndpointStatus()
    {
        // Arrange
        //We use WebApplicationFactory to create an in-memory test server hosting your application.
        var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });

        //This line creates an HTTP client configured to interact with the test server created by the WebApplicationFactory.
        var client = factory.CreateClient();

        // Act
        // Sends a GET request to the "/patients" endpoint to retrieve patient data.
        var response = await client.GetAsync("surgery/patients");
        var responseDTO = await client.GetFromJsonAsync<List<PatientDTO>>("surgery/patients");

        // Assert
        // Verifies that the response status code is HTTP 200 OK.
        Assert.IsTrue(response.StatusCode == System.Net.HttpStatusCode.OK);
        Assert.That(responseDTO.Count, Is.AtLeast(2));
    }
    
    [Test]
    public async Task DoctorEndpointStatus()
    {
        // Arrange
        var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
        var client = factory.CreateClient();

        // Act
        var response = await client.GetAsync("surgery/doctors");
        var responseDTO = await client.GetFromJsonAsync<List<PatientDTO>>("surgery/doctors");


        // Assert
        Assert.IsTrue(response.StatusCode == System.Net.HttpStatusCode.OK);
        Assert.That(responseDTO.Count, Is.AtLeast(2));

    }

    [Test]
    public async Task AppointmentEndpointStatus()
    {
        // Arrange
        var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
        var client = factory.CreateClient();

        // Act
        var response = await client.GetAsync("surgery/appointments");
        var responseDTO = await client.GetFromJsonAsync<List<AppointmentDTO>>("surgery/appointments");


        // Assert
        Assert.IsTrue(response.StatusCode == System.Net.HttpStatusCode.OK);
    }

    
    /*--------------------------------------------------Post----------------------------------------------------*/
    
    [Test]
    public async Task CreateDoctorEndpointStatus()
    {
        // Arrange
        //Creating a test factory for the web application (WebapplicationFactory) and configure it.
        var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });

        //Creating an HTTP client to make requests to the application
        var client = factory.CreateClient();

        //Create JSON content representing a new doctor with a full name
        var content = new StringContent(
            //JsonConvert.SerializeObject() is a method provided by the JSON.NET library
            //It converts an object in this case, an instance of CreateDoctorDTO  into a JSON string.
            JsonConvert.SerializeObject(new CreateDoctorDTO { FullName = "J-Hope" }),
            Encoding.UTF8,
            "application/json"
        );

        // Act
        //Send a POST request to the /doctors endpoint with the JSON content representing the new doctor
        var response = await client.PostAsync("surgery/doctors", content);

        // Assert
        // Assert that the HTTP response status code is Created (HTTP 201), indicating that the doctor was successfully created
        Assert.IsTrue(response.StatusCode == System.Net.HttpStatusCode.Created);
    }

    [Test]
    public async Task CreatePatientEndpointStatus()
    {
        // Arrange
        var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
        var client = factory.CreateClient();
        var content = new StringContent(
            JsonConvert.SerializeObject(new CreatePatientDTO { FullName = "Jin" }),
            Encoding.UTF8,
            "application/json"
        );

        // Act
        var response = await client.PostAsync("surgery/patients", content);

        // Assert
        Assert.IsTrue(response.StatusCode == System.Net.HttpStatusCode.Created);
    }


    [Test]
    public async Task CreateAppointmentEndpointStatus()
    {
        // Arrange
        var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
        var client = factory.CreateClient();
        var content = new StringContent(
            JsonConvert.SerializeObject(new CreateAppointmentDTO { PatientId = 1, DoctorId = 1, Booking = DateTime.Now }),
            Encoding.UTF8,
            "application/json"
        );

        // Act
        var response = await client.PostAsync("surgery/appointments", content);

        // Assert
        Assert.IsTrue(response.StatusCode == System.Net.HttpStatusCode.Created);
    }


    



}