using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IMCControlAPI.Class;
using IMCControlAPI.DTO;

namespace IMCControlAPI.Services
{
    public class IMCService : IIMCService
    {
        public async Task<IMCReturnDTO> CalculateIMC(double height, double weight)
        {
            IMCReturnDTO imc = new();
            imc.IMC = double.Parse((weight/height).ToString("N2")); 
            imc.IMCDescription = "";
            return imc;
        }

        public Task<bool> SaveIMC(IMCDTO imc)
        {
            throw new NotImplementedException();
        }

        
    }
}