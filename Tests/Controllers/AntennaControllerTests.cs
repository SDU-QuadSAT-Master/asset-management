using asset_management.Controllers;
using asset_management.Models.Antennas;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace asset_management.Tests
{
    [TestFixture]
    public class AntennaControllerTests
    {
        private Mock<IAntennaService> _antennaServiceMock;
        private AntennaController _antennaController;

        [SetUp]
        public void Setup()
        {
            _antennaServiceMock = new Mock<IAntennaService>();
            _antennaController = new AntennaController(_antennaServiceMock.Object);
        }

        [Test]
        public void GetAllAntennasTest()
        {
            var antennasList = new List<Antenna>
            {
                new Antenna { AntennaId = 1, Title = "Antenna1", OrganizationId = 1, Location = "HCA Airport" },
                new Antenna { AntennaId = 2, Title = "Antenna2", OrganizationId = 1, Location = "HCA Airport" }
            };
            _antennaServiceMock.Setup(service => service.GetAll()).Returns(antennasList);

            var result = _antennaController.Get() as OkObjectResult;

            // Assertions
            var HTTP_OK = 200;
            var EXPECTED_COUNT = 2;

            Assert.IsNotNull(result);
            Assert.That(HTTP_OK, Is.EqualTo(result.StatusCode));
            var antennas = result.Value as List<Antenna>;
            Assert.IsNotNull(antennas);
            Assert.That(EXPECTED_COUNT, Is.EqualTo(antennas.Count));
            _antennaServiceMock.Verify(service => service.GetAll(), Times.Once);
        }
        [Test]
        public void PostAntennaTest()
        {
            var antennaCreateRequest = new AntennaCreateRequest { Title = "Antenna1", OrganizationId = 1, Location = "HCA Airport" };
            var createdAntenna = new Antenna { AntennaId = 1, Title = "Antenna1",  Location = "HCA Airport" };

            _antennaServiceMock.Setup(service => service.Create(antennaCreateRequest)).Returns(createdAntenna);
            var result = _antennaController.Post(antennaCreateRequest) as OkObjectResult;

            // Assertions
            var HTTP_OK = 200;

            Assert.IsNotNull(result);
            Assert.That(HTTP_OK, Is.EqualTo(result.StatusCode));

            var antenna = result.Value as Antenna;

            Assert.IsNotNull(antenna);
            Assert.That(createdAntenna.AntennaId, Is.EqualTo(antenna.AntennaId));
            _antennaServiceMock.Verify(service => service.Create(antennaCreateRequest), Times.Once);
        }

        [Test]
        public void PutAntennaTest()
        {
            int antennaId = 1;
            var antennaUpdateRequest = new AntennaUpdateRequest { Title = "UpdatedAntenna1", OrganizationId = 1, Location = "HCA Airport"  };
            var updatedAntenna = new Antenna { AntennaId = 1, Title = "UpdatedAntenna1" };
            _antennaServiceMock.Setup(service => service.Update(antennaId, antennaUpdateRequest)).Returns(updatedAntenna);

            var result = _antennaController.Put(antennaId, antennaUpdateRequest) as OkObjectResult;

            var HTTP_OK = 200;
            Assert.IsNotNull(result);
            Assert.That(HTTP_OK, Is.EqualTo(result.StatusCode));
            var antenna = result.Value as Antenna;
            Assert.IsNotNull(antenna);
            Assert.That(updatedAntenna.AntennaId, Is.EqualTo(antenna.AntennaId));
            _antennaServiceMock.Verify(service => service.Update(antennaId, antennaUpdateRequest), Times.Once);
        }

        [Test]
        public void DeleteAntennaTest()
        {
            int antennaId = 1;
            _antennaServiceMock.Setup(service => service.Delete(antennaId));
            var result = _antennaController.Delete(antennaId) as OkObjectResult;

         
            var HTTP_OK = 200;
            Assert.IsNotNull(result);
            Assert.That(HTTP_OK, Is.EqualTo(result.StatusCode));

            _antennaServiceMock.Verify(service => service.Delete(antennaId), Times.Once);
        }
    }
}