using ManagingDevices.Business.Services;
using ManagingDevices.Data.Repositories;
using ManagingDevices.Domain.Entities;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace ManagingDevices.Tests
{
    public class DeviceServiceTests
    {
        private readonly DeviceService _sut;
        private readonly Mock<IDeviceRepository> _deviceRepoMock = new Mock<IDeviceRepository>();
        public DeviceServiceTests()
        {
            _sut = new DeviceService(_deviceRepoMock.Object);
        }

        //string manufacturer, string isTaken, string releasedDateInterval,string takenSince
        [Fact]
        public async Task GetAllDevices_ShouldReturnDevice_When_Device_Exists()
        {
            //Arrange
            var deviceManufacturer = "Apple";
            var deviceIsTaken = "Iphone";
            var releasedDateInterval = "2022-03-01 2022-03-03";
            var takenSince = "2022-03-05";
            var expectedItems = new List<Device> { CreateRandomDevice() };
            var deviceDto = new Device
            {
                Id = 1,
                Manafacturer = "Iphone",
                Model = "Apple",
                ReleaseDate = new DateTime(2022,03,03),
                DateTaken = new DateTime(2022,03,02)
            };
            _deviceRepoMock.Setup(x => x.GetAllDevices()).ReturnsAsync(expectedItems);
            //Act
            var device = await _sut.GetAllDevices(deviceManufacturer,deviceIsTaken, releasedDateInterval, takenSince);
            //Assert
            Assert.Equal(deviceManufacturer,device[0].Manafacturer);
            
        }

        private Device CreateRandomDevice()
        {
            return new()
            {
                Id = 1,
                Name = "Iphone",
                Manafacturer = "Apple",
                Model = "X",
                ReleaseDate = new DateTime(2022, 03, 03),
                DateTaken = new DateTime(2022, 03, 02)
            };
        }
    }
}