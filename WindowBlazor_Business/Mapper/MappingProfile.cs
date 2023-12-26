using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowBlazor_DataAccess;
using WindowBlazor_Models;

namespace WindowBlazor_Business.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Category, CategoryDTO>().ReverseMap();
            CreateMap<Window, WindowDTO>().ReverseMap();
            CreateMap<SubElement, SubElementDTO>().ReverseMap();
        }
    }
}
