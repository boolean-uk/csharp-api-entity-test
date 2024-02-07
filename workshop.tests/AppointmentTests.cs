using Microsoft.AspNetCore.Mvc.Testing;
using workshop.wwwapi.Models;

namespace workshop.tests;

public class AppointmentTests
{

    [Test]
    public async Task AppointmentsEndpointStatus()
    {
        // Arrange
        var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
        var client = factory.CreateClient();

        // Act
        var response = await client.GetAsync("/surgery/doctors");

        // Assert
        Assert.IsTrue(response.StatusCode == System.Net.HttpStatusCode.OK);
    }

    [Test]
    public async Task GetAppointmentsResponse()
    {
        // Arrange
        var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
        var client = factory.CreateClient();

        var expectedPayload = new List<Appointment>()
            {
                new Appointment { Booking = new DateTime(2024,01,31), DoctorId = 1, PatientId = 1 },
                new Appointment { Booking = new DateTime(2024,01,31), DoctorId = 1, PatientId = 2 },
                new Appointment { Booking = new DateTime(2024,01,31), DoctorId = 2, PatientId = 1 },
                new Appointment { Booking = new DateTime(2024,01,31), DoctorId = 2, PatientId = 2 }
            };

        // Act
        var response = await client.GetAsync("/surgery/appointments");
        string responeJson = await response.Content.ReadAsStringAsync();

        // Assert
        Assert.That(response.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.OK));

        //Assert.That(responsePayload.Result.Count(), Is.EqualTo(3));

        string expectedJson = "[{\"booking\":\"2024-01-31T12:26:16.098426Z\",\"doctor\":{\"id\":1,\"fullName\":\"Dr.Johanna\"},\"patient\":{\"id\":1,\"fullName\":\"Klas Bengtsson\"}},{\"booking\":\"2024-01-31T12:26:16.098427Z\",\"doctor\":{\"id\":2,\"fullName\":\"Dr.Jon\"},\"patient\":{\"id\":1,\"fullName\":\"Klas Bengtsson\"}},{\"booking\":\"2024-01-31T12:26:16.098427Z\",\"doctor\":{\"id\":1,\"fullName\":\"Dr.Johanna\"},\"patient\":{\"id\":2,\"fullName\":\"Kerstin Gunnarsson\"}},{\"booking\":\"2024-01-31T12:26:16.098427Z\",\"doctor\":{\"id\":2,\"fullName\":\"Dr.Jon\"},\"patient\":{\"id\":2,\"fullName\":\"Kerstin Gunnarsson\"}},{\"booking\":\"2024-01-31T16:07:15.070528Z\",\"doctor\":{\"id\":3,\"fullName\":\"Dr. new\"},\"patient\":{\"id\":1,\"fullName\":\"Klas Bengtsson\"}}]";

        StringAssert.AreEqualIgnoringCase(expectedJson, responeJson);
    }
}