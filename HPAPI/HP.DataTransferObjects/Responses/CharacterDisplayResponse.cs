using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HP.DataTransferObjects.Responses
{
    public class CharacterDisplayResponse
    {
        public int CharacterId { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public int BirthYear { get; set; }
        public string? Gender { get; set; }
        public string? Wands { get; set; }
    }
}
