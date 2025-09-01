using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using workshop.wwwapi.Data;
using workshop.wwwapi.Models;
using workshop.wwwapi.Repository;

namespace workshop.tests;

public class RepositoryTests
{
    private Seeder _seeder;

    [SetUp]
    public void Setup()
    {
        _seeder = new Seeder();
    }

    [Test]
    public async Task GetPatientsTest()
    {
        // Arrange
        var repository = new Repository(TestUtils.CreateNewContext());
        var expected = _seeder.Patients;

        // Act
        var result = (await repository.GetPatients()).ToList();

        // Assert
        Assert.That(result, Is.Not.Empty);
        Assert.That(result, Has.Count.EqualTo(expected.Count));
        for (var index = 0; index < result.Count; index++)
        {
            Assert.That(expected[index].FullName, Is.EqualTo(result[index].FullName));
        }
    }

    [Test]
    public async Task GetPatientTest()
    {
        // Arrange
        var repository = new Repository(TestUtils.CreateNewContext());
        var expected = _seeder.Patients[0];

        // Act
        var result = await repository.GetPatient(1);

        // Assert
        Assert.That(result, Is.Not.Null);
        Assert.That(result.FullName, Is.EqualTo(expected.FullName));
    }
    
    [Test]
    public async Task CreatePatientTest()
    {
        // Arrange
        var repository = new Repository(TestUtils.CreateNewContext());
        
        var expected = new Patient()
        {
            FullName = "New Test Patient",
        };

        // Act
        var result = await repository.CreatePatient(expected);
        var listPatients = (await repository.GetPatients()).ToList();
        
        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(result.FullName, Is.EqualTo(expected.FullName));
            Assert.That(listPatients.Last().FullName, Is.EqualTo(expected.FullName));
        });
    }
    
    [Test]
    public async Task GetDoctorsTest()
    {
        // Arrange
        var repository = new Repository(TestUtils.CreateNewContext());
        var expected = _seeder.Doctors;

        // Act
        var result = (await repository.GetDoctors()).ToList();

        // Assert
        Assert.That(result, Is.Not.Empty);
        Assert.That(result, Has.Count.EqualTo(expected.Count));
        for (var index = 0; index < result.Count; index++)
        {
            Assert.That(expected[index].FullName, Is.EqualTo(result[index].FullName));
        }
    }
    
    [Test]
    public async Task GetDoctorTest()
    {
        // Arrange
        var repository = new Repository(TestUtils.CreateNewContext());
        var expected = _seeder.Doctors[0];

        // Act
        var result = await repository.GetDoctor(1);

        // Assert
        Assert.That(result, Is.Not.Null);
        Assert.That(result.FullName, Is.EqualTo(expected.FullName));
    }
    
    [Test]
    public async Task CreateDoctorTest()
    {
        // Arrange
        var repository = new Repository(TestUtils.CreateNewContext());
        var expected = new Doctor()
        {
            FullName = "New Test Doctor",
        };

        // Act
        var result = await repository.CreateDoctor(expected);
        var listPatients = (await repository.GetDoctors()).ToList();
        
        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(result.FullName, Is.EqualTo(expected.FullName));
            Assert.That(listPatients.Last().FullName, Is.EqualTo(expected.FullName));
        });
    }
    
    [Test]
    public async Task GetAppointmentsTest()
    {
        // Arrange
        var repository = new Repository(TestUtils.CreateNewContext());
        var expected = _seeder.Appointments;

        // Act
        var result = (await repository.GetAppointments()).ToList();

        // Assert
        Assert.That(result, Is.Not.Empty);
        Assert.That(result, Has.Count.EqualTo(expected.Count));
        for (var index = 0; index < result.Count; index++)
        {
            Assert.That(expected[index].Id, Is.EqualTo(result[index].Id));
        }
    }
    
    [Test]
    public async Task GetAppointmentTest()
    {
        // Arrange
        var repository = new Repository(TestUtils.CreateNewContext());
        var expected = new Appointment()
        {
            Id = 1,
            PatientId = 1,
            DoctorId = 1,
        };

        // Act
        var result = await repository.GetAppointment(1);

        // Assert
        Assert.That(result, Is.Not.Null);
        Assert.Multiple(() =>
        {
            Assert.That(result.DoctorId, Is.EqualTo(expected.DoctorId));
            Assert.That(result.PatientId, Is.EqualTo(expected.PatientId));
        });
    }
    
    [Test]
    public async Task GetAppointmentsByDoctorTest()
    {
        // Arrange
        var repository = new Repository(TestUtils.CreateNewContext());
        var expected = new List<Appointment>()
        {
            new() { Id = 1, DoctorId = 1, },
            new() { Id = 3, DoctorId = 1, },
        };
        
        // Act
        var result = (await repository.GetAppointmentsByDoctor(1)).ToList();

        // Assert
        Assert.That(result, Is.Not.Empty);
        for (var index = 0; index < result.Count; index++)
        {
            Assert.That(expected[index].Id, Is.EqualTo(result[index].Id));
        }
    }
    
    [Test]
    public async Task GetAppointmentsByPatientTest()
    {
        // Arrange
        var repository = new Repository(TestUtils.CreateNewContext());
        var expected = new List<Appointment>()
        {
            new() { Id = 1, PatientId = 1, },
            new() { Id = 2, PatientId = 1, },
        };
        
        // Act
        var result = (await repository.GetAppointmentsByPatient(1)).ToList();

        // Assert
        Assert.That(result, Is.Not.Empty);
        for (var index = 0; index < result.Count; index++)
        {
            Assert.That(expected[index].Id, Is.EqualTo(result[index].Id));
        }
    }
    
    [Test]
    public async Task CreateAppointmentTest()
    {
        // Arrange
        var repository = new Repository(TestUtils.CreateNewContext());
        var expected = new Appointment()
        {
            DoctorId = 3,
            PatientId = 3,
        };

        // Act
        var result = await repository.CreateAppointment(expected);
        var listPatients = (await repository.GetAppointments()).ToList();
        
        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(result.DoctorId, Is.EqualTo(expected.DoctorId));
            Assert.That(result.PatientId, Is.EqualTo(expected.PatientId));
            
            var last = listPatients.Last();
            Assert.That(last.DoctorId, Is.EqualTo(expected.DoctorId));
            Assert.That(last.PatientId, Is.EqualTo(expected.PatientId));
        });
    }

   
}