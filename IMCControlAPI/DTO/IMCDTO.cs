using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IMCControlAPI.DTO
{
    public class IMCDTO
    {
        public int Id {set;get;}
        public string Uuid {set;get;} = "";
        public double height {set;get;}
        public double weight {set;get;}
        public double imc {set;get;}
        public string imcDescription {set;get;} = "";
    }
}