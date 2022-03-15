using ManagingDevices.Domain.Entities;
using ManagingDevices.Domain.Models;

namespace ManagingDevices.Business.Services
{
    public interface IDeviceService
    {
        Task<List<Device>> GetAllDevices(string manufacturer,string isTaken, string releasedDateInterval,string takenSince);
        Task<Device> GetDeviceById(int id);
        Task<Device> AddDevice(DeviceRequestModel deviceRequestModel);
        Task<Device> DeleteDevice(int id);
        Task<Device> UpdateDevice(int id, DeviceEditRequestModel deviceEditRequestModel);
    }
}
