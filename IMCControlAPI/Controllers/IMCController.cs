using AutoMapper;
using IMCControlAPI.Data;
using IMCControlAPI.DTO;
using IMCControlAPI.Models;
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
        private readonly IMapper _mapper;
        public IMCController(DataContext context, IIMCService iMCService, IMapper mapper){
            this._context = context;
            this._imcService = iMCService;
            this._mapper = mapper;
        }

        [HttpGet("calculateimc/{height}/{weight}")]
        public async Task<IActionResult> CalculateImc(double height, double weight){

            return Ok(await _imcService.CalculateIMC(height,weight));
        }

        [HttpGet("getoptions")]
        public async Task<IActionResult> GetOptions(){

            return Ok(await _context.IMCOptions.ToListAsync());
        }

        [HttpGet("getimcsuser/{Uuid}")]
        public async Task<IActionResult> GetImcsUser(string Uuid){
            return Ok(await _context.IMCUsers.Where(x => x.Uuid == Uuid).OrderByDescending(x => x.TimesTamp).ToListAsync());
        }

        [HttpPost("saveimc")]
        public async Task<IActionResult> SaveImc(IMCDTO imc){
            try
            {
                IMCUser imcUser = _mapper.Map<IMCUser>(imc);
                await _context.IMCUsers.AddAsync(imcUser);
                await _context.SaveChangesAsync();
                return Ok(true);
            }
            catch (System.Exception ex)
            {
                
                return BadRequest(false);
            }
        }

        [HttpDelete("deleteimc/{id}")]
        public async Task<IActionResult> DeleteImc(int id){
            try
            {
                var imc = await _context.IMCUsers.FirstOrDefaultAsync(x => x.Id == id);
                _context.IMCUsers.Remove(imc);
                await _context.SaveChangesAsync();
                return Ok(true);
            }
            catch (System.Exception ex)
            {
                
                return BadRequest(false);
            }
        }
    }
}