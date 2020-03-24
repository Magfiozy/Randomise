using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Randomise.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RandomNumbersController : ControllerBase
    {

        [HttpGet]
        public ActionResult<int> Get()
        {
            Random rnd = new Random();
            return Ok(rnd.Next(1,100));
        }

    }
}
