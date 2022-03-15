using DemoApii.Models;
using System.Threading.Tasks;

namespace DemoApii.Services
{
    public class HomeworkService : IHomeworkService
    {
        private readonly IHomeworkRepository _homeworkRepository;

        public HomeworkService(IHomeworkRepository homeworkRepository)
        {
            _homeworkRepository = homeworkRepository;
        }

        public async Task<Person> GetByName(string name)
        {
            var result = await _homeworkRepository.GetByName(name);

            if (result.Height > 9000)
            {
                result.Height = 900;
            }

            return result;
        }
    }
}
