using DemoApii.Models;
using System.Threading.Tasks;

namespace DemoApii.Services
{
    public interface IHomeworkService
    {
        Task<Person> GetByName(string name);
    }
}
