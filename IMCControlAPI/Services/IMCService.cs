using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IMCControlAPI.Class;
using IMCControlAPI.Data;
using IMCControlAPI.DTO;
using IMCControlAPI.Models;

namespace IMCControlAPI.Services
{
    public class IMCService : IIMCService
    {
        private readonly DataContext _context;
        public IMCService(DataContext context){
            _context = context;
        }
        public async Task<IMCReturnDTO> CalculateIMC(double height, double weight)
        {
            IMCReturnDTO imc = new();
            imc.IMC = double.Parse((weight/(Math.Pow(height/100,2))).ToString("N2")); 
            
            var listOptions = _context.IMCOptions.ToList<IMCOption>();
            var option = listOptions.FirstOrDefault(x => imc.IMC >= x.Min && imc.IMC <= x.Max);
            if(option != null){
                imc.IMCDescription = option.Description;
                imc.Color = option.Color;
            }
            return imc;
        }

        public Task<bool> SaveIMC(IMCDTO imc)
        {
            throw new NotImplementedException();
        }

        
    }
}