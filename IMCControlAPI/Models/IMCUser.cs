using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IMCControlAPI.Models
{
    public class IMCUser
    {
        public int Id {set;get;}
        public string Uuid {set;get;} = "";
        public double Height {set;get;}
        public double Weight {set;get;}
        public double Imc {set;get;}
        public string ImcDescription {set;get;} = "";
        public string ImcColor {set;get;} = "";
        public DateTime TimesTamp {set;get;} = DateTime.Now;
    }
}