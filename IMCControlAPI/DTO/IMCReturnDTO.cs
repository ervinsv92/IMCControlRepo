using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IMCControlAPI.Class
{
    public class IMCReturnDTO
    {
        public double IMC {set;get;}
        public string IMCDescription {set;get;} = "";
        public string Color {set;get;} = "";
    }
}