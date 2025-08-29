using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskProjectManagementApi.Application.Features.CQRS.Auth.Register;
using TaskProjectManagementApi.Domain.Entity;

namespace TaskProjectManagementApi.Application
{
    public class MapperProfile : Profile  
    {
        public MapperProfile()
        {
            CreateMap<RegisterCommandRequest, User>()
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email));
        }
    }
}
