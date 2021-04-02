using Appli_Cinéma.DTOs.Cinema;
using Appli_Cinéma.Modele;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Appli_Cinéma.Profiles
{
    public class UserProfile : Profile
    {
        private object _mapper;

        public UserProfile()
        {
            CreateMap<UserSignUpDTO, User>()
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.Email));
        }

    }
}
