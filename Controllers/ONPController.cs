using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Projekt.Controllers
{
    [ApiController]
    [Produces("application/json")]
    public class ONPController : ControllerBase
    {
        [HttpGet]
        [Route("api/tokens")]
        public IActionResult Get(string formula)
        {
            ONP test = new ONP(formula);
            string[] infix = test.Tokeny(test.Wejscie);
            if (!test.Sprawdzenie(infix))
            {
                var data = new {
                    status = "error",
                    message = "invalid formula"
                };
                return BadRequest(data);
            }else{
                List<string> postfix = test.Zamiana(infix);
                var data = new {
                    status = "ok",
                    result = new {
                        infix = infix,
                        rpn = postfix
                    }
                };
                return Ok(data);
            }
        }

        [HttpGet]
        [Route("api/calculate")]
        public IActionResult Get(string formula, double x)
        {
            ONP test = new ONP(formula);
            string[] infix = test.Tokeny(test.Wejscie);
            if (!test.Sprawdzenie(infix))
            {
                var data = new {
                    status = "error",
                    message = "invalid formula"
                };
                return BadRequest(data);
            }else{
                List<string> postfix = test.Zamiana(infix);
                var data = new {
                    status = "ok",
                    result = test.ObliczaniePostfixa(postfix)
                };
                return Ok(data);
            }
        }

        [HttpGet]
        [Route("api/calculate/xy")]
        public IActionResult Get(string formula, double from, double to, int n)
        {
            ONP test = new ONP(formula);
            string[] infix = test.Tokeny(test.Wejscie);
            if (!test.Sprawdzenie(infix))
            {
                var data = new {
                    status = "error",
                    message = "invalid formula"
                };
                return BadRequest(data);
            }else{
                List<string> postfix = test.Zamiana(infix);
                var data = new {
                    status = "ok",
                    result = "nic"
                };
                return Ok(data);
            }
        }
    }
}
