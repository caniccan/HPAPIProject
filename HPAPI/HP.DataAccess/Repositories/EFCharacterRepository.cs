using HP.DataAccess.Data;
using HP.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HP.DataAccess.Repositories
{
    public class EFCharacterRepository : ICharacterRepository
    {
        private HPDbContext context;
        public EFCharacterRepository(HPDbContext context)
        {
            this.context = context;
        }

        public async Task Add(Character entity)
        {
            await this.context.AddAsync(entity);
            await this.context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var character = await context.Characters.FirstOrDefaultAsync(c => c.Id == id);
            context.Characters.Remove(character);
            await context.SaveChangesAsync();
        }

        public async Task<IList<Character>> GetAll()
        {
            var characters = await context.Characters.ToListAsync();
            return characters;
        }

        public async Task<Character> GetById(int id)
        {
            return await context.Characters.FindAsync(id);
        }

        public async Task<IEnumerable<Character>> GetCharactersByName(string name)
        {
            return await context.Characters.Where(c => c.Name.Contains(name)).ToListAsync();
        }

        public async Task<bool> IsExist(int id)
        {
            return await context.Characters.AnyAsync(c => c.Id == id);
        }

        public async Task Update(Character entity)
        {
            context.Characters.Update(entity);
            await context.SaveChangesAsync();
        }
    }
}
