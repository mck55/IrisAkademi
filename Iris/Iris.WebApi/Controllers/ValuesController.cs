using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Iris.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ResponseCache(Duration = 1000, Location = ResponseCacheLocation.Any)]
    public class ValuesController : Controller
    {

        public ILogger<ValuesController> _logger;
        public ValuesController(ILogger<ValuesController> logger)
        {
            _logger = logger;
        }
        // GET: api/<controller>
        [HttpGet]
        public string Get()
        {
            //throw new Exception("Deneme Hata Mesajı Loglarda gözükmesi için.Global Exception Handling");
            var watch = new Stopwatch();

            watch.Start();
            _logger.LogInformation("api/values/get");
            string exp = string.Empty;
            for (int i = 0; i < 20000; i++)
            {
                exp += i.ToString()+",";
            }
            watch.Stop();
            return "** Süre : "+watch.ElapsedMilliseconds+" -- "+exp;
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            var watch = new Stopwatch();

            watch.Start();
            for (int i = 0; i < 1000000; i++)
            {

            }
            _logger.LogInformation("api/values/get/id");
            watch.Stop();
            return id + "** Süre " + watch.ElapsedMilliseconds.ToString();
        }

        // POST api/<controller>
        [HttpPost]
        public void Post([FromBody]string value)
        {
            _logger.LogInformation("POST");
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
            _logger.LogInformation("api/values/PUT/");
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _logger.LogInformation("delete");
        }
    }
}
