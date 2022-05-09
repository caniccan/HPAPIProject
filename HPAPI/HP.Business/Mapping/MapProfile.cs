using AutoMapper;
using HP.DataTransferObjects.Requests;
using HP.DataTransferObjects.Responses;
using HP.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HP.Business.Mapping
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<Character, CharacterDisplayResponse>();
            CreateMap<AddCharacterRequest, Character>();
            CreateMap<UpdateCharacterRequest, Character>();
        }
    }
}
