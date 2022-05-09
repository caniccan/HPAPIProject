using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using HP.DataAccess.Repositories;
using HP.DataTransferObjects.Requests;
using HP.DataTransferObjects.Responses;
using HP.Entities;

namespace HP.Business
{
    public class CharacterService : ICharacterService
    {
        private readonly IMapper mapper;
        private readonly ICharacterRepository characterRepository;
        private List<Character> characters;
        public CharacterService(ICharacterRepository characterRepository, IMapper mapper)
        {
            this.mapper = mapper;
            this.characterRepository = characterRepository;
        }

        public async Task<int> AddCharacter(AddCharacterRequest request)
        {
            var character = mapper.Map<Character>(request);
            character.CreatedAt = DateTime.Now;
            await characterRepository.Add(character);
            return character.Id;

        }

        public async Task DeleteCharacter(int id)
        {
            await characterRepository.Delete(id);
        }

        public async Task<CharacterDisplayResponse> GetCharacter(int id)
        {
            var character=await characterRepository.GetById(id);
            var characterDisplayResponse=mapper.Map<CharacterDisplayResponse>(character);
            return characterDisplayResponse;
        }

        public async Task<IList<CharacterDisplayResponse>> GetCharacters()
        {
            var character= await characterRepository.GetAll();
            var result = mapper.Map<IList<CharacterDisplayResponse>>(character);
            return result;
        }

        public async Task<IList<CharacterDisplayResponse>> GetCharactersByName(string key)
        {
            var characters= await characterRepository.GetCharactersByName(key);
            var result=mapper.Map<IList<CharacterDisplayResponse>>(characters);
            return result;
        }

        public async Task<bool> IsCharacterExists(int id)
        {
            return await characterRepository.IsExist(id);

        }

        public async Task UpdateCharacter(UpdateCharacterRequest request)
        {
            var character=mapper.Map<Character>(request);
            await characterRepository.Update(character);
        }
    }
}
