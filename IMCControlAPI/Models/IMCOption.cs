

namespace IMCControlAPI.Models
{
    public class IMCOption
    {
        public int Id {set;get;}
        public string Description {set;get;} = "";
        public double Min {get;set;}
        public double Max {get;set;}
        public string Color {get;set;} = "";
    }
}