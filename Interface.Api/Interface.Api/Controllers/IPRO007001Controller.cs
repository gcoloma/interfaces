using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Interface.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IPRO007001Controller : ControllerBase
    {
        // GET: api/<IPRO007001Controller>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<IPRO007001Controller>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<IPRO007001Controller>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<IPRO007001Controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<IPRO007001Controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
