using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Http;
using workshop.wwwapi.Endpoints;
using workshop.wwwapi.Models.Responses;
using workshop.wwwapi.Models;
using workshop.wwwapi.Repository;
using Moq;

namespace workshop.tests
{
    public class DoctorTests
    {
        private Mock<IDoctorRepository> _mockRepo;

        [SetUp]
        public void Setup()
        {
            _mockRepo = new Mock<IDoctorRepository>();
        }

        [Test]
        public async Task GetDoctors_ReturnsListOfDoctors()
        {
            // Arrange
            var doctors = new List<Doctor>
            {
                new Doctor { Id = 1, FullName = "Dr. House", Appointments = new List<Appointment>() },
                new Doctor { Id = 2, FullName = "Dr. Grey", Appointments = new List<Appointment>() }
            };

            _mockRepo.Setup(repo => repo.GetAllAsync()).ReturnsAsync(doctors);

            // Act
            var result = await DoctorEndpoints.GetDoctors(_mockRepo.Object) as Ok<List<DoctorDTO>>;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(StatusCodes.Status200OK, result.StatusCode);
            Assert.AreEqual(2, result.Value.Count);
        }

        [Test]
        public async Task CreateDoctor_ValidDoctor_ReturnsCreatedResult()
        {
            // Arrange
            var newDoctor = new Doctor { Id = 3, FullName = "Dr. Wilson" };
            _mockRepo.Setup(repo => repo.AddAsync(It.IsAny<Doctor>())).ReturnsAsync(newDoctor);

            // Act
            var result = await DoctorEndpoints.CreateDoctor(_mockRepo.Object, newDoctor) as Created<Doctor>;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(StatusCodes.Status201Created, result.StatusCode);
            Assert.AreEqual(newDoctor.FullName, result.Value.FullName);
        }
    }
}
