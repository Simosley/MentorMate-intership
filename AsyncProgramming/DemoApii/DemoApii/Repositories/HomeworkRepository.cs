using DemoApii.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading;
using System.Threading.Tasks;

namespace DemoApii.Services
{
    public class HomeworkRepository: IHomeworkRepository
    {
        static readonly HttpClient _HttpClient = new HttpClient();

        private async Task<List<Person>> _GetPerson()
        {
            var swApiResponse = await _HttpClient.GetFromJsonAsync<SwApiResponse>("https://swapi.dev/api/people/");
            var swPeople = swApiResponse.results;
            return swPeople;
        }


        public async Task<Person> GetByName(string name)
        {
            var getPerson = await _GetPerson();
            var result =  getPerson
                            .Where(x => x.Name == name)
                            .FirstOrDefault();

            await Task.Delay(1500);         
            return  result;
        }
    }
}
