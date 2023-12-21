using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using IMCControlAPI.DTO;
using IMCControlAPI.Models;

namespace IMCControlAPI.Mapper
{
    public class MappingDTO:Profile
    {
        public MappingDTO(){
            CreateMap<IMCDTO, IMCUser>();
        }
    }
}