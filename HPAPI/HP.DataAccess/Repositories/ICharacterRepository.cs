using HP.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HP.DataAccess.Repositories
{
    public interface ICharacterRepository : IRepository<Character> 
    {
        Task<IEnumerable<Character>> GetCharactersByName(string name);
    }
}
