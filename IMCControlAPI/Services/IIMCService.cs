using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IMCControlAPI.Class;
using IMCControlAPI.DTO;

namespace IMCControlAPI.Services
{
    public interface IIMCService
    {
        public Task<IMCReturnDTO> CalculateIMC(double height, double weight);
        public Task<bool> SaveIMC(IMCDTO imc);
    }
}