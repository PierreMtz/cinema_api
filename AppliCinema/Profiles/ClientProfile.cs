using Appli_Cinéma.DTOs.Cinema;
using Appli_Cinéma.Modele;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Appli_Cinéma.Profiles
{
    public class ClientProfile : Profile
    {
        public ClientProfile()
        {
            CreateMap<Client, ClientDTO>();

            CreateMap<ClientForCreateDTO, Client>();

            CreateMap<ClientForUpdateDTO, Client>();

        }
    }
}
