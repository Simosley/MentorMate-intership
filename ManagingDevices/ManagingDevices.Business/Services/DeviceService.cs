using ManagingDevices.Data.Repositories;
using ManagingDevices.Domain.Entities;
using ManagingDevices.Domain.Models;

namespace ManagingDevices.Business.Services
{
    public class DeviceService : IDeviceService
    {
        private readonly IDeviceRepository _deviceRepository;
        public DeviceService(IDeviceRepository deviceRepository)
        {
            _deviceRepository = deviceRepository;
        }
        public async Task<Device> AddDevice(DeviceRequestModel deviceRequestModel)
        {
            var device = new Device
            {
                Name = deviceRequestModel.Name,
                Model = deviceRequestModel.Model,
                Manafacturer = deviceRequestModel.Manafacturer,
                ReleaseDate = deviceRequestModel.ReleaseDate,
                DateTaken = deviceRequestModel.DateTaken
            };
            var addDevice = await _deviceRepository.AddDevice(device);
            return addDevice;
        }

        public async Task<Device> DeleteDevice(int id)
        {
            var deleteDevice = await _deviceRepository.DeleteDevice(id);
            return deleteDevice;
        }

        public async Task<List<Device>> GetAllDevices(string manufacturer, string isTaken, string releasedDateInterval,string takenSince)
        {
            var allDevices = await _deviceRepository.GetAllDevices();
            if (manufacturer != null)
            {
                allDevices = allDevices.Where(x => x.Manafacturer == manufacturer).ToList();
            }
            if (isTaken !=null)
            {
                allDevices = allDevices.Where(x => x.Name == isTaken).Where(x => x.DateTaken != null).ToList();
            }
            if(releasedDateInterval != null)
            {
                var interval = releasedDateInterval.ToString();
                var split = interval.Split(" ");
                var startDate= DateTime.Parse(split[0]);
                var endDate= DateTime.Parse(split[1]);
                allDevices = allDevices.Where(x => x.ReleaseDate >=startDate && x.ReleaseDate<=endDate).ToList();
            }
            if(takenSince!= null)
            {
                var takenSinceDate = DateTime.Parse(takenSince);
                allDevices = allDevices.Where(x => x.DateTaken <= takenSinceDate).ToList();
            }
            return allDevices;
        }

        public async Task<Device> GetDeviceById(int id)
        {
            var getDeviceById = await _deviceRepository.GetDeviceById(id);
            return getDeviceById;
        }

        public async Task<Device> UpdateDevice(int id, DeviceEditRequestModel deviceEditRequestModel)
        {
            var targetDevice = await _deviceRepository.GetDeviceById(id);
            if (targetDevice == null)
            {
                return null;
            }
            else
            {
                targetDevice.Name = deviceEditRequestModel.Name;
                targetDevice.Model = deviceEditRequestModel.Model;
                targetDevice.Manafacturer = deviceEditRequestModel.Manafacturer;
                targetDevice.ReleaseDate = deviceEditRequestModel.ReleaseDate;
                targetDevice.DateTaken = deviceEditRequestModel.DateTaken;
                return await _deviceRepository.UpdateDevice(id, targetDevice);
            }          
        }
    }
}
