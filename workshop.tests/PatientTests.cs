using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using Moq;
using workshop.wwwapi.DTOs;
using workshop.wwwapi.Endpoints;
using workshop.wwwapi.Models;
using workshop.wwwapi.Repository;

namespace workshop.tests;

public class Tests
{
    [Test]
    public async Task CreatePatient_ShouldReturnCreatedResult_WhenPatientIsValid()
    {
        // Arrange
        var mockRepository = new Mock<IRepository<Patient>>();
        var patientDTO = new CreatePatientDTO { Id = 1, fullName = "Jane Doe" };
        var patient = new Patient { Id = 1, FullName = "Jane Doe" };

        mockRepository.Setup(repo => repo.Add(It.IsAny<Patient>())).Verifiable();

        // Act
        var result = await SurgeryEndpoint.createPatient(mockRepository.Object, patientDTO);

        // Assert
        var typedResult = result as StatusCodeResult;
        Assert.NotNull(typedResult);
        Assert.AreEqual(StatusCodes.Status201Created, typedResult.StatusCode);
    }

    [Test]
    public async Task GetPatients_ShouldReturnOkResult_WithListOfPatients()
    {
        // Arrange
        var mockRepository = new Mock<IRepository<Patient>>();
        var patients = new List<Patient>
        {
            new Patient { Id = 1, FullName = "Jane Doe" },
            new Patient { Id = 2, FullName = "John Doe" }
        };

        mockRepository.Setup(repo => repo.GetAll()).ReturnsAsync(patients);

        // Act
        var result = await SurgeryEndpoint.GetPatients(mockRepository.Object);

        // Assert
        var typedResult = result as OkObjectResult;
        Assert.NotNull(typedResult);
        var patientDTOs = typedResult.Value as List<PatientDTO>;
        Assert.NotNull(patientDTOs);
        Assert.AreEqual(2, patientDTOs.Count);
    }

    [Test]
    public async Task GetPatient_ShouldReturnOkResult_WithPatientAndAppointments()
    {
        // Arrange
        var mockPatientRepo = new Mock<IRepository<Patient>>();
        var mockAppointmentRepo = new Mock<IAppointmentRepository>();

        var patient = new Patient { Id = 1, FullName = "Jane Doe" };
        var appointments = new List<Appointment>
        {
            new Appointment { Booking = DateTime.UtcNow, DoctorId = 1, PatientId = 1, doctor = new Doctor { Id = 1, FullName = "Dr. Smith" } }
        };

        mockPatientRepo.Setup(repo => repo.GetOne(1)).ReturnsAsync(patient);
        mockAppointmentRepo.Setup(repo => repo.getAppointmentByPatient(1)).ReturnsAsync(appointments);

        // Act
        var result = await SurgeryEndpoint.getPatient(mockAppointmentRepo.Object, mockPatientRepo.Object, 1);

        // Assert
        var typedResult = result as OkObjectResult;
        Assert.NotNull(typedResult);
        var patientDTO = typedResult.Value as PatientDTO;
        Assert.NotNull(patientDTO);
        Assert.AreEqual(1, patientDTO.Id);
        Assert.AreEqual(1, patientDTO.appointments.Count);
    }


    [Test]
    public async Task GetDoctors_ShouldReturnOkResult_WithListOfDoctors()
    {
        // Arrange
        var mockRepository = new Mock<IRepository<Doctor>>();
        var doctors = new List<Doctor>
        {
            new Doctor { Id = 1, FullName = "Dr. Smith" },
            new Doctor { Id = 2, FullName = "Dr. Jones" }
        };

        mockRepository.Setup(repo => repo.GetAll()).ReturnsAsync(doctors);

        // Act
        var result = await SurgeryEndpoint.GetDoctors(mockRepository.Object);

        // Assert
        var typedResult = result as OkObjectResult;
        Assert.NotNull(typedResult);
        var doctorDTOs = typedResult.Value as List<DoctorDTO>;
        Assert.NotNull(doctorDTOs);
        Assert.AreEqual(2, doctorDTOs.Count);
    }

    [Test]
    public async Task GetAppointments_ShouldReturnOkResult_WithListOfAppointments()
    {
        // Arrange
        var mockRepository = new Mock<IRepository<Appointment>>();
        var appointments = new List<Appointment>
        {
            new Appointment { Id = 1, doctor = new Doctor { Id = 1, FullName = "Dr. Smith" }, patient = new Patient { Id = 1, FullName = "Jane Doe" } }
        };

        mockRepository.Setup(repo => repo.GetAll()).ReturnsAsync(appointments);

        // Act
        var result = await SurgeryEndpoint.GetAppointments(mockRepository.Object);

        // Assert
        var typedResult = result as OkObjectResult;
        Assert.NotNull(typedResult);
        var appointmentDTOs = typedResult.Value as List<GetAppointmentDTO>;
        Assert.NotNull(appointmentDTOs);
        Assert.AreEqual(1, appointmentDTOs.Count);
    }

    [Test]
    public async Task GetAppointmentsByDoctor_ShouldReturnOkResult_WithListOfAppointments()
    {
        // Arrange
        var mockRepository = new Mock<IAppointmentRepository>();
        var appointments = new List<Appointment>
        {
            new Appointment { Id = 1, doctor = new Doctor { Id = 1, FullName = "Dr. Smith" }, patient = new Patient { Id = 1, FullName = "Jane Doe" } }
        };

        mockRepository.Setup(repo => repo.getAppointmentByDoctor(1)).ReturnsAsync(appointments);

        // Act
        var result = await SurgeryEndpoint.GetAppointmentsByDoctor(mockRepository.Object, 1);

        // Assert
        var typedResult = result as OkObjectResult;
        Assert.NotNull(typedResult);
        var appointmentDTOs = typedResult.Value as List<GetAppointmentDTO>;
        Assert.NotNull(appointmentDTOs);
        Assert.AreEqual(1, appointmentDTOs.Count);
    }
}
