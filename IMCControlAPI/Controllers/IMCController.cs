using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace IMCControlAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class IMCController : ControllerBase
    {
        
        [HttpPost]
        public async Task<IActionResult> CalculateImc(double height, double weight){

            return Ok("");
        }
    }
}