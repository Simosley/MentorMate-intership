using ManagingDevices.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ManagingDevices.Data.Repositories
{
    public class DeviceRepository : IDeviceRepository
    {
        private readonly ManagingDevicesApiContext _context;
        public DeviceRepository(ManagingDevicesApiContext context)
        {
            _context = context;
        }
        public async Task<Device> AddDevice(Device device)
        {
            _context.Add(device);
            await _context.SaveChangesAsync();
            return device;
        }

        public async Task<Device> DeleteDevice(int id)
        {
            var getUserById = await _context.Devices.FindAsync(id);
            if (getUserById == null)
            {
                return null;
            }
            _context.Devices.Remove(getUserById);
            await _context.SaveChangesAsync();
            return getUserById;
        }

        public async Task<List<Device>> GetAllDevices()
        {
            var allDevices = await _context.Devices.OrderByDescending(x => x.ReleaseDate).ToListAsync();
            return allDevices;
        }

        public async Task<Device> GetDeviceById(int id)
        {
            var getDeviceById = await _context.Devices.FindAsync(id);
            return getDeviceById;
        }

        public async Task<Device> UpdateDevice(int id, Device device)
        {
            _context.Devices.Update(device);
            await _context.SaveChangesAsync();
            return device;
        }
    }
}
