using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;

namespace workshop.tests;

public class Tests
{
    // seeded values
    private string _getAllPatient = "[{\"fullName\":\"Patrick\",\"appointments\":[{\"doctorId\":1,\"doctorName\":\"Adam Doe\",\"booking\":\"2025-08-21T09:37:00.825534Z\",\"type\":0},{\"doctorId\":2,\"doctorName\":\"Florian Frank\",\"booking\":\"2025-08-21T09:37:00.825585Z\",\"type\":0},{\"doctorId\":3,\"doctorName\":\"Bob Bagel\",\"booking\":\"2025-08-21T09:37:00.825586Z\",\"type\":0}]},{\"fullName\":\"Spongebob\",\"appointments\":[{\"doctorId\":2,\"doctorName\":\"Florian Frank\",\"booking\":\"2025-08-21T09:37:00.825586Z\",\"type\":1},{\"doctorId\":3,\"doctorName\":\"Bob Bagel\",\"booking\":\"2025-08-21T09:37:00.825586Z\",\"type\":1},{\"doctorId\":4,\"doctorName\":\"Robert Bank\",\"booking\":\"2025-08-21T09:37:00.825586Z\",\"type\":1}]},{\"fullName\":\"Sandy\",\"appointments\":[{\"doctorId\":3,\"doctorName\":\"Bob Bagel\",\"booking\":\"2025-08-21T09:37:00.825586Z\",\"type\":0},{\"doctorId\":4,\"doctorName\":\"Robert Bank\",\"booking\":\"2025-08-21T09:37:00.825586Z\",\"type\":0},{\"doctorId\":5,\"doctorName\":\"Leonardo Gonzalez\",\"booking\":\"2025-08-21T09:37:00.825589Z\",\"type\":0}]},{\"fullName\":\"Mr Crabs\",\"appointments\":[{\"doctorId\":1,\"doctorName\":\"Adam Doe\",\"booking\":\"2025-08-21T09:37:00.825589Z\",\"type\":1},{\"doctorId\":4,\"doctorName\":\"Robert Bank\",\"booking\":\"2025-08-21T09:37:00.825589Z\",\"type\":1},{\"doctorId\":5,\"doctorName\":\"Leonardo Gonzalez\",\"booking\":\"2025-08-21T09:37:00.825589Z\",\"type\":1}]},{\"fullName\":\"Squidward\",\"appointments\":[{\"doctorId\":1,\"doctorName\":\"Adam Doe\",\"booking\":\"2025-08-21T09:37:00.825589Z\",\"type\":0},{\"doctorId\":2,\"doctorName\":\"Florian Frank\",\"booking\":\"2025-08-21T09:37:00.825589Z\",\"type\":0},{\"doctorId\":5,\"doctorName\":\"Leonardo Gonzalez\",\"booking\":\"2025-08-21T09:37:00.825589Z\",\"type\":0}]}]";
    private string _getAllDoctor = "[{\"fullName\":\"Patrick\",\"appointments\":[{\"doctorId\":1,\"doctorName\":\"Adam Doe\",\"booking\":\"2025-08-21T09:37:00.825534Z\",\"type\":0},{\"doctorId\":2,\"doctorName\":\"Florian Frank\",\"booking\":\"2025-08-21T09:37:00.825585Z\",\"type\":0},{\"doctorId\":3,\"doctorName\":\"Bob Bagel\",\"booking\":\"2025-08-21T09:37:00.825586Z\",\"type\":0}]},{\"fullName\":\"Spongebob\",\"appointments\":[{\"doctorId\":2,\"doctorName\":\"Florian Frank\",\"booking\":\"2025-08-21T09:37:00.825586Z\",\"type\":1},{\"doctorId\":3,\"doctorName\":\"Bob Bagel\",\"booking\":\"2025-08-21T09:37:00.825586Z\",\"type\":1},{\"doctorId\":4,\"doctorName\":\"Robert Bank\",\"booking\":\"2025-08-21T09:37:00.825586Z\",\"type\":1}]},{\"fullName\":\"Sandy\",\"appointments\":[{\"doctorId\":3,\"doctorName\":\"Bob Bagel\",\"booking\":\"2025-08-21T09:37:00.825586Z\",\"type\":0},{\"doctorId\":4,\"doctorName\":\"Robert Bank\",\"booking\":\"2025-08-21T09:37:00.825586Z\",\"type\":0},{\"doctorId\":5,\"doctorName\":\"Leonardo Gonzalez\",\"booking\":\"2025-08-21T09:37:00.825589Z\",\"type\":0}]},{\"fullName\":\"Mr Crabs\",\"appointments\":[{\"doctorId\":1,\"doctorName\":\"Adam Doe\",\"booking\":\"2025-08-21T09:37:00.825589Z\",\"type\":1},{\"doctorId\":4,\"doctorName\":\"Robert Bank\",\"booking\":\"2025-08-21T09:37:00.825589Z\",\"type\":1},{\"doctorId\":5,\"doctorName\":\"Leonardo Gonzalez\",\"booking\":\"2025-08-21T09:37:00.825589Z\",\"type\":1}]},{\"fullName\":\"Squidward\",\"appointments\":[{\"doctorId\":1,\"doctorName\":\"Adam Doe\",\"booking\":\"2025-08-21T09:37:00.825589Z\",\"type\":0},{\"doctorId\":2,\"doctorName\":\"Florian Frank\",\"booking\":\"2025-08-21T09:37:00.825589Z\",\"type\":0},{\"doctorId\":5,\"doctorName\":\"Leonardo Gonzalez\",\"booking\":\"2025-08-21T09:37:00.825589Z\",\"type\":0}]}]";

    [Test]
    public async Task PatientEndpointStatusOk()
    {
        // Arrange
        var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
        var client = factory.CreateClient();

        // Act
        var response = await client.GetAsync("/surgery/patients");

        // Assert
        Assert.That(response.StatusCode == System.Net.HttpStatusCode.OK);

        var content = await response.Content.ReadAsStringAsync();
        Console.WriteLine(content);

        Assert.That(content == _getAllPatient);
    }

    [Test]
    public async Task DoctorEndpointStatusOk()
    {
        // Arrange
        var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
        var client = factory.CreateClient();

        // Act
        var response = await client.GetAsync("/surgery/doctors");
        var content = await response.Content.ReadAsStringAsync();
        Console.WriteLine(content);

        // Assert
        Assert.That(response.StatusCode == System.Net.HttpStatusCode.OK);

        Assert.That(content == _getAllDoctor);
    }

    [Test]
    public async Task PatientIdEndPointStatusOk()
    {
        // Arrange
        var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
        var client = factory.CreateClient();

        // Act
        int id = 1;
        string requestUrl = $"/surgery/appointmentsbypatient/{id}";
        var response = await client.GetAsync(requestUrl);

        // Assert
        Assert.That(response.StatusCode == System.Net.HttpStatusCode.OK);
    }

    [Test]
    public async Task PatientIdEndPointStatusNotFound()
    {
        // Arrange
        var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
        var client = factory.CreateClient();

        // Act
        int id = 100000;
        string requestUrl = $"/surgery/appointmentsbypatient/{id}";
        var response = await client.GetAsync(requestUrl);

        // Assert
        Assert.That(response.StatusCode == System.Net.HttpStatusCode.NotFound);
    }

    [Test]
    public async Task DoctorIdEndPointStatusOk()
    {
        // Arrange
        var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
        var client = factory.CreateClient();

        // Act
        int id = 1;
        string requestUrl = $"/surgery/appointmentsbydoctor/{id}";
        var response = await client.GetAsync(requestUrl);

        // Assert
        Assert.That(response.StatusCode == System.Net.HttpStatusCode.OK);
    }

    [Test]
    public async Task DoctorIdEndPointStatusNotFound()
    {
        // Arrange
        var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
        var client = factory.CreateClient();

        // Act
        int id = 100000;
        string requestUrl = $"/surgery/appointmentsbydoctor/{id}";
        var response = await client.GetAsync(requestUrl);

        // Assert
        Assert.That(response.StatusCode == System.Net.HttpStatusCode.NotFound);
    }
}