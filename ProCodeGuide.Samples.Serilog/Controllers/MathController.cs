using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProCodeGuide.Samples.Serilog.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class MathController : ControllerBase
    {
        private readonly ILogger<MathController> _logger;

        public MathController(ILogger<MathController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public decimal Divide(decimal a, decimal b)
        {
            try
            {
                return (a / b);
            }
            catch (Exception ex)
            {
                _logger.LogInformation("Error in Divide Method - Value of a is {a}", a);
                _logger.LogInformation("Error in Divide Method - Value of b is {b}", b);
                _logger.LogError(ex, "Error in Divide Method");
                return 0;
            }
        }
    }
}