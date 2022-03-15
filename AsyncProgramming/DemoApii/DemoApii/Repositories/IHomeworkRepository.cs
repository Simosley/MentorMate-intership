using DemoApii.Models;
using System.Threading.Tasks;

namespace DemoApii.Services
{
    public interface IHomeworkRepository
    {
        public Task<Person> GetByName(string name);
    }
}
