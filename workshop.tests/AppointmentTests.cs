using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Http;
using Moq;
using workshop.wwwapi.Endpoints;
using workshop.wwwapi.Models.Responses;
using workshop.wwwapi.Models;
using workshop.wwwapi.Repository;

namespace workshop.tests
{
    public class AppointmentTests
    {
        private Mock<IAppointmentRepository> _mockRepo;
        private Mock<IPatientRepository> _mockPatientRepo;
        private Mock<IDoctorRepository> _mockDoctorRepo;

        [SetUp]
        public void Setup()
        {
            _mockRepo = new Mock<IAppointmentRepository>();
            _mockPatientRepo = new Mock<IPatientRepository>();
            _mockDoctorRepo = new Mock<IDoctorRepository>();
        }

        [Test]
        public async Task GetAppointments_ReturnsListOfAppointments()
        {
            // Arrange
            var appointments = new List<Appointment>
            {
                new Appointment {
                    PatientId = 1, DoctorId = 1, Booking = DateTime.UtcNow,
                    Patient = new Patient { Id = 1, FullName = "John Doe" },
                    Doctor = new Doctor { Id = 1, FullName = "Dr. House" }
                },
                new Appointment {
                    PatientId = 2, DoctorId = 2, Booking = DateTime.UtcNow.AddDays(1),
                    Patient = new Patient { Id = 2, FullName = "Jane Smith" },
                    Doctor = new Doctor { Id = 2, FullName = "Dr. Grey" }
                }
            };

            _mockRepo.Setup(repo => repo.GetAllAsync()).ReturnsAsync(appointments);

            // Act
            var result = await AppointmentEndpoints.GetAppointments(_mockRepo.Object) as Ok<List<AppointmentDTO>>;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(StatusCodes.Status200OK, result.StatusCode);
            Assert.AreEqual(2, result.Value.Count);
        }

        [Test]
        public async Task CreateAppointment_ValidAppointment_ReturnsCreatedResult()
        {
            // Arrange
            var newAppointment = new Appointment { PatientId = 3, DoctorId = 1, Booking = DateTime.UtcNow };

            _mockPatientRepo.Setup(repo => repo.GetByIdAsync(3)).ReturnsAsync(new Patient { Id = 3, FullName = "Alice" });
            _mockDoctorRepo.Setup(repo => repo.GetByIdAsync(1)).ReturnsAsync(new Doctor { Id = 1, FullName = "Dr. House" });
            _mockRepo.Setup(repo => repo.AddAsync(It.IsAny<Appointment>())).ReturnsAsync(newAppointment);

            // Act
            var result = await AppointmentEndpoints.CreateAppointment(
                _mockRepo.Object, _mockPatientRepo.Object, _mockDoctorRepo.Object, newAppointment
            ) as Created<Appointment>;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(StatusCodes.Status201Created, result.StatusCode);
            Assert.AreEqual(newAppointment.PatientId, result.Value.PatientId);
        }
    }
}
