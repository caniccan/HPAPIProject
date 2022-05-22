using HP.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HP.DataAccess.Repositories
{
    public class FakeCharacterRepository : ICharacterRepository
    {
        private List<Character> characters;
        public FakeCharacterRepository()
        {
            characters = new List<Character>
            {
                new Character{Id=1, BirthYear=1999, EyeColor="Brown", Gender="Male",
                    HairColor="Brown", HaveNose=true, Pet="Cat", Height=193, Mass=90,
                    Name="Can", Surname="İçcan", SkinColor="White", Wands="Dont Have"},
                new Character{Id=2, BirthYear=1980, EyeColor="Bright green", Gender="Male",
                    HairColor="Jet-black", HaveNose=true, Pet="Snowy owl", Height=180, Mass=67,
                    Name="Harry James", Surname="Potter", SkinColor="Light", Wands="Harry Potter's Wand, Blackthorn Wand, Draco Malfoy's Wand, Elder Wand"}
            };
        }

        public Task Add(Character entity)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IList<Character>> GetAll()
        {
            return characters;
        }

        public Character GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Character> GetCharactersByName(string name)
        {
            throw new NotImplementedException();
        }

        public Task<bool> IsExist(int id)
        {
            throw new NotImplementedException();
        }

        public Task Update(Character entity)
        {
            throw new NotImplementedException();
        }

        Task<Character> IRepository<Character>.GetById(int id)
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<Character>> ICharacterRepository.GetCharactersByName(string name)
        {
            throw new NotImplementedException();
        }
    }
}
