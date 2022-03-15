using ManagingDevices.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ManagingDevices.Data
{
    public class ManagingDevicesApiContext : DbContext
    {
        public ManagingDevicesApiContext(DbContextOptions<ManagingDevicesApiContext> options) : base(options) { }
        public DbSet<Device> Devices { get; set; }
    }
}
