using DemoApii.Models;
using DemoApii.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DemoAPi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeworkController : ControllerBase
    {
        private static readonly string[] _Victims = new[]
        {
            "Daniel Todorov",
            
            "Simeon Tsolov"
        };
        private static readonly string[] _Tortures = new[]
        {
            ".NET", "Java"
        };

        private readonly IHomeworkService _homeworkService;

        public HomeworkController(IHomeworkService homeworkService)
        {
            _homeworkService = homeworkService;
        }


        [Route("victim")]
        [HttpGet]
        public async Task<string> Victim()
        {
            var fate = new Random();
            int index = fate.Next(_Victims.Count());
            string vic = _Victims[index];

            await Task.Delay(2000);

            return vic;
        }

        [Route("torture")]
        [HttpGet]
        public string Torture()
        {
            var fate = new Random();
            int index = fate.Next(_Tortures.Count());
            string vic = _Tortures[index];

            Thread.Sleep(3000);

            return vic;
        }

        /// <summary>
        /// https://swapi.dev/
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        [Route("person")]
        [HttpGet]
        //The GetByName() task execute and it waits to be finished then it passed it to GetPerson and its ready to be returned
        //if the requested thing was very very big,sometimes there will be error if its not async because it wont be able to load it quickly
        //here we say lets first get it ,then return it
        public async Task<Person> GetPerson(string name)
        {
            var swPerson = await _homeworkService.GetByName(name);
            return swPerson;
        }


    }
}
