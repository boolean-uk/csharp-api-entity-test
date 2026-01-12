using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using System.Diagnostics;
using System.Text.Json;
using workshop.wwwapi.DTOs;
using workshop.wwwapi.Models;

namespace workshop.tests;

public class Tests
{

    [Test] // Test that endpoint for getting patients works correctly and contains seeded patients
    public async Task GetPatients()
    {
        // Arrange: prepare request data
        var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
        var client = factory.CreateClient();

        // Act: make an API call using the shared _client instance
        var response = await client.GetAsync("/patients"); // send a GET request to the /patients endpoint to get all patients

        // Assert: check the response
        Assert.That(response.StatusCode == System.Net.HttpStatusCode.OK);

        // Read the response body and converts the JSON into a list of AppointmentWithDetailsDto objects.
        var contentStream = await response.Content.ReadAsStreamAsync();
        var patients = await JsonSerializer.DeserializeAsync<List<PatientWithAppointmentsDto>>(
            contentStream,
            new JsonSerializerOptions { PropertyNameCaseInsensitive = true }
        );
        Assert.That(patients, Is.Not.Null); // check that the patients list is not null
        Assert.That(patients.Count > 0); // check that the patients list contains at least one patient
        Assert.That(patients.Any(p => p.FullName == "Lionel Messi")); // check that the seeded patient is in the list

    }

    [Test] // Test that endpoint for getting a patient by ID returns the correct patient
    public async Task GetPatientById()
    {
        // Arrange: prepare request data
        var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
        var client = factory.CreateClient();

        // Act: make an API call using the shared _client instance
        var response = await client.GetAsync("/patients/1");

        // Assert: check the response
        Assert.That(response.StatusCode == System.Net.HttpStatusCode.OK);

        var contentStream = await response.Content.ReadAsStreamAsync();
        var patient = await JsonSerializer.DeserializeAsync<PatientWithAppointmentsDto>(
            contentStream,
            new JsonSerializerOptions { PropertyNameCaseInsensitive = true }
        );

        Assert.That(patient, Is.Not.Null);
        Assert.That(patient.FullName, Is.EqualTo("Lionel Messi"));
    }

    [Test] // Test that endpoint for adding a new patient works correctly
    public async Task AddPatient()
    {
        // Arrange: prepare request data
        var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
        var client = factory.CreateClient();
        var newPatient = new PersonPostDto { FullName = "Dimitar Berbatov" };
        var content = new StringContent(JsonSerializer.Serialize(newPatient), System.Text.Encoding.UTF8, "application/json");
        
        // Act: make an API call using the shared _client instance
        var response = await client.PostAsync("/patients", content);
        
        // Assert: check the response
        Assert.That(response.StatusCode == System.Net.HttpStatusCode.Created);

        var getResponse = await client.GetAsync("/patients"); // get all patients to check if the new patient was added
        var contentStream = await getResponse.Content.ReadAsStreamAsync();
        var patients = await JsonSerializer.DeserializeAsync<List<PatientWithAppointmentsDto>>(
            contentStream,
            new JsonSerializerOptions { PropertyNameCaseInsensitive = true }
        );
        Assert.That(patients, Is.Not.Null);
        Assert.That(patients.Any(p => p.FullName == "Dimitar Berbatov")); // check that the new patient is in the list

    }


}