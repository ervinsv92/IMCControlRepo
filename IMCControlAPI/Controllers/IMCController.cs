using IMCControlAPI.Data;
using IMCControlAPI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IMCControlAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class IMCController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IIMCService _imcService;
        public IMCController(DataContext context, IIMCService iMCService){
            this._context = context;
            this._imcService = iMCService;
        }

        [HttpGet("calculateimc/{height}/{weight}")]
        public async Task<IActionResult> CalculateImc(double height, double weight){

            return Ok(await _imcService.CalculateIMC(height,weight));
        }

        [HttpGet("getoptions")]
        public async Task<IActionResult> GetOptions(){

            return Ok(await _context.IMCOptions.ToListAsync());
        }

    }
}