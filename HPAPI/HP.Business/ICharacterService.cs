using HP.DataTransferObjects.Requests;
using HP.DataTransferObjects.Responses;
using HP.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HP.Business
{
    public interface ICharacterService
    {
        Task<IList<CharacterDisplayResponse>> GetCharacters();
        Task<CharacterDisplayResponse> GetCharacter(int id);
        Task<IList<CharacterDisplayResponse>> GetCharactersByName(string key);
        Task<int> AddCharacter(AddCharacterRequest request);
        Task UpdateCharacter(UpdateCharacterRequest request);
        Task DeleteCharacter(int id);
        Task<bool> IsCharacterExists(int id);
    }
}
