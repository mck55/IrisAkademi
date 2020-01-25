using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Iris.BusinessLayer.Abstract;
using Iris.Entities;
using Iris.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Iris.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IPersonService _personService;
        private readonly ILogger<PersonController> _loggerService;

        public PersonController(IPersonService personService, ILogger<PersonController> loggerService)
        {
            _personService = personService;
            _loggerService = loggerService;
        }

        [HttpGet]
        [Route("~/getperson")]
        public List<Person> Get()
        {
            _loggerService.LogInformation("/getperson");
            return _personService.GetList();
        }

        [HttpGet]
        [Route("~/person/{id}")]
        public List<Person> Get(int id)
        {
            _loggerService.LogInformation("/person/{id}");
            return _personService.GetList(x=>x.Id == id);
        }

        [HttpPost]
        [Route("/addperson")]
        public Person AddPerson([FromBody] PersonViewModel model)
        {
            if (ModelState.IsValid)
            {
                return _personService.Add(new Person()
                {
                    Age = model.Age,
                    Name = model.Name,
                    Surname = model.Surname
                });
            }
            return new Person();
        }
    }
}