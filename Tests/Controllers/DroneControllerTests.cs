using asset_management.Controllers;
using asset_management.Models.Drones;
using asset_management.Models.Drones;
using Microsoft.AspNetCore.Mvc;
using Moq;


namespace asset_management.Tests
{
    [TestFixture]
    public class DroneControllerTests
    {
        private Mock<IDroneService> _droneServiceMock;
        private DroneController _droneController;

        [SetUp]
        public void Setup()
        {
            _droneServiceMock = new Mock<IDroneService>();
            _droneController = new DroneController(_droneServiceMock.Object);
        }

        [Test]
        public void GetAllDronesTest()
        {
            var droneList = new List<Drone>
            {
                new Drone { DroneId = 1, OrganizationId = 1 },
                new Drone { DroneId = 2, OrganizationId = 1 }
            };
            _droneServiceMock.Setup(service => service.GetAll()).Returns(droneList);
            var result = _droneController.Get() as OkObjectResult;

            // Assertions
            var HTTP_OK = 200;
            var EXPECTED_COUNT = 2;

            Assert.IsNotNull(result);
            Assert.That(HTTP_OK, Is.EqualTo(result.StatusCode));
            var drones = result.Value as List<Drone>;
            Assert.IsNotNull(drones);
            Assert.That(EXPECTED_COUNT, Is.EqualTo(drones.Count));
            _droneServiceMock.Verify(service => service.GetAll(), Times.Once);
        }
        public void PostDronesTest()
        {
            var droneCreateRequest = new DroneCreateRequest { OrganizationId = 1, Model = "QuadSAT Ranger" };
            var createdDrone = new Drone { OrganizationId = 1, Model = "QuadSAT Ranger" };

            _droneServiceMock.Setup(service => service.Create(droneCreateRequest)).Returns(createdDrone);
            var result = _droneController.Post(droneCreateRequest) as OkObjectResult;

            // Assertions
            var HTTP_OK = 200;

            Assert.IsNotNull(result);
            Assert.That(HTTP_OK, Is.EqualTo(result.StatusCode));

            var drone = result.Value as Drone;

            Assert.IsNotNull(drone);
            Assert.That(createdDrone.DroneId, Is.EqualTo(drone.DroneId));
            _droneServiceMock.Verify(service => service.Create(droneCreateRequest), Times.Once);
        }

        [Test]
        public void PutDroneTest()
        {
            int droneId = 1;
            var droneUpdateRequest = new DroneUpdateRequest { OrganizationId = 1, Model = "QuadSAT Ranger 1" };
            var updatedDrone = new Drone { OrganizationId = 1, Model = "QuadSAT Ranger 2" };
            _droneServiceMock.Setup(service => service.Update(droneId, droneUpdateRequest)).Returns(updatedDrone);

            var result = _droneController.Put(droneId, droneUpdateRequest) as OkObjectResult;

            // Assertions
            var HTTP_OK = 200;

            Assert.IsNotNull(result);
            Assert.That(HTTP_OK, Is.EqualTo(result.StatusCode));
            var drone = result.Value as Drone;
            Assert.IsNotNull(drone);
            Assert.That(updatedDrone.DroneId, Is.EqualTo(drone.DroneId));
            _droneServiceMock.Verify(service => service.Update(droneId, droneUpdateRequest), Times.Once);
        }

        [Test]
        public void DeleteDroneTest()
        {
            int droneId = 1;
            _droneServiceMock.Setup(service => service.Delete(droneId));

            var result = _droneController.Delete(droneId) as OkObjectResult;

            // Assertions
            var HTTP_OK = 200;

            Assert.IsNotNull(result);
            Assert.That(HTTP_OK, Is.EqualTo(result.StatusCode));

            _droneServiceMock.Verify(service => service.Delete(droneId), Times.Once);
        }
    }
}