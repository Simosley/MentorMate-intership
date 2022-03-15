using ManagingDevices.Domain.Entities;

namespace ManagingDevices.Data.Repositories
{
    public interface IDeviceRepository
    {
        Task<List<Device>> GetAllDevices();
        Task<Device> GetDeviceById(int id);
        Task<Device> AddDevice(Device device);
        Task<Device> DeleteDevice(int id);
        Task<Device> UpdateDevice(int id, Device device);
    }
}
