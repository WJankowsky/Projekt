using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Projekt.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ONPController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get(string formula)
        {
            ONP test = new ONP(formula);
            return Ok(formula);
        }
    }
}
