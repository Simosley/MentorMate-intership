using ManagingDevices.Business.Services;
using ManagingDevices.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace ManagingDevicesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DevicesController : ControllerBase
    {
        private readonly IDeviceService _deviceService;

        public DevicesController(IDeviceService deviceService)
        {
            _deviceService = deviceService;
        }

        [HttpGet]
        public async Task<ActionResult> GetAllDevices(string? manufacturer, string? isTaken, string? releasedDateInterval, string? takenSince)
        {
            var allDevices = await _deviceService.GetAllDevices(manufacturer, isTaken, releasedDateInterval,takenSince);
            if (allDevices == null)
            {
                return BadRequest("no devices in database");
            }
            else
            {
                return Ok(allDevices);
            }
        }
        [HttpGet("{id}")]
        public async Task<ActionResult> GetDeviceById(int id)
        {
            var getDeviceById = await _deviceService.GetDeviceById(id);
            if (getDeviceById == null)
            {
                return BadRequest("no such device");
            }
            else
            {
                return Ok(getDeviceById);
            }
        }

        [HttpPost]
        public async Task<ActionResult> AddDevice(DeviceRequestModel deviceRequestModel)
        {
            var addDevice = await _deviceService.AddDevice(deviceRequestModel);
            if (addDevice == null)
            {
                return BadRequest();
            }
            else
            {
                return Ok(addDevice);
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateDevice(int id, DeviceEditRequestModel deviceEditRequestModel)
        {
            var updateDevice = await _deviceService.UpdateDevice(id, deviceEditRequestModel);
            if (updateDevice == null)
            {
                return BadRequest();
            }
            else
            {
                return Ok(deviceEditRequestModel);
            }
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteDevice(int id)
        {
            var deleteDevice = await _deviceService.DeleteDevice(id);
            if (deleteDevice == null)
            {
                return BadRequest("no such device");
            }
            else
            {
                return Ok("Device deleted successfully");
            }
        }
    }
}
