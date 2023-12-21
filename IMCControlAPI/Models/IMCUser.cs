using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IMCControlAPI.Models
{
    public class IMCUser
    {
        int Id {set;get;}
        string Uuid {set;get;} = "";
        double height {set;get;}
        double weight {set;get;}
        double imc {set;get;}
        string imcDescription {set;get;} = "";
    }
}