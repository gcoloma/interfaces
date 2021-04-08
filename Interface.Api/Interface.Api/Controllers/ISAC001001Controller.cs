using Interface.Api.Models.ISAC001001.Request;
using Interface.Api.Models.ISAC001001.Response;
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
    public class ISAC001001Controller : ControllerBase
    {
        
        // POST api/<ISAC001001Controller>
        [HttpPost]
        [Route("APISAC001001")]
        public async Task<ActionResult<APISAC001001MessageResponseLegado>>    APISAC001001(APISAC001001MessageRequestLegado mensajerecibido)
        {

            return Ok();
        }


        
    }
}
