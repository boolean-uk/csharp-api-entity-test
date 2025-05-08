using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Http;
using Moq;
using workshop.wwwapi.Endpoints;
using workshop.wwwapi.Models;
using workshop.wwwapi.Repository.SpecificRepositories;
using workshop.wwwapi.Repository;
using workshop.wwwapi.Models.Responses;

namespace workshop.tests
{
    public class PrescriptionTests
    {
        private Mock<IPrescriptionRepository> _mockRepo;
        private Mock<IAppointmentRepository> _mockAppointmentRepo;

        [SetUp]
        public void Setup()
        {
            _mockRepo = new Mock<IPrescriptionRepository>();
            _mockAppointmentRepo = new Mock<IAppointmentRepository>();
        }

        [Test]
        public async Task GetPrescriptions_ReturnsListOfPrescriptions()
        {
            // Arrange
            var prescriptions = new List<Prescription>
            {
                new Prescription { Id = 1, PatientId = 1, DoctorId = 1, Appointment = new Appointment { Patient = new Patient { FullName = "John Doe" }, Doctor = new Doctor { FullName = "Dr. Smith" } } },
                new Prescription { Id = 2, PatientId = 2, DoctorId = 2, Appointment = new Appointment { Patient = new Patient { FullName = "Jane Doe" }, Doctor = new Doctor { FullName = "Dr. Adams" } } }
            };

            _mockRepo.Setup(repo => repo.GetAllAsync()).ReturnsAsync(prescriptions);

            // Act
            var result = await PrescriptionEndpoints.GetPrescriptions(_mockRepo.Object) as Ok<List<PrescriptionDTO>>;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(StatusCodes.Status200OK, result.StatusCode);
            Assert.AreEqual(2, result.Value.Count);
        }

        [Test]
        public async Task GetPrescriptionById_ExistingId_ReturnsPrescription()
        {
            // Arrange
            var prescription = new Prescription
            {
                Id = 1,
                PatientId = 1,
                DoctorId = 1,
                PrescriptionMedicines = new List<PrescriptionMedicine>
                {
                    new PrescriptionMedicine { PrescriptionId = 1, MedicineId = 1, Quantity = 2, Notes = "Take with food" }
                }
            };

            _mockRepo.Setup(repo => repo.GetPrescriptionWithDetails(1)).ReturnsAsync(prescription);

            // Act
            var result = await PrescriptionEndpoints.GetPrescriptionById(_mockRepo.Object, 1) as Ok<Prescription>;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(StatusCodes.Status200OK, result.StatusCode);
            Assert.AreEqual(1, result.Value.Id);
        }

        [Test]
        public async Task GetPrescriptionById_NonExistingId_ReturnsNotFound()
        {
            // Arrange
            _mockRepo.Setup(repo => repo.GetPrescriptionWithDetails(99)).ReturnsAsync((Prescription)null);

            // Act
            var result = await PrescriptionEndpoints.GetPrescriptionById(_mockRepo.Object, 99) as NotFound;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(StatusCodes.Status404NotFound, result.StatusCode);
        }

        [Test]
        public async Task CreatePrescription_ValidPrescription_ReturnsCreatedResult()
        {
            // Arrange
            var newPrescription = new Prescription { Id = 3, PatientId = 1, DoctorId = 1 };

            _mockAppointmentRepo.Setup(repo => repo.GetAppointmentDetails(1, 1))
                .ReturnsAsync(new Appointment { PatientId = 1, DoctorId = 1 });

            _mockRepo.Setup(repo => repo.AddAsync(It.IsAny<Prescription>())).ReturnsAsync(newPrescription);

            // Act
            var result = await PrescriptionEndpoints.CreatePrescription(
                _mockRepo.Object, _mockAppointmentRepo.Object, newPrescription
            ) as Created<Prescription>;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(StatusCodes.Status201Created, result.StatusCode);
            Assert.AreEqual(3, result.Value.Id);
        }

        [Test]
        public async Task CreatePrescription_InvalidAppointment_ReturnsBadRequest()
        {
            // Arrange
            var newPrescription = new Prescription { Id = 4, PatientId = 99, DoctorId = 99 };

            _mockAppointmentRepo.Setup(repo => repo.GetAppointmentDetails(99, 99))
                .ReturnsAsync((Appointment)null);

            // Act
            var result = await PrescriptionEndpoints.CreatePrescription(
                _mockRepo.Object, _mockAppointmentRepo.Object, newPrescription
            ) as BadRequest<string>;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(StatusCodes.Status400BadRequest, result.StatusCode);
            Assert.AreEqual("No appointment found for Patient 99 and Doctor 99", result.Value);
        }
    }
}
