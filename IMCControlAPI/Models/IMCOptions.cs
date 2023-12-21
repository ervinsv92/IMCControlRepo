using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IMCControlAPI.Models
{
    public class IMCOptions
    {
        public string Description {set;get;} = "";
        public double Min {get;set;}
        public double Max {get;set;}
    }
}